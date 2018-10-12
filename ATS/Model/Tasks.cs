using System;
using System.Collections.Generic;
using System.Text;
using ATS.Model;
using Xamarin.Forms;
using System.Diagnostics;

namespace ATS.Tasks
{
    public abstract class Task : ContentPage
    {
        private NestedTaskLayout parent;
        private Label name;
        protected Label complete;
        protected ScrollView mainView;
        protected StackLayout intermediate;

        protected abstract void CheckCompletion();
        protected abstract void Reset();
        public abstract List<Tuple<string,Entry>> GetEntries();
        public abstract void FinishEditing(List<Entry> entries);
        protected abstract void ToggleComponents(bool b);

        public bool Completed = false;

        public Task(NestedTaskLayout parent, string n) : base()
        {
            this.parent = parent;

            mainView = new ScrollView();
            intermediate = new StackLayout();
            name = new Label();
            name.HorizontalOptions = LayoutOptions.Center;
            name.Text = n;

            complete = new Label();
            complete.HorizontalOptions = LayoutOptions.Center;
            complete.Text = "Complete";
            complete.IsVisible = false;

            Button reset = new Button();
            reset.HorizontalOptions = LayoutOptions.Center;
            reset.Text = "Reset";
            reset.Clicked += ButtonReset;

            intermediate.Children.Add(name);
            intermediate.Children.Add(complete);
            intermediate.Children.Add(reset);
            mainView.Content = intermediate;
            this.Content = mainView;
        }

        public string GetName()
        {
            return name.Text;
        }

        public void UpdateName(string s)
        {
            name.Text = s;
        }

        private void ButtonReset(object sender, EventArgs args)
        {
            SetComplete(false);
            Reset();
        }

        protected void SetComplete(bool c)
        {
            if (Completed == c)
                return;
            complete.IsVisible = c;
            Completed = c;
            ToggleComponents(c);
            parent.CheckCompletion();
        }

        public TaskEditor GetEditor()
        {
            List<Tuple<string, Entry>> entryList = GetEntries();
            List<string> names = new List<string>();
            List<Entry> entries = new List<Entry>();
            foreach(Tuple<string, Entry> pair in entryList)
            {
                names.Add(pair.Item1);
                entries.Add(pair.Item2);
            }
            return new TaskEditor(this, names, entries);
        }

        protected Tuple<string, Entry> GetGenericEntry(string s)
        {
            Entry res = new Entry();
            res.WidthRequest = 200;
            return new Tuple<string, Entry>(s, res);
        }

        protected Tuple<string, Entry> GetGenericNumEntry(string s)
        {
            Entry res = new Entry();
            res.WidthRequest = 200;
            res.Keyboard = Keyboard.Numeric;
            return new Tuple<string, Entry>(s, res);
        }

    }

    public class DurationTask : Task
    {
        private Label goalTime;
        private Label curTime;
        private float mTime;
        private float gTime;
        private float cTime;

        private bool timing = false;

        private Button timer;


        public DurationTask(NestedTaskLayout p, string n) : base(p, n)
        {
            goalTime = new Label();
            goalTime.Text = "00:00:00";
            goalTime.HorizontalOptions = LayoutOptions.Center;
            curTime = new Label();
            curTime.Text = "00:00:00";
            curTime.HorizontalOptions = LayoutOptions.Center;
            intermediate.Children.Add(curTime);

            timer = new Button();
            timer.Text = "Start";
            timer.Clicked += ToggleTimer;
            timer.HorizontalOptions = LayoutOptions.Center;
            intermediate.Children.Add(timer);
            intermediate.Children.Add(goalTime);
            
        }

        private void ToggleTimer(object sender, EventArgs a)
        {
            float interval = 100;
            if(timing)
            {
                CheckCompletion();
                timer.Text = "Start";
                
            }
            else
            {
                cTime = 0;
                Device.StartTimer(TimeSpan.FromMilliseconds(interval), () =>
                {
                    if (!timing)
                        return false;
                    else
                    {
                        cTime += interval / 1000;
                        curTime.Text = TimeSpan.FromSeconds(cTime).ToString(@"mm\:ss\:ff");
                        return true;
                    }
                }
                );
                timer.Text = "Stop";
            }
            timing = !timing;
        }

        protected override void Reset()
        {
            if (timing)
                ToggleTimer(null, null);
            mTime = 0;
            curTime.Text = "00:00:00";
        }

