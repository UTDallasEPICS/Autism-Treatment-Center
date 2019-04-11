using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using ATS.Model;

namespace ATS.ViewModel
{
    public class SubcategoryViewModel
    {
        public SubcategoryModel Subcategory { get; set; }
        public ObservableCollection<GoalViewModel> Goals { get; set; }
    }
}
