using System;
using ATS.Model;
using ATS.Database;
using ATS.View;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace ATS
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //  make sure that if you press the button multiple times that the function won't repeatedly be called
        private async void Button_Clicked(object sender, EventArgs e)
        {
            //  Database communication object to interact with our database
            DatabaseCommunication database = new DatabaseCommunication();

            ObservableCollection<PatientModel> patients = await database.getGenericModelBatch<TeacherPatientModel, PatientModel>(2);

            //  Need to collect user login information her

            await Navigation.PushAsync(new PatientView(patients)); //PatientView
        }
    }
}





/**
 * 
 PatientDataModel pat = await database.getPatient(1);

    await database.saveGenericDataModel<PatientDataModel>(new PatientDataModel {
                                                                Id = 2,
                                                                Name = "Guy2",
                                                                Age = 15,
                                                                Gender = "Male",
                                                                Active = true,
                                                                DateCreated = new DateTime().Date.ToString("yyyy-MM-dd")
                                                        });

            await database.saveGenericDataModel<TeacherDataModel>( new TeacherDataModel {
                                       Id = 1,
                                       Name = "Teacher",
                                       Age = 12,
                                       Gender = "Male",
                                       Active = true,
                                       DateCreated = new DateTime().Date.ToString("yyyy-MM-dd")
                                    });

            List<int> patIds = new List<int>();

            patIds.Add(2);

            await database.saveGenericDataModel<TeacherPatient>( new TeacherPatient {
                                       Id = 2,
                                       DateCreated = new DateTime().Date.ToString("yyyy-MM-dd"),
                                       Ids = patIds
                                    });    
            
 */
