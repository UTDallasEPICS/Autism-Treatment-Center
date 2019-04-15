using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using ATS.Models;

namespace ATS.ViewModels
{
    public class PatientViewModel : BaseViewModel
    {
        private static PatientModel _patient;

        public static PatientModel SetStaticPatient
        {
            set { _patient = value; }
        }

        public PatientModel Patient
        {
            get { return _patient; }
            set { _patient = value; OnPropertyChanged(); }
        }

        private ObservableCollection<DomainModel> _domains;

        public ObservableCollection<DomainModel> Domains
        {
            get { return _domains; }
            set { _domains = value; OnPropertyChanged(); }
        }

        public PatientViewModel()
        {

        }
    }
}
