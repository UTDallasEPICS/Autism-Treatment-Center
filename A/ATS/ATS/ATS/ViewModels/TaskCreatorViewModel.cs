using System;
using ATS.Models;
using ATS.Database;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace ATS.ViewModels
{
    public class TaskCreatorViewModel : BaseViewModel
    {
        //  Command interfaces
        public ICommand SaveTaskCommand { get; private set; }

        //  Fields
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }
        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged(); }
        }

        //  Constructor
        public TaskCreatorViewModel()
        {
            SaveTaskCommand = new Command(async () => await SaveTaskAsync());
        }

        //  Methods
        //  Saving Goal to database
        async Task SaveTaskAsync()
        {
            TaskModel Task_To_Add = new TaskModel
            {
                Id = Guid.NewGuid().ToString(),
                Name = Name,
                Description = Description
            };

            //  adds patient to our patient collection
            GoalViewModel.StaticTasks.Add(Task_To_Add);

            //  gets our subcategory id
            string goal_id = GoalViewModel.StaticGoal.Id;

            //  creates new data base object to save our patient
            DatabaseCommunication DatabaseComm = new DatabaseCommunication();

            await DatabaseComm.saveGenericModelUpdateRelationFinalTable<TaskModel, GoalTaskModel>(Task_To_Add, goal_id);

            //  Clears the input so that user doesn't have to delete characters to add
            //  another patient
            Name = "";
            Description = "";
        }
    }
}
