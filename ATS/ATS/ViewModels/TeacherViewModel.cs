using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using ATS.Models;
using ATS.Database;

namespace ATS.ViewModels
{
    public class TeacherViewModel : BaseViewModel
    {
        private bool _isbusy = false;
        public bool IsBusy
        {
            get { return _isbusy; }
            set { _isbusy = value; OnPropertyChanged(); }
        }

        private static TeacherModel _teacher;
        public static TeacherModel StaticTeacher 
        { 
            get { return _teacher; }
            set { _teacher = value; }
        }
        public TeacherModel Teacher
        {
            get { return _teacher; }
            set { _teacher = value; OnPropertyChanged(); }
        }

        private static ObservableCollection<PatientModel> _patients;
        public static ObservableCollection<PatientModel> StaticPatients
        {
            get { return _patients; }
            set { _patients = value; }
        }
        public ObservableCollection<PatientModel> Patients
        {
            get { return _patients; }
            set { _patients = value; OnPropertyChanged(); }
        }

        public TeacherViewModel()
        {
            Teacher = new TeacherModel
            {
                Id = "37d39648-7f9d-4a6e-bcf8-64ef59e47bc1",
                Name = "Teacher",
                Age = 22,
                Gender = "Male"
            };

            Patients = new ObservableCollection<PatientModel>();

            Initialize();
        }

        private async Task Initialize()
        {
            IsBusy = true;

            //  Database communication object to interact with our database
            DatabaseCommunication database = new DatabaseCommunication();

            Patients = await database.getGenericModelBatch<TeacherPatientModel, PatientModel>(Teacher.Id);

            IsBusy = false;
        }
    }
}
