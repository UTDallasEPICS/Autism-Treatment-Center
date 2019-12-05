using System;
using System.Net;
using System.Threading.Tasks;
using Amazon.Runtime;
using ATS.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using ATS.Database;
using ATS.Models;
using ATSApp.CustomUI;


namespace ATS
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
            BtnLogin.Clicked += async (source, args) =>
            {
                await BtnLoginClickListener();
            };
            
        }

        private async Task BtnLoginClickListener()
        {
            try
            {
                //var user = getUserFromEntry();
                string username = EntryUsername.Text.Trim();
                if (String.IsNullOrEmpty(username))
                    throw new Exception("Please enter username");

                DatabaseCommunication query = new DatabaseCommunication();
                var user = await query.getGenericModel<Login>(username);

                if (checkPasswordforUser(user) == false)
                    throw new Exception("Login failed");
                else
                {
                    Navigation.PushAsync(new TeacherView());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
       
        private bool checkPasswordforUser(Login login)
        {
            string password = EntryPassword.Text.Trim();
            if (String.IsNullOrEmpty(password))
            {
                throw new Exception("Please enter password");
                return false;
            }
            if (!password.Equals(login.Password))
            {
                throw new Exception("Password was not correct");
                return false;
            }
            return true;
        }

    }
}
