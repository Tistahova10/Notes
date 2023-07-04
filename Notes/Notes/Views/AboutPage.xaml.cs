using Notes.Models;
using System;
using System.Linq;
using Xamarin.Forms;

namespace Notes.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionViewS.ItemsSource = await App.Databases.GetSumbolNotes();
        }
        async void SOnAddClicked(object sender, EventArgs e)
        {
            // Navigate to the NoteEntryPage, without passing any data.
            await Shell.Current.GoToAsync(nameof(SymbolPage));
        }

        async void SOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                SumbolNotes snote = (SumbolNotes)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(SymbolPage)}?{nameof(SymbolPage.ItemIdS)}={snote.ID.ToString()}");

            }
        }
    }
}