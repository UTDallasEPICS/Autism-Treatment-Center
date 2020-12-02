using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentPage : ContentPage
    {
        public StudentPage()
        {
            InitializeComponent();
        }

        async void StudentSearchClickedAsync(object sender, EventArgs e)
        {

            //await Navigation.PushAsync(new ()); //this button will display student data from the database according to what the user searches for
        }

        async void StudentNewClickedAsync(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new AddStudentPage()); //navigate to AddStudentPage when button is clicked
        }

        async void MenuClickedAsync(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new MenuPage()); //navigate to MenuPage when menu button is clicked
        }
    }
}