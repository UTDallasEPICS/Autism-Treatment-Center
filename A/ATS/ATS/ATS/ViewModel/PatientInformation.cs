using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using ATS.Model;

namespace ATS.Content.AppContent
{
    public class PatientInformation
    {
        public PatientModel Patient { get; set; }
        public ObservableCollection<DomainInformation> Domains { get; set; }
    }
}
