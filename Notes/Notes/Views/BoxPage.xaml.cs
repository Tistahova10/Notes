using Notes.Models;
using System;
using Xamarin.Forms;

namespace Notes.Views
{
    [QueryProperty(nameof(ItemIdB), nameof(ItemIdB))]
    public partial class BoxPage : ContentPage
    {
        public string ItemIdB
        {
            set
            {
                LoadBNote(value);
            }
        }
        public BoxPage()
        {
            InitializeComponent();
            BindingContext = new BoxNote();
        }

        async void LoadBNote(string itemIdB)
        {
            try
            {
                int id = Convert.ToInt32(itemIdB);
                // Retrieve the note and set it as the BindingContext of the page.
                BoxNote bnote = await App.Databaseb.GetBoxNotes(id);
                BindingContext = bnote;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load note.");
            }
        }

        public async void OnSaveBtnClickedB(object sender, EventArgs e)
        {
            var bnote = (BoxNote)BindingContext;
            if (!string.IsNullOrWhiteSpace(bnote.Number) || (!string.IsNullOrWhiteSpace(bnote.Name)))
            {
                await App.Databaseb.SaveBoxNote(bnote);
            }

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }

        async void OnDeleteBtnClickedB(object sender, EventArgs e)
        {
            var bnote = (BoxNote)BindingContext;
            await App.Databaseb.DeleteBox(bnote);

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }
    }
}