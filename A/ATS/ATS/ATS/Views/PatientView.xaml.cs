using System;
using ATS.Models;
using ATS.ViewModels;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ATS.Views
{
    public partial class PatientView : ContentPage
    {
        public PatientView()
        {
            InitializeComponent();
        }

        async void AddDomainClickedAsync(object sender, EventArgs args)
        {
            Console.WriteLine("Clicked!");
            await Navigation.PushAsync(new DomainCreatorView());
        }

        async void DomainTappedAsync(object sender, ItemTappedEventArgs args)
        {
            DomainModel domain = (DomainModel)args.Item;

            DomainViewModel.StaticDomain = domain;

            await Navigation.PushAsync(new DomainView());

            OnPropertyChanged();
        }
    }
}
