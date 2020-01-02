using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ATS.Views
{
    public partial class VADMPageTeacher : ContentPage
    {
        public VADMPageTeacher()
        {
            InitializeComponent();
            BindingContext = new ViewModels.VADMViewModel();
        }

        //When View Button is clicked, leads to the screen where the therapists can be viewed
        private async void TapGestureRecognizer_Tapped1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewButtonTeacher());


        }

        //When View Button is clicked, leads to the screen where the therapists can be added
        private async void TapGestureRecognizer_Tapped2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddButtonTeacher());


        }
    }
}
