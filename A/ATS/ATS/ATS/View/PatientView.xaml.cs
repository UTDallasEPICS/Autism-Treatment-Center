using System;
using ATS.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace ATS.View
{
    public partial class PatientView : ContentPage
    {
        public PatientView(ObservableCollection<PatientModel> patients)
        {
            InitializeComponent();

            //  Populates PatientList ListView ObservableCollection with patient objects
            PatientList.ItemsSource = patients;
        }

        void AddClicked(object sender, EventArgs args)
        {
            Console.WriteLine("Clicked!");
            //  pushes the PatientCreator view to the Navigation stack when the Add button is clicked
            //  Navigation.PushAsync(new PatientCreator());
        }
    }
}
