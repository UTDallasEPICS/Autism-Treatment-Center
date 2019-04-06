using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using ATS.Model;

namespace ATS.Content.AppContent
{
    public class GoalInformation
    {
        public GoalModel Goal { get; set; }
        public ObservableCollection<TaskInformation> Tasks { get; set; }
    }
}
