using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using ATS.Models;

namespace ATS.ViewModels
{
    public class DomainViewModel
    {
        public DomainModel Domain { get; set; }
        public ObservableCollection<SubcategoryViewModel> Subcategories { get; set; }
    }
}
