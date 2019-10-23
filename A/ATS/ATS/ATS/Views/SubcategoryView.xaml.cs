using System;
using ATS.Models;
using ATS.ViewModels;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ATS.Views
{
    public partial class SubcategoryView : ContentPage
    {
        public SubcategoryView()
        {
            InitializeComponent();
        }

        async void AddGoalClickedAsync(object sender, EventArgs args)
        {
            Console.WriteLine("Add Goal Clicked");
            //  pushes the PatientCreator view to the Navigation stack when the Add button is clicked
            //  Navigation.PushAsync(new PatientCreator());
            await Navigation.PushAsync(new GoalCreatorView());
        }

        async void GoalTappedAsync(object sender, ItemTappedEventArgs args)
        {
            GoalModel goal = (GoalModel)args.Item;

            GoalViewModel.StaticGoal = goal;

            await Navigation.PushAsync(new GoalView());

            OnPropertyChanged();
        }
    }
}
