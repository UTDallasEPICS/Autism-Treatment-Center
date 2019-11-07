using System;
using ATS.Models;
using ATS.ViewModels;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ATS.Views
{
    public partial class PatientView : ContentPage
    {
        public PatientView()
        {
            InitializeComponent();
        }

        async void AddBehaviorClickedAsync(object sender, EventArgs args)
        {
            Console.WriteLine("Clicked!");
            await Navigation.PushAsync(new BehaviorCreatorView());
        }

        async void BehaviorTappedAsync(object sender, ItemTappedEventArgs args)
        {
            BehaviorModel Behavior = (BehaviorModel)args.Item;

            BehaviorViewModel.StaticBehavior = Behavior;

            await Navigation.PushAsync(new BehaviorView());

            OnPropertyChanged();
        }
    }
}
