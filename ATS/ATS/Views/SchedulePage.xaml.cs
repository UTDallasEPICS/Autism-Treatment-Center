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
    public partial class SchedulePage : ContentPage
    {
        public SchedulePage()
        {
            InitializeComponent();
        }

        //below is the code that will navigate user to other pages depending on selections they make
        async void StudentSearchClickedAsync(object sender, EventArgs e)
        {

            //await Navigation.PushAsync(new ()); //change this to appropriate code
        }

        async void NewSessionClickedAsync(object sender, EventArgs e)
        {

            //await Navigation.PushAsync(new ()); //change this to appropriate code
        }

        async void MenuClickedAsync(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new MenuPage()); //when menu button is clicked, navigate to menu page
        }
    }
}