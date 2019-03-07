using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Model;
using ATS.ModelView;
using ATS.ViewModel;
using ATS.Database;
using Xamarin.Forms;
using Amazon.DynamoDBv2.DataModel;

namespace ATS
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
            InitializeComponent();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            DatabaseCommunication database = new DatabaseCommunication();

            PatientDataModel patient = new PatientDataModel()
            {
                PatientName = "Second Name",
                PatientLocation = "Austin"
            };

            await database.SavePatient(patient);

            await Navigation.PushAsync(new PatientView()); //PatientView
        }

    }
}
