using Notes.Models;
using System;
using System.Linq;
using Xamarin.Forms;

namespace Notes.Views
{
    public partial class Box : ContentPage
    {
        public Box()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionViewB.ItemsSource = await App.Databaseb.GetBoxNotesAsync();
        }
        async void BOnAddClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(BoxPage));
        }

        async void BOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                BoxNote bnote = (BoxNote)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(BoxPage)}?{nameof(BoxPage.ItemIdB)}={bnote.ID.ToString()}");
            }
        }
    }
}