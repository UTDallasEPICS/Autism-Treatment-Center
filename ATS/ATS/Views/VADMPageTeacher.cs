using System;

using Xamarin.Forms;

namespace ATS.Views
{
    public class VADMPageTeacher : ContentPage
    {
        public VADMPageTeacher()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

