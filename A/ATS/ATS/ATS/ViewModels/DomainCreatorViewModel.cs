using System;
using ATS.Models;
using ATS.Database;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace ATS.ViewModels
{
    public class DomainCreatorViewModel : BaseViewModel
    {
        //  Command interfaces
        public ICommand SaveDomainCommand { get; private set; }

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

        public DomainCreatorViewModel()
        {
            SaveDomainCommand = new Command(async() => await SaveDomainAsync());
        }

        async Task SaveDomainAsync()
        {
            DomainModel Domain_To_Add = new DomainModel
            {
                Id = Guid.NewGuid().ToString(),
                Name = Name,
                Description = Description
            };

            //  adds patient to our patient collection
            PatientViewModel.StaticDomains.Add(Domain_To_Add);

            //  gets our teacher id
            string patient_id = PatientViewModel.StaticPatient.Id;

            //  creates new data base object to save our patient
            DatabaseCommunication DatabaseComm = new DatabaseCommunication();
            await DatabaseComm.saveGenericModelUpdateRelation<DomainModel, PatientDomainModel, DomainSubcategoryModel>(Domain_To_Add, patient_id);

            //  Clears the input so that user doesn't have to delete characters to add
            //  another patient
            Name = "";
            Description = "";
        }
    }
}