using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace ATS.Model
{
    public class NestedStackLayout : StackLayout
    {
        public enum NestedTypes { DomainGroup, Domain, Subcategory, Goal, Task };
        private Label name = new Label { HeightRequest = 25 };
        private Label complete = new Label { HeightRequest = 25, Text = "Complete" };
        private Label description = new Label() { HeightRequest = 25 };
        private BoxView divisionLine = new BoxView() { HeightRequest = 1, Color = Color.LightGray };

        private ObservableCollection<View> subViews;
        private bool isChildVisible = false;
        private bool wasOpenWhenParentClosed = false;
        protected bool completed = false;
        //in case we want to do different formatting or something for different types
        private NestedTypes type;
        private NestedStackLayout parent;
        private DomainGroup dgParent;
        protected NestedStackLayout(DomainGroup dgPar, NestedStackLayout par, string n, NestedTypes type)
        {
            dgParent = dgPar;
            parent = par;
            this.type = type;
            subViews = new ObservableCollection<View>();

            //special casing for the top-level (displays patient name and add button)
            if (type == NestedTypes.DomainGroup)
            {
                AbsoluteLayout topper = new AbsoluteLayout();
                topper.WidthRequest = Application.Current.MainPage.Width;
                topper.HeightRequest = 25;

                name.Text = n;
                name.HorizontalTextAlignment = TextAlignment.Center;

                Button add = new Button();
                add.Text = "Add";
                add.Margin = new Thickness(0, 0, 10, 0);
                add.Clicked += dgParent.AddButtonPressed;

                AbsoluteLayout.SetLayoutBounds(name, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
                AbsoluteLayout.SetLayoutFlags(name, AbsoluteLayoutFlags.PositionProportional);
                AbsoluteLayout.SetLayoutBounds(add, new Rectangle(1, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
                AbsoluteLayout.SetLayoutFlags(add, AbsoluteLayoutFlags.PositionProportional);

                topper.Children.Add(name);
                topper.Children.Add(add);
                Children.Add(topper);

                isChildVisible = true;
            }
            else
            {
                StackLayout nameStack = new StackLayout();
                nameStack.Margin = new Thickness(0, 0, 0, 0);

                name.Text = n;
                name.HorizontalTextAlignment = TextAlignment.Start;
                name.Margin = new Thickness(20, 0, 20, 0);

                nameStack.Orientation = StackOrientation.Horizontal;
                nameStack.Children.Add(name);
                nameStack.Children.Add(complete);
                complete.Margin = new Thickness(20, 0, 20, 0);
                complete.HorizontalOptions = LayoutOptions.EndAndExpand;
                complete.IsVisible = false;

                description.Margin = new Thickness(20, 0, 20, 0);

                name.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => { ToggleChildVisibility(); }) });
                name.HorizontalOptions = LayoutOptions.Start;

                StackLayout buttonLayout = new StackLayout();
                buttonLayout.Orientation = StackOrientation.Horizontal;
                buttonLayout.HeightRequest = 20;
                AddButtons(buttonLayout);

                isChildVisible = false;

                Children.Add(nameStack);
                AddSubView(buttonLayout);
                AddSubView(description);
                Children.Add(divisionLine);
                SetDescription("I am a description for " + n + ".");
            }
            dgParent.RegisterStack(type, this);
        }

        protected virtual void AddButtons(StackLayout buttonLayout)
        {
            Button edit = new Button();
            edit.Text = "Edit";
            edit.Clicked += EditClicked;
            edit.HorizontalOptions = LayoutOptions.Start;

            Button delete = new Button();
            delete.Text = "Delete";
            delete.Clicked += DeleteClicked;
            delete.HorizontalOptions = LayoutOptions.Start;
            buttonLayout.Margin = new Thickness(20, 0, 0, 0);
            buttonLayout.HeightRequest = 20;

            buttonLayout.Children.Add(edit);
            buttonLayout.Children.Add(delete);
        }


        public void AddSubView(View n)
        {
            Children.Add(n);
            subViews.Add(n);
            n.IsVisible = isChildVisible;
            CheckCompletion();

        }

        public void RemoveSubView(View n)
        {
            Children.Remove(n);
            subViews.Remove(n);
            CheckCompletion();
        }

        public void SetDescription(string s)
        {
            description.Text = s;
        }

        public virtual void SetName(string s)
        {
            name.Text = s;
        }

        public string GetName()
        {
            return name.Text;
        }

        public string GetDescription()
        {
            return description.Text;
        }

        public NestedStackLayout.NestedTypes GetStackType()
        {
            return type;
        }

        public NestedStackLayout GetParent()
        {
            return parent;
        }

        private void EditClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new DomainGroupEditor(dgParent, this));
        }

        private async void DeleteClicked(object sender, EventArgs arg)
        {
            var res = await dgParent.DisplayAlert("Confirmation", "Are you sure you want to delete this?", "Yes", "No");
            if (res)
            {
                parent.RemoveSubView(this);
            }
        }

        public virtual void CheckCompletion()
        {
            SetComplete(CheckChildCompletion());
        }

        protected bool CheckChildCompletion()
        {
            bool complete = true;
            if (subViews == null)
                return false;
            foreach(View v in subViews)
            {
                if(v is NestedStackLayout)
                {
                    NestedStackLayout ns = v as NestedStackLayout;
                    if (!ns.completed)
                    {
                        complete = false;
                        break;
                    }
                }
            }
            return complete;
        }

        protected void SetComplete(bool c)
        {
            if (completed == c)
                return;
            complete.IsVisible = c;
            completed = c;
            if(parent != null)
                parent.CheckCompletion();
        }

        private void ForceClose()
        {
            if (!isChildVisible)
                return;
            wasOpenWhenParentClosed = true;
            foreach (View ss in subViews)
            {
                if (ss is NestedStackLayout)
                    (ss as NestedStackLayout).ForceClose();
                //ss.HeightRequest = 0;
                ss.IsVisible = isChildVisible;
            }
            isChildVisible = false;
        }

        private void ToggleChildVisibility()
        {
            //this can't be closed
            if (type == NestedTypes.DomainGroup)
                return;
            wasOpenWhenParentClosed = false;
            if (isChildVisible)
            {
                name.HeightRequest = 25;
                foreach (View ss in subViews)
                {
                    if (ss is NestedStackLayout)
                        (ss as NestedStackLayout).ForceClose();
                    //ss.HeightRequest = 0;
                    ss.IsVisible = false;
                }
            }
            else
            {
                name.HeightRequest = 20;
                foreach (View ss in subViews)
                {
                    //ss.HeightRequest = 50 * ss.Children.Count;
                    ss.IsVisible = true;
                    if (ss is NestedStackLayout)
                    {
                        NestedStackLayout nsl = ss as NestedStackLayout;
                        if (nsl.wasOpenWhenParentClosed)
                        {
                            nsl.ToggleChildVisibility();
                        }
                    }
                }
            }
            isChildVisible = !isChildVisible;
        }

        //we need to have a way to load task information, but data files should be specified before that
        public static NestedStackLayout LoadLayout(DomainGroup dg, NestedStackLayout par, string n, NestedTypes t, NestedTaskLayout.TaskType tt = NestedTaskLayout.TaskType.PassFail)
        {
            if (t == NestedTypes.Task)
            {
                return new NestedTaskLayout(dg, par, n, tt);
            }
            else
            {
                return new NestedStackLayout(dg, par, n, t);
            }
        }

        public static NestedStackLayout CreateLayout(DomainGroup dg, NestedStackLayout par, string n, NestedTypes t, NestedTaskLayout.TaskType tt = NestedTaskLayout.TaskType.PassFail)
        {
            if(t == NestedTypes.Task)
            {
                NestedTaskLayout res = new NestedTaskLayout(dg, par, n, tt);
                res.EditTask();
                return res;
            }
            else
            {
                return new NestedStackLayout(dg, par, n, t);
            }
        }
    }
}
