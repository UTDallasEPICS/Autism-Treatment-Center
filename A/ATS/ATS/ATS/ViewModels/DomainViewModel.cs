using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using ATS.Models;

namespace ATS.ViewModels
{
    public class DomainViewModel : BaseViewModel
    {
        public DomainModel _domain;
        public DomainModel Domain { get; set; }

        public SubcategoryModel _subcategories;
        public ObservableCollection<SubcategoryModel> Subcategories { get; set; }
    }
}
