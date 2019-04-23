using System;
using ATS.Models;
using ATS.ViewModels;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ATS.Views
{
    public partial class DomainView : ContentPage
    {
        public DomainView()
        {
            InitializeComponent();
        }

        async void AddSubcategoryClickedAsync(object sender, EventArgs args)
        {
            Console.WriteLine("Add subcat Clicked");
            //  pushes the PatientCreator view to the Navigation stack when the Add button is clicked
            //  Navigation.PushAsync(new PatientCreator());
            await Navigation.PushAsync(new SubcategoryCreatorView());
        }

        async void SubcategoryTappedAsync(object sender, ItemTappedEventArgs args)
        {
            SubcategoryModel subcategory = (SubcategoryModel)args.Item;

            SubcategoryViewModel.StaticSubcategory = subcategory;

            await Navigation.PushAsync(new SubcategoryView());

            OnPropertyChanged();
        }
    }
}
