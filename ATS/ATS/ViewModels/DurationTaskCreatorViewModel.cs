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
    public class DurationTaskCreatorViewModel : BaseViewModel
    {
        public ICommand SaveDurationCommand { get; private set; }
        //  Fields
        private string _behaviorID;
        public string BehaviorID
        {
            get { return _behaviorID; }
            set { _behaviorID = value; }
        }
        private string _time;
        public string Time
        {
            get { return _time; }
            set { _time = value; }
        }


        public DurationTaskCreatorViewModel()
        {

            SaveDurationCommand = new Command(async () => await SaveDurationTaskAsync());
        }

        async Task SaveDurationTaskAsync()
        {
            DurationTaskModel DurationTask_To_Add = new DurationTaskModel
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Occurence of Behavior", //Needs to be fixed with Occurence 1, Occurence 2, Occurence 3, etc.
                Time = Time
            };

            DatabaseCommunication DatabaseComm = new DatabaseCommunication();

            //Currently this is being manually seeded, however this needs to be fixed
            await DatabaseComm.saveGenericModelUpdateRelationFinalTable<DurationTaskModel, BehaviorDurationTaskModel>(DurationTask_To_Add, "5ae6bf42-0c11-468a-8176-e248850fd918");

            //  Clears the input so that user doesn't have to delete characters to add
            //  another occurence of behavior
            Time = "";
        }
    }
}