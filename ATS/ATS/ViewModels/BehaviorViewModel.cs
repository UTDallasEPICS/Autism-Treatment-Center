using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using ATS.Models;
using ATS.Database;

namespace ATS.ViewModels
{
    public class BehaviorViewModel : BaseViewModel
    {
        private bool _isbusy = false;
        public bool IsBusy
        {
            get { return _isbusy; }
            set { _isbusy = value; OnPropertyChanged(); }
        }

        //  Behavior
        private static BehaviorModel _Behavior;
        public static BehaviorModel StaticBehavior
        {
            get { return _Behavior; }
            set { _Behavior = value; }
        }
        public BehaviorModel Behavior
        {
            get { return _Behavior; }
            set { _Behavior = value; OnPropertyChanged(); }
        }

        //  subcategories
        /*
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
        } */

        //  Constructor and Respective functions
        public BehaviorViewModel()
        {
           //Subcategories = new ObservableCollection<SubcategoryModel>();


            Initialize();
        }

        private async Task Initialize()
        {
            IsBusy = true;

            //  Database communication object to interact with our database
            DatabaseCommunication database = new DatabaseCommunication();



            //Subcategories = await database.getGenericModelBatch<BehaviorSubcategoryModel, SubcategoryModel>(Behavior.Id);

            IsBusy = false;
        }
    }
}