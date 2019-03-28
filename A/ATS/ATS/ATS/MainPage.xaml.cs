using System;
using ATS.Database.DataModel;
using ATS.Database;
using ATS.ModelView;
using Xamarin.Forms;
using ATS.Content.PatientContent;
using System.Collections.ObjectModel;

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
            //  Database communication objector to interact with our database
            DatabaseCommunication database = new DatabaseCommunication();

            await database.getPatients(1);

            ObservableCollection<PatientDataModel> patients = new ObservableCollection<PatientDataModel>{
                new PatientDataModel {
                        PatientId = 123,
                        PatientName = "Patient1",
                        PatientAge = 12,
                        PatientGender = "Male",
                        PatientActive = true
                }
            };

            //  Need to collect user login information here

            await Navigation.PushAsync(new PatientContentPage(patients)); //PatientView
        }

    }
}
