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
    public class PassFailTaskCreatorViewModel : BaseViewModel
    {
        public ICommand SavePassFailCommand { get; private set; }
        //  Fields
        private string _behaviorID;
        public string BehaviorID
        {
            get { return _behaviorID; }
            set { _behaviorID = value; }
        }
        private string _opportunities;
        public string Opportunities
        {
            get { return _opportunities; }
            set { _opportunities = value; }
        }
        private string _successes;
        public string Successes
        {
            get { return _successes; }
            set { _successes = value; }
        }


        public PassFailTaskCreatorViewModel()
        {

            SavePassFailCommand = new Command(async () => await SavePassFailTaskAsync());
        }

        async Task SavePassFailTaskAsync()
        {
            PassFailTaskModel PassFailTask_To_Add = new PassFailTaskModel
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Occurence of Behavior", //Needs to be fixed with Occurence 1, Occurence 2, Occurence 3, etc.
                Opportunities = Opportunities,
                Successes = Successes
            };

            DatabaseCommunication DatabaseComm = new DatabaseCommunication();
            
            //Currently this is being manually seeded, however this needs to be fixed
            await DatabaseComm.saveGenericModelUpdateRelationFinalTable<PassFailTaskModel, BehaviorPassFailTaskModel>(PassFailTask_To_Add, "5ae6bf42-0c11-468a-8176-e248850fd918");

            //  Clears the input so that user doesn't have to delete characters to add
            //  another occurence of behavior
            Opportunities = "";
            Successes = "";
        }
    }
}