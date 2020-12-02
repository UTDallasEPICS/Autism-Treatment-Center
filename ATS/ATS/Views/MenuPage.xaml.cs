using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Views;
using ATS;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        //the methods below navigate the user to a page depending on their selection
        async void SearchClickedAsync(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new StudentPage()); 
        }

        async void AddNewClickedAsync(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new AddStudentPage()); 
        }

        async void ViewScheduleClickedAsync(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new SchedulePage()); 
        }

        async void LogoutClickedAsync(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new MainPage()); 
        }


    }
}