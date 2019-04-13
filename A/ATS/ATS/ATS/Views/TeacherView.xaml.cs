using System;
using ATS.Models;
using ATS.ViewModels;
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

        void AddClicked(object sender, EventArgs args)
        {
            Console.WriteLine("Clicked!");
            //  pushes the PatientCreator view to the Navigation stack when the Add button is clicked
            //  Navigation.PushAsync(new PatientCreator());
        }
    }
}
