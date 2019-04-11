using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using ATS.Model;

namespace ATS.ViewModel
{
    public class PatientViewModel
    {
        public PatientModel Patient { get; set; }
        public ObservableCollection<DomainViewModel> Domains { get; set; }
    }
}