        protected override void ToggleComponents(bool b)
        {
            timer.IsEnabled = !b;
            timer.TextColor = b ? Color.Gray : Color.Blue;
        }

        protected override void CheckCompletion()
        {
            if(cTime > mTime)
            {
                mTime = cTime;
            }
            if(mTime >= gTime)
            {
                SetComplete(true);
            }
        }

        public override List<Tuple<string, Entry>> GetEntries()
        {
            //we just need a time to pass
            return new List<Tuple<string, Entry>>()
            {
                GetGenericNumEntry("Time to pass (s) ")
            };
        }

        public override void FinishEditing(List<Entry> entries)
        {
            float.TryParse(entries[0].Text, out gTime);
            goalTime.Text = TimeSpan.FromSeconds(gTime).ToString(@"mm\:ss\:ff");
        }

    }

    public class FrequencyTask : Task
    {

        private int current, needed;
        private Label currentL, neededL;
        private Button add;

        public FrequencyTask(NestedTaskLayout p, string n) : base(p, n)
        {
            currentL = new Label();
            neededL = new Label();
            currentL.HorizontalOptions = LayoutOptions.Center;
            neededL.HorizontalOptions = LayoutOptions.Center;
            currentL.Text = "0";
            neededL.Text = "0";
            neededL.HorizontalTextAlignment = TextAlignment.Center;
            currentL.HorizontalTextAlignment = TextAlignment.Center;

            add = new Button();
            add.HorizontalOptions = LayoutOptions.Center;
            add.Text = "Record Occurance";
            add.Clicked += AddClicked;

            intermediate.Children.Add(currentL);
            intermediate.Children.Add(add);
            intermediate.Children.Add(neededL);

        }

        private void AddClicked(object sender, EventArgs a)
        {
            current++;
            currentL.Text = current + "";
            CheckCompletion();
        }

        protected override void Reset()
        {
            current = 0;
            currentL.Text = "0";
        }

        protected override void ToggleComponents(bool b)
        {
            add.IsEnabled = !b;
            add.TextColor = b ? Color.Gray : Color.Blue;
        }

        protected override void CheckCompletion()
        {
            if (current >= needed)
                SetComplete(true);
        }

        public override List<Tuple<string, Entry>> GetEntries()
        {
            return new List<Tuple<string, Entry>>()
            {
                GetGenericNumEntry("Number of successes needed: ")
            };

        }

        public override void FinishEditing(List<Entry> entries)
        {
            int.TryParse(entries[0].Text, out needed);
            neededL.Text = needed + "";
        }
    }

    public class OpportunityTask : Task
    {
        private List<bool> results;
        private float needed, current;
        private int numTests, numDone;

        private Label neededL, currentL, numTestsL, numDoneL;
        private Button pass, fail;

        public OpportunityTask(NestedTaskLayout p, string n) : base(p, n)
        {
            results = new List<bool>();
            neededL = new Label();
            neededL.HorizontalOptions = LayoutOptions.Center;
            neededL.HorizontalTextAlignment = TextAlignment.Center;
            neededL.Text = "0.00%";
            currentL = new Label();
            currentL.HorizontalOptions = LayoutOptions.Center;
            currentL.HorizontalTextAlignment = TextAlignment.Center;
            currentL.Text = "0.00%";
            numTestsL = new Label();
            numTestsL.HorizontalOptions = LayoutOptions.Center;
            numTestsL.HorizontalTextAlignment = TextAlignment.Center;
            numTestsL.Text = "0";
            numDoneL = new Label();
            numDoneL.HorizontalOptions = LayoutOptions.Center;
            numDoneL.HorizontalTextAlignment = TextAlignment.Center;
            numDoneL.Text = "0";

            StackLayout real = new StackLayout();
            real.Orientation = StackOrientation.Horizontal;
            real.HorizontalOptions = LayoutOptions.Center;
            real.Children.Add(numDoneL);
            real.Children.Add(currentL);

            StackLayout need = new StackLayout();
            need.Orientation = StackOrientation.Horizontal;
            need.HorizontalOptions = LayoutOptions.Center;
            need.Children.Add(numTestsL);
            need.Children.Add(neededL);

            StackLayout buttons = new StackLayout();
            buttons.HorizontalOptions = LayoutOptions.Center;
            buttons.Orientation = StackOrientation.Horizontal;
            pass = new Button();
            fail = new Button();
            pass.Text = "Pass";
            fail.Text = "Fail";
            pass.Clicked += PassClicked;
            fail.Clicked += FailClicked;
            buttons.Children.Add(pass);
            buttons.Children.Add(fail);

            intermediate.Children.Add(real);
            intermediate.Children.Add(buttons);
            intermediate.Children.Add(need);
        }

