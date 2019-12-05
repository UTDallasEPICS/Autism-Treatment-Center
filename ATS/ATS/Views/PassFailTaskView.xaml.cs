using System;
using ATS.Models;
using ATS.ViewModels;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ATS.Views
{
    public partial class PassFailTaskView : ContentPage
    {
        public PassFailTaskView()
        {
            InitializeComponent();
        }

        async void AddOccurenceClickedAsync(object sender, EventArgs args)
        {
            Console.WriteLine("Add subcat Clicked");
            //  pushes the PatientCreator view to the Navigation stack when the Add button is clicked
            //  Navigation.PushAsync(new PatientCreator());
            await Navigation.PushAsync(new PassFailTaskCreatorView());
        }

        async void OccurenceTappedAsync(object sender, ItemTappedEventArgs args)
        {
            OnPropertyChanged();
        }
    }
}
