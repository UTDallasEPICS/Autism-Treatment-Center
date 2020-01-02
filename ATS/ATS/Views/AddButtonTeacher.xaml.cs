using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ATS.Views
{
	public partial class AddButtonTeacher : ContentPage
	{
		public AddButtonTeacher()
		{
			InitializeComponent();
		}

		private void Button_onClicked(object sender, EventArgs e)
		{
			DisplayAlert("Success!", "Therapist has been added", "OK");


		}

	}
}
