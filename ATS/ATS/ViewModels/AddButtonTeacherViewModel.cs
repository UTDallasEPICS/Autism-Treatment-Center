/******************************************************************
* The AddButtonTeacher page adds a new therapist to the database
*
* The function for adding therapists should be tested and modified
* if needed by the Spring 2020 team
*********************************************************************/
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ATS.Database;
using ATS.Models;
using Xamarin.Forms;

namespace ATS.ViewModels
{
    public class AddButtonTeacherViewModel : ContentPage
    {
        //  Command interfaces
        public ICommand SaveTeacherCommand { get; private set; }

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

        public AddButtonTeacherViewModel()
        {
            SaveTeacherCommand = new Command(async () => await SaveTeacherAsync());
        }

        //  Methods
        async Task SaveTeacherAsync()
        {
            TeacherModel Therapist_To_Add = new TeacherModel
            {
                Id = Guid.NewGuid().ToString(),
                Name = Name,
                Age = Age,
                Gender = Gender
            };

            /*
            //  adds patient to our patient collection
            TeacherViewModel.StaticPatients.Add(Therapist_To_Add);*/

            //  save our patient model, and update relation table
            DatabaseCommunication DatabaseComm = new DatabaseCommunication();

            await DatabaseComm.saveGenericModel<TeacherModel>(Therapist_To_Add);
            //  Clears the input so that user doesn't have to delete characters to add
            //  another patient
            Name = "";
            Age = 0;
            Gender = "";
        }
    }
}

