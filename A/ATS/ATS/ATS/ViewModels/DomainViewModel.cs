using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using ATS.Models;
using ATS.Database;

namespace ATS.ViewModels
{
    public class DomainViewModel : BaseViewModel
    {
        private bool _isbusy = false;
        public bool IsBusy
        {
            get { return _isbusy; }
            set { _isbusy = value; OnPropertyChanged(); }
        }

        //  domain
        private static DomainModel _domain;
        public static DomainModel StaticDomain
        {
            get { return _domain; }
            set { _domain = value; }
        }
        public DomainModel Domain
        {
            get { return _domain; }
            set { _domain = value; OnPropertyChanged(); }
        }

        //  subcategories
        private static ObservableCollection<SubcategoryModel> _subcategories;
        public static ObservableCollection<SubcategoryModel> StaticSubcategories
        {
            get { return _subcategories; }
            set { _subcategories = value; }
        }
        public ObservableCollection<SubcategoryModel> Subcategories
        {
            get { return _subcategories; }
            set { _subcategories = value; OnPropertyChanged(); }
        }

        //  Constructor and Respective functions
        public DomainViewModel()
        {
            Subcategories = new ObservableCollection<SubcategoryModel>();

            Initialize();
        }

        private async Task Initialize()
        {
            IsBusy = true;

            //  Database communication object to interact with our database
            DatabaseCommunication database = new DatabaseCommunication();

            Subcategories = await database.getGenericModelBatch<DomainSubcategoryModel, SubcategoryModel>(Domain.Id);

            IsBusy = false;
        }
    }
}