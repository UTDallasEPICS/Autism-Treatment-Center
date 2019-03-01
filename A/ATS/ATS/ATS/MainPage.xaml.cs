using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Model;
using ATS.ModelView;
using ATS.ViewModel;
using Xamarin.Forms;

namespace ATS
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
            InitializeComponent();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PatientView()); //PatientView
        }

    }
}
