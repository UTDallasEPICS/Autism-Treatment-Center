using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using ATS.Model;

namespace ATS.Content.AppContent
{
    public class TeacherInformation
    {
        public TeacherModel Teacher { get; set; }
        public ObservableCollection<PatientInformation> Patients { get; set; }
    }
}
