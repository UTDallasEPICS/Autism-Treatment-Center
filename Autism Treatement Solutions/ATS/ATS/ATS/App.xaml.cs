using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATS.ModelView;
using ATS.Model;
using ATS.ViewModel;

using Xamarin.Forms;

namespace ATS
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            MainPage = new NavigationPage (new ATS.MainPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
