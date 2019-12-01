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
    public class BehaviorCreatorViewModel : BaseViewModel
    {
        //  Command interfaces
        public ICommand SaveBehaviorCommand { get; private set; }

        //  Fields
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }
        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged(); }
        }

        //Stores and displays Task Types

        private ObservableCollection<string> _tasktypes;

        public ObservableCollection<string> TaskTypes
        {
            get { return _tasktypes; }
            set { _tasktypes = value; OnPropertyChanged(); }
        }

        //Get the task that is chosen
        private string _type;
        public string Type
        {
            get { return _type; }
            set { _type = value; OnPropertyChanged(); }
        }


        public BehaviorCreatorViewModel()
        {
            string[] TaskNames = { "Duration", "Frequency", "PassFail" };
            TaskTypes = new ObservableCollection<string>(TaskNames);

            SaveBehaviorCommand = new Command(async() => await SaveBehaviorAsync());
        }

        async Task SaveBehaviorAsync()
        {
            BehaviorModel Behavior_To_Add = new BehaviorModel
            {
                Id = Guid.NewGuid().ToString(),
                Name = Name,
                Active = true,
                Description = Description,
                Task = Type
        };

            //  adds patient to our patient collection
            PatientViewModel.StaticBehavior.Add(Behavior_To_Add);

            //  gets our teacher id
            string patient_id = PatientViewModel.StaticPatient.Id;

            //  creates new data base object to save our patient
            DatabaseCommunication DatabaseComm = new DatabaseCommunication();
            await DatabaseComm.saveGenericModelUpdateRelationFinalTable<BehaviorModel, PatientBehaviorModel>(Behavior_To_Add, patient_id);

            //  Clears the input so that user doesn't have to delete characters to add
            //  another patient
            Name = "";
            Description = "";
        }
    }
}