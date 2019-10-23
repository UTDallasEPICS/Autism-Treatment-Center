using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using ATS.Models;
using ATS.Database;

namespace ATS.ViewModels
{
    public class SubcategoryViewModel : BaseViewModel
    {
        private bool _isbusy = false;
        public bool IsBusy
        {
            get { return _isbusy; }
            set { _isbusy = value; OnPropertyChanged(); }
        }

        public static SubcategoryModel _subcategory;
        public static SubcategoryModel StaticSubcategory
        {
            get { return _subcategory; }
            set { _subcategory = value; }
        }
        public SubcategoryModel Subcategory
        {
            get { return _subcategory; }
            set { _subcategory = value; OnPropertyChanged(); }
        }

        public static ObservableCollection<GoalModel> _goals;
        public static ObservableCollection<GoalModel> StaticGoals
        {
            get { return _goals; }
            set { _goals = value; }
        }
        public ObservableCollection<GoalModel> Goals
        {
            get { return _goals; }
            set { _goals = value; OnPropertyChanged(); }
        }

        public SubcategoryViewModel()
        {
            Goals = new ObservableCollection<GoalModel>();

            Initialize();
        }

        private async Task Initialize()
        {
            //  Database communication object to interact with our database
            DatabaseCommunication database = new DatabaseCommunication();

            Goals = await database.getGenericModelBatch<SubcategoryGoalModel, GoalModel>(Subcategory.Id);
        }
    }
}
