using System;
using ATS.Models;
using ATS.Database;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace ATS.ViewModels
{
    public class SubcategoryCreatorViewModel : BaseViewModel
    {
        //  Command interfaces
        public ICommand SaveSubcategoryCommand { get; private set; }

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

        public SubcategoryCreatorViewModel()
        {
            SaveSubcategoryCommand = new Command(async () => await SaveSubcategoryAsync());
        }

        async Task SaveSubcategoryAsync()
        {
            SubcategoryModel Subcategory_To_Add = new SubcategoryModel
            {
                Id = Guid.NewGuid().ToString(),
                Name = Name,
                Description = Description
            };

            //  adds patient to our patient collection
            DomainViewModel.StaticSubcategories.Add(Subcategory_To_Add);

            //  gets our teacher id
            string domain_id = DomainViewModel.StaticDomain.Id;

            //  creates new data base object to save our patient
            DatabaseCommunication DatabaseComm = new DatabaseCommunication();

            await DatabaseComm.saveGenericModelUpdateRelation<SubcategoryModel, DomainSubcategoryModel, SubcategoryGoalModel>(Subcategory_To_Add, domain_id);

            //  Clears the input so that user doesn't have to delete characters to add
            //  another patient
            Name = "";
            Description = "";
        }
    }
}
