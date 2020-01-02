
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ATS.Views
{
	public partial class VADMPage : ContentPage
	{
		public VADMPage()
		{
			InitializeComponent();
			BindingContext = new ViewModels.VADMViewModel();
		}

        //When the View button is clicked, this function will cause the app to move to the TeacherView screen that will display the patients
		private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new TeacherView());


		}
	}
}
