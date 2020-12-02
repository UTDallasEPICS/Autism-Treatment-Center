using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ATS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentPage : ContentPage
    {
        public StudentPage()
        {
            InitializeComponent();
        }

        //below is code that will navigate users to other pages depending on selections they make
        async void StudentSearchClickedAsync(object sender, EventArgs e)
        {           

            //await Navigation.PushAsync(new ()); 
        }

        async void StudentNewClickedAsync(object sender, EventArgs e)
        {

            //await Navigation.PushAsync(new ()); 
        }
    }
}