using System;
using ATS.Model;
using ATS.Database.DataModel;
using ATS.Database.DataModel.DisplayModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace ATS.Content.PatientContent
{
    public partial class PatientContentPage : ContentPage
    {
        public PatientContentPage(ObservableCollection<PatientDataModel> patients)
        {
            InitializeComponent();

            //  Populates PatientList ListView ObservableCollection with patient objects
            PatientList.ItemsSource = patients;
        }

        void AddClicked(object sender, EventArgs args)
        {
            Console.WriteLine("Clicked!");
            //  pushes the PatientCreator view to the Navigation stack when the Add button is clicked
            Navigation.PushAsync(new PatientCreator());
        }
    }
}
