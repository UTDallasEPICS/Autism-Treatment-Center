using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using ATS.Models;
using ATS.Database;
namespace ATS.ViewModels
{

    public class DurationTaskViewModel : BaseViewModel
    {
        private bool _isbusy = false;
        public bool IsBusy
        {
            get { return _isbusy; }
            set { _isbusy = value; OnPropertyChanged(); }
        }

        private static ObservableCollection<DurationTaskModel> _occurences;

        private static DurationTaskModel _durationTask;
        public DurationTaskModel DurationTask
        {
            get { return _durationTask; }
            set { _durationTask = value; OnPropertyChanged(); }
        }

        public ObservableCollection<DurationTaskModel> Occurences
    {
        get { return _occurences; }
        set { _occurences = value; }
    }

    public DurationTaskViewModel()
        {
            Occurences = new ObservableCollection<DurationTaskModel>();

            Initialize();
        }

        private async Task Initialize()
        {
            IsBusy = true;

            //  Database communication object to interact with our database
            DatabaseCommunication database = new DatabaseCommunication();

            DurationTask = await database.getGenericModel<DurationTaskModel>(DurationTask.Id);

            Occurences.Add(DurationTask);

            IsBusy = false;
        }
    }

}