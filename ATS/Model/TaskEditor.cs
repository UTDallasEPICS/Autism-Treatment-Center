using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace ATS.Tasks
{
    public class TaskEditor : ContentPage
    {

        private Task task;

        private ScrollView mainView;

        private StackLayout intermediate;

        List<Entry> entries;

        public TaskEditor(Task t, List<string> names, List<Entry> entries) : base()
        {
            this.entries = entries;
            task = t;
            mainView = new ScrollView();
            intermediate = new StackLayout();

            Label name = new Label();
            name.HorizontalOptions = LayoutOptions.Center;
            name.Text = t.GetName();
            intermediate.Children.Add(name);

            for(int i = 0; i < names.Count; i++)
            {
                StackLayout pair = new StackLayout();
                pair.Orientation = StackOrientation.Horizontal;
                pair.Margin = new Thickness(0, 0, 0, 0);
                Label l = new Label();
                l.Text = names[i];
                pair.Children.Add(l);
                pair.Children.Add(entries[i]);
                intermediate.Children.Add(pair);
            }
            Button b = new Button();
            b.Text = "Finish";
            b.Clicked += FinishClicked;
            intermediate.Children.Add(b);
            mainView.Content = intermediate;
            Content = mainView;
        }

        private void FinishClicked(object sender, EventArgs args)
        {
            foreach(Entry e in entries)
            {
                if(e.Text == "")
                {
                    DisplayAlert("Incomplete Data", "Please fill out all of the fields.", "OK");
                    return;
                }
            }
            task.FinishEditing(entries);
            Navigation.RemovePage(this);
        }

    }
}
