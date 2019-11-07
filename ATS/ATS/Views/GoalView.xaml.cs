using System;
using ATS.Models;
using ATS.ViewModels;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ATS.Views
{
    public partial class GoalView : ContentPage
    {
        public GoalView()
        {
            InitializeComponent();
        }

        async void AddTaskClickedAsync(object sender, EventArgs args)
        {
            Console.WriteLine("Add task Clicked");
            //  pushes the PatientCreator view to the Navigation stack when the Add button is clicked
            //  Navigation.PushAsync(new PatientCreator());
            await Navigation.PushAsync(new TaskCreatorView());
        }

        async void TaskTappedAsync(object sender, ItemTappedEventArgs args)
        {
            TaskModel task = (TaskModel)args.Item;

            /*
            //  switch statment to launch the correct view for the respective TaskModel variant
            switch (task.Type)
            {
                case "Duration":
                    DurationTaskView.StaticDurationTask = (DurationTaskModel)task;
                    await Navigation.PushAsync(new DurationTaskView());
                    break;

                case "Frequency":
                    FrequencyTaskView.StaticFrequencyTask = (FrequencyTaskModel)task;
                    await Navigation.PushAsync(new FrequencyTaskView());
                    break;

                case "Opportunity":
                    OpportunityTaskView.StaticOpportunityTask = (OpportunityTaskModel)task;
                    await Navigation.PushAsync(new OpportunityTaskView());
                    break;

                case "PassFail":
                    PassFailTaskView.StaticPassFailTask = (PassFailTaskModel)task;
                    await Navigation.PushAsync(new PassFailTaskView());
                    break;
            }
            */

            OnPropertyChanged();
        }
    }
}
