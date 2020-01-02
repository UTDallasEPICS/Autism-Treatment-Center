using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATS.Database;
using ATS.Models;
using ATS.ViewModels;
using Amazon.CognitoIdentity;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Xamarin.Forms;
using ATS.Database;
using Amazon;

namespace ATS
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ATS.MainPage());
        }

        protected override void OnStart()
        {
            //Spring2020 Team:  Handle when your app starts
        }

        protected override void OnSleep()
        {
            //Spring2020 Team:  Handle when your app sleeps
        }

        protected override void OnResume()
        {
            //Spring2020 Team:  Handle when your app resumes
        }
    }
}