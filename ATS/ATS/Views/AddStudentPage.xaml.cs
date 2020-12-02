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
    public partial class AddStudentPage : ContentPage
    {
        public AddStudentPage()
        {
            InitializeComponent();
        }

        //the methods below navigate the user to a page depending on their selection
        async void MenuClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuPage());
        }

        async void SubmitClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StudentPage());
        }
    }
}