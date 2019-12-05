using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using ATS.Models;
using ATS.Database;
using System.Threading.Tasks;

namespace ATS.ViewModels
{
    public class PatientViewModel : BaseViewModel
    {
        private bool _isbusy = false;
        public bool IsBusy
        {
            get { return _isbusy; }
            set { _isbusy = value; OnPropertyChanged(); }
        }
        //  Patient
        private static PatientModel _patient;
        public static PatientModel StaticPatient
        {
            get { return _patient; }
            set { _patient = value; }
        }
        public PatientModel Patient
        {
            get { return _patient; }
            set { _patient = value; OnPropertyChanged(); }
        }

        //  Behavior
        private static ObservableCollection<BehaviorModel> _Behavior;
        public static ObservableCollection<BehaviorModel> StaticBehavior
        {
            get { return _Behavior; }
            set { _Behavior = value; }
        }
        public ObservableCollection<BehaviorModel> Behavior
        {
            get { return _Behavior; }
            set { _Behavior = value; OnPropertyChanged(); }
        }

        //  Contructor
        public PatientViewModel()
        {
            Behavior = new ObservableCollection<BehaviorModel>();
            Initialize();
        }

        private async Task Initialize()
        {
            IsBusy = true;

            //  Database communication object to interact with our database
            DatabaseCommunication database = new DatabaseCommunication();
            Behavior = await database.getGenericModelBatch<PatientBehaviorModel, BehaviorModel>(Patient.Id);

            IsBusy = false;
        }
    }
}
