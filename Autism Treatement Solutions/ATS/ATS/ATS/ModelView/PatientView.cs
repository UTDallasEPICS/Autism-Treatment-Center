using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ATS.Model;
using ATS.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ATS.ModelView
{
    // [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PatientView : ContentPage
    {

        public PatientView()
        {
            InitializeComponent();
            patientList.ItemSelected += PatientOnSelection;
            patientList.ItemsSource = PatientManager.Instance.GetPatients();
        }

        void PatientOnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            Patient currentPatient = (Patient)e.SelectedItem;
            if (currentPatient != null)
                PatientClicked(currentPatient);
            (sender as ListView).SelectedItem = null;
        }

        void PatientClicked(Patient p)
        {
            Navigation.PushAsync(p.DGroup);
        }

        void AddClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new PatientCreator());
        }



    }
}