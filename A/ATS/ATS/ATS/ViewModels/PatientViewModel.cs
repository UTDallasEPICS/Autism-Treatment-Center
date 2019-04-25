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

        //  Domains
        private static ObservableCollection<DomainModel> _domains;
        public static ObservableCollection<DomainModel> StaticDomains
        {
            get { return _domains; }
            set { _domains = value; }
        }
        public ObservableCollection<DomainModel> Domains
        {
            get { return _domains; }
            set { _domains = value; OnPropertyChanged(); }
        }

        //  Contructor
        public PatientViewModel()
        {
            Domains = new ObservableCollection<DomainModel>();
            Initialize();
        }

        private async Task Initialize()
        {
            IsBusy = true;

            //  Database communication object to interact with our database
            DatabaseCommunication database = new DatabaseCommunication();
            Domains = await database.getGenericModelBatch<PatientDomainModel, DomainModel>(Patient.Id);

            IsBusy = false;
        }
    }
}
