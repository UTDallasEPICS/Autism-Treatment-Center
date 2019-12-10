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
    public class FrequencyTaskCreatorViewModel : BaseViewModel
    {
        public ICommand SaveFrequencyCommand { get; private set; }
        //  Fields
        private string _behaviorID;
        public string BehaviorID
        {
            get { return _behaviorID; }
            set { _behaviorID = value; }
        }
        private string _frequency;
        public string Frequency
        {
            get { return _frequency; }
            set { _frequency = value; }
        }

        public FrequencyTaskCreatorViewModel()
        {

            SaveFrequencyCommand = new Command(async () => await SaveFrequencyTaskAsync());
        }

        async Task SaveFrequencyTaskAsync()
        {
            FrequencyTaskModel FrequencyTask_To_Add = new FrequencyTaskModel
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Occurence of Behavior", //Needs to be fixed with Occurence 1, Occurence 2, Occurence 3, etc.
                //BehaviorID = BehaviorID,
                Frequency = Frequency
            };

            DatabaseCommunication DatabaseComm = new DatabaseCommunication();

            //Currently this is being manually seeded, however this needs to be fixed
            await DatabaseComm.saveGenericModelUpdateRelationFinalTable<FrequencyTaskModel, BehaviorFrequencyTaskModel>(FrequencyTask_To_Add, "5ae6bf42-0c11-468a-8176-e248850fd918");

            //  Clears the input so that user doesn't have to delete characters to add
            //  another occurence of behavior
            Frequency = "";
        }
    }
}