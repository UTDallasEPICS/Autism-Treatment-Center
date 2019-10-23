using System;
using ATS.Models;
using ATS.Database;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace ATS.ViewModels
{
    public class GoalCreatorViewModel : BaseViewModel
    {
        //  Command interfaces
        public ICommand SaveGoalCommand { get; private set; }

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
        public GoalCreatorViewModel()
        {
            SaveGoalCommand = new Command(async () => await SaveGoalAsync());
        }

        //  Methods
        //  Saving Goal to database
        async Task SaveGoalAsync()
        {
            GoalModel Goal_To_Add = new GoalModel
            {
                Id = Guid.NewGuid().ToString(),
                Name = Name,
                Description = Description
            };

            //  adds patient to our patient collection
            SubcategoryViewModel.StaticGoals.Add(Goal_To_Add);

            //  gets our subcategory id
            string subcategory_id = SubcategoryViewModel.StaticSubcategory.Id;

            //  creates new data base object to save our patient
            DatabaseCommunication DatabaseComm = new DatabaseCommunication();

            await DatabaseComm.saveGenericModelUpdateRelation<GoalModel, SubcategoryGoalModel, GoalTaskModel>(Goal_To_Add, subcategory_id);

            //  Clears the input so that user doesn't have to delete characters to add
            //  another patient
            Name = "";
            Description = "";
        }
    }
}
