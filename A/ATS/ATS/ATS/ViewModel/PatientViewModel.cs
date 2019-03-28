using System;
using ATS.Model;
using ATS;
using ATS.ModelView;
using ATS.ViewModel;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ATS.ViewModel
{
    public class PatientViewModel
    {

        public ObservableCollection<Patient0> Patient0;

        public PatientViewModel()
        {
            //Patients = PatientManager.Instance.GetPatients();
        }
    }
}
