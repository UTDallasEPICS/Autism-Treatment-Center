using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using ATS.Model;

namespace ATS.Content.AppContent
{
    public class SubcategoryInformation
    {
        public SubcategoryModel Subcategory { get; set; }
        public ObservableCollection<GoalInformation> Goals { get; set; }
    }
}
