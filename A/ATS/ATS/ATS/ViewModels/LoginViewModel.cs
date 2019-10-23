using System;
using System.Collections.Generic;
using System.Text;
using ATS.Models;
using ATS.Database;

namespace ATS.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(); }
        }

        private string _password;
        public string Password
        {
            get { return _password;}
            set { _password = value; OnPropertyChanged(); }
        }


    }
}
