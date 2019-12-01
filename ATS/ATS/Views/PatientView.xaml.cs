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

            if (Behavior.Task.Equals("Duration"))
            {
                await Navigation.PushAsync(new DurationTaskView());
            }
            if (Behavior.Task.Equals("Frequency"))
            {
                await Navigation.PushAsync(new FrequencyTaskView());
            }
            if (Behavior.Task.Equals("PassFail"))
            {
                await Navigation.PushAsync(new PassFailTaskView());
            }

            //await Navigation.PushAsync(new BehaviorView());

            OnPropertyChanged();
        }
    }
}
