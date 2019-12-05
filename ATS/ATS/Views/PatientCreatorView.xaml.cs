using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ATS.Views
{
    public partial class PatientCreatorView : ContentPage
    {
        public PatientCreatorView()
        {
            InitializeComponent();
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                //gender.Text = picker.Items[selectedIndex];
            }
        }

    }
}
