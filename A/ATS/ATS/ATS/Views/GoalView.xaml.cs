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
            TaskModel subcategory = (TaskModel)args.Item;

            //TaskViewModel.StaticTask = subcategory;

            await Navigation.PushAsync(new TaskView());

            OnPropertyChanged();
        }
    }
}
