using System;
using ATS.Views;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using ATS.Database;
using ATS.Models;

namespace ATS
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //  make sure that if you press the button multiple times that the function won't repeatedly be called
        async void SignInClickedAsync(object sender, EventArgs e)
        {
            //  Need to collect user login information her

            Navigation.PushAsync(new TeacherView()); //PatientView
        }
    }
}
