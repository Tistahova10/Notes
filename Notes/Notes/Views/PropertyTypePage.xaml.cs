using Notes.Models;
using System;
using Xamarin.Forms;

namespace Notes.Views
{
    [QueryProperty(nameof(ItemIdP), nameof(ItemIdP))]
    public partial class PropertyTypePage : ContentPage
    {
        public string ItemIdP
        {
            set
            {
                LoadPNote(value);
            }
        }
        public PropertyTypePage()
        {
            InitializeComponent();
            BindingContext = new PropertyNotes();
        }

        async void LoadPNote(string itemIdB)
        {
            try
            {
                int id = Convert.ToInt32(itemIdB);
                // Retrieve the note and set it as the BindingContext of the page.
                PropertyNotes pnote = await App.Databasep.GetProperty(id);
                BindingContext = pnote;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load note.");
            }
        }

        public async void OnSaveBtnClickedP(object sender, EventArgs e)
        {
            var pnote = (PropertyNotes)BindingContext;
            if (!string.IsNullOrWhiteSpace(pnote.Keys))
            {
                await App.Databasep.SaveProperty(pnote);

            }

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }

        async void OnDeleteBtnClickedP(object sender, EventArgs e)
        {
            var pnote = (PropertyNotes)BindingContext;
            await App.Databasep.DeleteProperty(pnote);

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }
    }
}