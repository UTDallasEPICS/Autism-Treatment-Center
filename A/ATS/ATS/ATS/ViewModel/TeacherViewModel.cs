using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using ATS.Model;

namespace ATS.ViewModel
{
    public class TeacherViewModel
    {
        public TeacherModel Teacher { get; set; }
        public ObservableCollection<PatientViewModel> Patients { get; set; }
    }
}
