using Notes.Models;
using System;
using System.Linq;
using Xamarin.Forms;

namespace Notes.Views
{
    public partial class PropertyType : ContentPage
    {
        public PropertyType()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionViewP.ItemsSource = await App.Databasep.GetProperty();
        }
        async void POnAddClicked(object sender, EventArgs e)
        {
            // Navigate to the NoteEntryPage, without passing any data.
            await Shell.Current.GoToAsync(nameof(PropertyTypePage));
        }

        async void POnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                PropertyNotes pnote = (PropertyNotes)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(PropertyTypePage)}?{nameof(PropertyTypePage.ItemIdP)}={pnote.ID.ToString()}");
            }
        }
    }
}