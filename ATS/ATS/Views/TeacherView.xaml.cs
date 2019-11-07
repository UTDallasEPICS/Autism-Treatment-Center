using System;
using ATS.Models;
using ATS.ViewModels;
using ATS.Views;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace ATS.Views
{
    public partial class TeacherView : ContentPage
    {
        public TeacherView()
        {
            InitializeComponent();
        }

        async void AddPatientClickedAsync(object sender, EventArgs args)
        {
            Console.WriteLine("Add Patient Clicked");
            //  pushes the PatientCreator view to the Navigation stack when the Add button is clicked
            //  Navigation.PushAsync(new PatientCreator());
            await Navigation.PushAsync(new PatientCreatorView());
        }

        async void PatientTappedAsync(object sender, ItemTappedEventArgs args)
        {
            PatientModel patient = (PatientModel)args.Item;

            PatientViewModel.StaticPatient = patient;

            await Navigation.PushAsync(new PatientView());

            OnPropertyChanged();
        }
    }
}
