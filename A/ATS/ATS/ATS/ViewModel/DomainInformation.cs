using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using ATS.Model;

namespace ATS.Content.AppContent
{
    public class DomainInformation
    {
        public DomainModel Domain { get; set; }
        public ObservableCollection<SubcategoryInformation> Subcategories { get; set; }
    }
}
