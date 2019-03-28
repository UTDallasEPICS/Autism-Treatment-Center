using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace ATS.Model
{
    class PatientCreator : ContentPage
    {
        private Entry name;
        private Entry age;
        private Entry gender;
        private ScrollView mainView;

        public PatientCreator()
        {
            mainView = new ScrollView();
            StackLayout intermediate = new StackLayout();
            mainView.Margin = new Thickness(20, 20, 20, 0);

            Label topper = new Label();
            topper.Text = "Patient Creator";
            topper.HorizontalOptions = LayoutOptions.Center;
            topper.HorizontalTextAlignment = TextAlignment.Center;

            StackLayout labelAndEntry = new StackLayout();
            labelAndEntry.Orientation = StackOrientation.Horizontal;

            StackLayout labelLayout = new StackLayout();
            StackLayout entryLayout = new StackLayout();

            //Fall2018 Team: option to add new fields here, and split name into firstname and lastname
            name = new Entry();
            name.WidthRequest = 200;
            name.HorizontalTextAlignment = TextAlignment.Center;
            name.HorizontalOptions = LayoutOptions.CenterAndExpand;
            Label nameLabel = new Label();
            nameLabel.Text = "Name";
            nameLabel.HorizontalOptions = LayoutOptions.Start;
            nameLabel.HeightRequest = 30;
            nameLabel.VerticalTextAlignment = TextAlignment.Center;

            age = new Entry();
            age.Keyboard = Keyboard.Numeric;
            age.WidthRequest = 200;
            age.HorizontalTextAlignment = TextAlignment.Center;
            Label ageLabel = new Label();
            ageLabel.Text = "Age";
            ageLabel.HorizontalOptions = LayoutOptions.Start;
            ageLabel.HeightRequest = 30;
            ageLabel.VerticalTextAlignment = TextAlignment.Center;

            gender = new Entry();
            gender.WidthRequest = 200;
            gender.HorizontalTextAlignment = TextAlignment.Center;
            Label genderLabel = new Label();
            genderLabel.Text = "Gender";
            genderLabel.HorizontalOptions = LayoutOptions.Start;
            genderLabel.HeightRequest = 30;
            genderLabel.VerticalTextAlignment = TextAlignment.Center;

            entryLayout.Children.Add(name);
            entryLayout.Children.Add(age);
            entryLayout.Children.Add(gender);
            labelLayout.Children.Add(nameLabel);
            labelLayout.Children.Add(ageLabel);
            labelLayout.Children.Add(genderLabel);

            labelAndEntry.Children.Add(labelLayout);
            labelAndEntry.Children.Add(entryLayout);

            Button finish = new Button();
            finish.Text = "Finish";
            finish.Clicked += FinishClicked;
            finish.HorizontalOptions = LayoutOptions.Center;

            intermediate.Children.Add(topper);
            intermediate.Children.Add(labelAndEntry);
            intermediate.Children.Add(finish);

            mainView.Content = intermediate;
            Content = mainView;

        }

        private void FinishClicked(object sender, EventArgs args)
        {
            if (name.Text == "" || age.Text == "" || gender.Text == "")
            {
                DisplayAlert("Incomplete Data", "Not all of the data fields were entered, please enter all of the information.", "OK");
                return;
            }
            Patient0 newPatient = new Patient0(name.Text, true);
            newPatient.PatientAge = age.Text;
            newPatient.Gender = gender.Text;
            //PatientManager.Instance.AddPatient(newPatient);
            Navigation.RemovePage(this);

        }
    }
}
