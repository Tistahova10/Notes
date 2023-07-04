using Notes.Models;
using System;
using System.Linq;
using Xamarin.Forms;

namespace Notes.Views
{
    public partial class Card : ContentPage
    {
        public Card()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionViewC.ItemsSource = await App.Databasec.GetCardNotes();
        }
        async void COnAddClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(CardPage));
        }

        async void COnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                CardNotes cnote = (CardNotes)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(CardPage)}?{nameof(CardPage.ItemIdC)}={cnote.ID.ToString()}");
            }
        }
    }
}