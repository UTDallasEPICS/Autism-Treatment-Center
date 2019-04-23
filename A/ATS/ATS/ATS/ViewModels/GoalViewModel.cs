using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using ATS.Models;
using ATS.Database;
using System.Threading.Tasks;

namespace ATS.ViewModels
{
    public class GoalViewModel : BaseViewModel
    {
        //  Goal
        private static GoalModel _goal;
        public static GoalModel StaticGoal
        {
            get { return _goal; }
            set { _goal = value; }
        }
        public GoalModel Goal
        {
            get { return _goal; }
            set { _goal = value; OnPropertyChanged(); }
        }

        //  Tasks
        private static ObservableCollection<TaskModel> _tasks;
        public static ObservableCollection<TaskModel> StaticTasks
        {
            get { return _tasks; }
            set { _tasks = value; }
        }
        public ObservableCollection<TaskModel> Tasks
        {
            get { return _tasks; }
            set { _tasks = value; OnPropertyChanged(); }
        }

        //  Constructor and methods
        public GoalViewModel()
        {
            Tasks = new ObservableCollection<TaskModel>();

            Initialize();
        }

        private async Task Initialize()
        {
            //  Database communication object to interact with our database
            DatabaseCommunication database = new DatabaseCommunication();

            Tasks = await database.getGenericModelBatch<GoalTaskModel, TaskModel>(Goal.Id);
        }
    }
}