        private void PassClicked(object sender, EventArgs a)
        {
            results.Add(true);
            if(results.Count > numTests)
            {
                results.RemoveAt(0);
            }
            CheckCompletion();
        }

        private void FailClicked(object sender, EventArgs a)
        {
            results.Add(false);
            if(results.Count > numTests)
            {
                results.RemoveAt(0);
            }
            CheckCompletion();
        }

        private float CalcPercent()
        {
            if (results.Count == 0)
                return 0;
            float t = 0;
            foreach(bool b in results)
            {
                if (b)
                    t += 1;
            }
            return (t / results.Count) * 100;
        }

        protected override void Reset()
        {
            results = new List<bool>();
            CheckCompletion();
        }

        protected override void ToggleComponents(bool b)
        {
            pass.IsEnabled = !b;
            pass.TextColor = b ? Color.Gray : Color.Blue;
            fail.IsEnabled = !b;
            fail.TextColor = b ? Color.Gray : Color.Blue;
        }

        protected override void CheckCompletion()
        {
            numDone = results.Count;
            numDoneL.Text = numDone + "";
            current = CalcPercent();
            currentL.Text = current.ToString("0.00") + "%";
            if(numDone >= numTests)
            {
                if(current >= needed)
                {
                    SetComplete(true);
                }
            }
        }

        public override List<Tuple<string, Entry>> GetEntries()
        {
            return new List<Tuple<string, Entry>>()
            {
                GetGenericNumEntry("Percentage success needed: "),
                GetGenericNumEntry("Total Tests: ")
            };
        }

        public override void FinishEditing(List<Entry> entries)
        {
            float.TryParse(entries[0].Text, out needed);
            neededL.Text = needed.ToString("0.00") + "%";
            int.TryParse(entries[1].Text, out numTests);
            numTestsL.Text = numTests + "";
        }
    }

    public class PassFailTask : Task
    {
        int needed;
        int soFar;

        Label neededL;
        Label soFarL;
        Button pass, fail;

        public PassFailTask(NestedTaskLayout p, string n) : base(p, n)
        {
            neededL = new Label();
            neededL.Text = "0";
            neededL.HorizontalOptions = LayoutOptions.Center;
            neededL.HorizontalTextAlignment = TextAlignment.Center;
            soFarL = new Label();
            soFarL.Text = "0";
            soFarL.HorizontalOptions = LayoutOptions.Center;
            soFarL.HorizontalTextAlignment = TextAlignment.Center;

            StackLayout buttons = new StackLayout();
            buttons.HorizontalOptions = LayoutOptions.Center;
            buttons.Orientation = StackOrientation.Horizontal;
            pass = new Button();
            fail = new Button();
            pass.Text = "Pass";
            fail.Text = "Fail";
            pass.Clicked += PassClicked;
            fail.Clicked += FailClicked;
            buttons.Children.Add(pass);
            buttons.Children.Add(fail);
            intermediate.Children.Add(soFarL);
            intermediate.Children.Add(buttons);
            intermediate.Children.Add(neededL);
        }

        private void PassClicked(object sender, EventArgs a)
        {
            soFar++;
            soFarL.Text = soFar + "";
            CheckCompletion();
        }

        private void FailClicked(object sender, EventArgs a)
        {
            soFar = 0;
            soFarL.Text = "0";
        }

        protected override void Reset()
        {
            soFar = 0;
            soFarL.Text = "0";
        }

        protected override void ToggleComponents(bool b)
        {
            pass.IsEnabled = !b;
            pass.TextColor = b ? Color.Gray : Color.Blue;
            fail.IsEnabled = !b;
            fail.TextColor = b ? Color.Gray : Color.Blue;
        }

        protected override void CheckCompletion()
        {
            if(soFar >= needed)
            {
                SetComplete(true);
            }
        }

        public override List<Tuple<string, Entry>> GetEntries()
        {
            return new List<Tuple<string, Entry>>()
            {
                GetGenericNumEntry("Number of times needed to pass: ")
            };
        }

        public override void FinishEditing(List<Entry> entries)
        {
            int.TryParse(entries[0].Text, out needed);
            neededL.Text = needed + "";
        }
    }

}
