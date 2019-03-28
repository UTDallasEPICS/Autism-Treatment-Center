using System;

using Xamarin.Forms;

namespace ATS.Content.PatientContent
{
    public class PatientContent : ContentPage
    {
        public PatientContent()
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

