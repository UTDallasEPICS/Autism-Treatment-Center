using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ATS.Views
{
    public partial class UserSelection : ContentPage
    {
        public UserSelection()
        {
            InitializeComponent();
            BindingContext = new ViewModels.UserSelectionViewModel();
        }

        private async void TapGestureRecognizer_Tapped1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VADMPageTeacher());


        }

        private async void TapGestureRecognizer_Tapped2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VADMPage());


        }
    }
}
