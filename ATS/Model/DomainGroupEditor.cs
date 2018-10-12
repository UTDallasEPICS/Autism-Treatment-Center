using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace ATS.Model
{
    class DomainGroupEditor : ContentPage
    {

        private ScrollView mainView;
        private Entry newName;
        private Editor newDescription;
        private DropDownList<NestedStackLayout.NestedTypes> categorySelect;
        private DropDownList<NestedStackLayout> parentSelect;
        private DropDownList<NestedTaskLayout.TaskType> taskSelect;
        private DomainGroup parent;
        private NestedStackLayout original;

        public DomainGroupEditor(DomainGroup dg, NestedStackLayout orig = null) : base()
        {
            original = orig;
            parent = dg;
            List<string> groupNames = new List<string>();
            List<NestedStackLayout> groups = dg.GetAllStacks();
            foreach(NestedStackLayout ss in groups)
            {
                groupNames.Add(ss.GetName());
            }
            List<NestedStackLayout.NestedTypes> groupTypes = new List<NestedStackLayout.NestedTypes>()
            {NestedStackLayout.NestedTypes.Domain, NestedStackLayout.NestedTypes.Subcategory, NestedStackLayout.NestedTypes.Goal, NestedStackLayout.NestedTypes.Task };
            List<string> groupTypeNames = new List<string>()
            {"Domain", "Subcategory", "Goal", "Task"};
            List<NestedTaskLayout.TaskType> taskTypes = new List<NestedTaskLayout.TaskType>()
            { NestedTaskLayout.TaskType.Duration, NestedTaskLayout.TaskType.Frequency, NestedTaskLayout.TaskType.Opportunity, NestedTaskLayout.TaskType.PassFail };
            List<string> taskNames = new List<string>()
            { "Duration", "Frequency", "Opportunity", "PassFail"};
            

            mainView = new ScrollView();
            StackLayout intermediate = new StackLayout();

            newName = new Entry();
            newName.Placeholder = "Enter Name...";
            newName.Text = original == null ? "" : original.GetName();
            newName.HorizontalOptions = LayoutOptions.Center;
            newName.HorizontalTextAlignment = TextAlignment.Center;
            newName.Margin = new Thickness(0, 5, 0, 0);
            newName.WidthRequest = Application.Current.MainPage.Width / 2;

            newDescription = new Editor();
            newDescription.HorizontalOptions = LayoutOptions.FillAndExpand;
            newDescription.BackgroundColor = Color.GhostWhite;
            newDescription.HeightRequest = 200;
            newDescription.WidthRequest = Application.Current.MainPage.Width - 20;
            newDescription.Text = original == null ? "" : original.GetDescription();
            Label descriptionLabel = new Label();
            descriptionLabel.Text = "Details";

            categorySelect = new DropDownList<NestedStackLayout.NestedTypes>(intermediate, "Type", groupTypeNames, groupTypes);
            categorySelect.HeightRequest = 30;
            categorySelect.VerticalOptions = LayoutOptions.Start;
            if(original != null)
            {
                categorySelect.SetSelected(original.GetStackType());
                categorySelect.Disable();
            }
            categorySelect.OnSelected = new Command(o => CategorySelected((NestedStackLayout.NestedTypes) o));

            parentSelect = new DropDownList<NestedStackLayout>(intermediate, "Parent", groupNames, groups);
            parentSelect.HeightRequest = 30;
            parentSelect.VerticalOptions = LayoutOptions.Start;
            if(original != null)
            {
                parentSelect.SetSelected(original.GetParent());
            }

            taskSelect = new DropDownList<NestedTaskLayout.TaskType>(intermediate, "Task Type", taskNames, taskTypes);
            taskSelect.VerticalOptions = LayoutOptions.Start;
            if(original != null && original.GetStackType() == NestedStackLayout.NestedTypes.Task)
            {
                taskSelect.HeightRequest = 30;
            }
            else
            {
                taskSelect.HeightRequest = 0;
                taskSelect.IsVisible = false;
            }

            Button finish = new Button();
            finish.Text = "Finish";
            finish.Clicked += FinishClicked;

            intermediate.Children.Add(newName);
            intermediate.Children.Add(categorySelect);
            intermediate.Children.Add(taskSelect);
            intermediate.Children.Add(parentSelect);
            intermediate.Children.Add(descriptionLabel);
            intermediate.Children.Add(newDescription);
            intermediate.Children.Add(finish);

            mainView.Content = intermediate;
            Content = mainView;
        }

        private void CategorySelected(NestedStackLayout.NestedTypes type)
        {
            if(type == NestedStackLayout.NestedTypes.Task)
            {
                taskSelect.IsVisible = true;
                taskSelect.HeightRequest = 30;
            }
            else
            {
                taskSelect.IsVisible = false;
                taskSelect.HeightRequest = 0;
            }
        }

        private void FinishClicked(object sender, EventArgs args)
        {
            if(newName.Text == "")
            {
                DisplayAlert("Incomplete Data", "No name was entered, please enter a name.", "OK");
                return;
            }
            string name = newName.Text;
            string description = newDescription.Text;
            NestedStackLayout.NestedTypes type = categorySelect.GetSelected();
            NestedStackLayout stackParent = parentSelect.GetSelected();
            NestedTaskLayout.TaskType taskType = taskSelect.GetSelected();
            if(original != null)
            {
                if(stackParent == original.GetParent())
                {
                    original.SetName(name);
                    original.SetDescription(description);
                    Navigation.RemovePage(this);
                }
                else
                {
                    original.GetParent().RemoveSubView(original);
                    NestedStackLayout newGroup = NestedStackLayout.CreateLayout(parent, stackParent, newName.Text, type, taskType);
                    newGroup.SetDescription(description);
                    stackParent.AddSubView(newGroup);
                    Navigation.RemovePage(this);
                }
            }
            else
            {
                NestedStackLayout newGroup = NestedStackLayout.CreateLayout(parent, stackParent, newName.Text, type, taskType);
                newGroup.SetDescription(description);
                stackParent.AddSubView(newGroup);
                Navigation.RemovePage(this);
            }

        }
    }
}
