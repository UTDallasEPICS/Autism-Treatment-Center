using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using ATS.Models;
using ATS.Database;

namespace ATS.ViewModels
{
    public class BehaviorViewModel : BaseViewModel
    {
        private bool _isbusy = false;
        public bool IsBusy
        {
            get { return _isbusy; }
            set { _isbusy = value; OnPropertyChanged(); }
        }

        //  Behavior
        private static BehaviorModel _Behavior;
        public static BehaviorModel StaticBehavior
        {
            get { return _Behavior; }
            set { _Behavior = value; }
        }
        public BehaviorModel Behavior
        {
            get { return _Behavior; }
            set { _Behavior = value; OnPropertyChanged(); }
        }

        public BehaviorViewModel()
        {
           //Tasks = new ObservableCollection<TaskModel>();


            Initialize();
        }

        private async Task Initialize()
        {
            IsBusy = true;

            //  Database communication object to interact with our database
            DatabaseCommunication database = new DatabaseCommunication();
            
            if(Behavior.Task == "Duration")
            {
                await database.getGenericModelBatch<BehaviorDurationTaskModel, DurationTaskModel>(Behavior.Id);
            }
            if (Behavior.Task == "Frequency")
            {
                await database.getGenericModelBatch<BehaviorFrequencyTaskModel, FrequencyTaskModel>(Behavior.Id);
            }
            if (Behavior.Task == "PassFail")
            {
                await database.getGenericModelBatch<BehaviorPassFailTaskModel, PassFailTaskModel>(Behavior.Id);
            }


            //Tasks = await database.getGenericModelBatch<BehaviorSubcategoryModel, SubcategoryModel>(Behavior.Id);

            IsBusy = false;
        }
    }
}