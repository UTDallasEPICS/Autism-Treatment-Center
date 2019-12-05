using System;
using ATS.Models;
using ATS.Database;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ATS.ViewModels
{
    public class PatientCreatorViewModel : BaseViewModel
    {
        //  Command interfaces
        public ICommand SavePatientCommand { get; private set; }

        //Handle Gender Picker


        //  Fields
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }
        private int _age;
        public int Age
        {
            get { return _age; }
            set { _age = value; OnPropertyChanged(); }
        }

        private string _gender;
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; OnPropertyChanged(); }
        }




        //  Constructor methods
        public PatientCreatorViewModel()
        {
            SavePatientCommand = new Command(async () => await SavePatientAsync());
        }

        //  Methods
        async Task SavePatientAsync()
        {
            PatientModel Patient_To_Add = new PatientModel
            {
                Id = Guid.NewGuid().ToString(),
                Name = Name,
                Age = Age,
                Gender = Gender.ToString()
            };

            //  adds patient to our patient collection
            TeacherViewModel.StaticPatients.Add(Patient_To_Add);

            //  gets our teacher id
            string teacher_id = TeacherViewModel.StaticTeacher.Id;

            //  save our patient model, and update relation table
            DatabaseCommunication DatabaseComm = new DatabaseCommunication();

            await DatabaseComm.saveGenericModelUpdateRelation<PatientModel, TeacherPatientModel, PatientBehaviorModel>(Patient_To_Add, teacher_id);

            //  Clears the input so that user doesn't have to delete characters to add
            //  another patient
            Name = "";
            Age = 0;
            //Gender = "";
        }
    }
}
