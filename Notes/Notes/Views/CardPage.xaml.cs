using Notes.Models;
using System;
using Xamarin.Forms;

namespace Notes.Views
{
    [QueryProperty(nameof(ItemIdC), nameof(ItemIdC))]
    public partial class CardPage : ContentPage
    {
        public string ItemIdC
        {
            set
            {
                LoadCNote(value);
            }
        }
        public CardPage()
        {
            InitializeComponent();
            BindingContext = new CardNotes();
        }

        async void LoadCNote(string itemIdC)
        {
            try
            {
                int id = Convert.ToInt32(itemIdC);
                // Retrieve the note and set it as the BindingContext of the page.
                CardNotes cnote = await App.Databasec.GetCardNotes(id);
                BindingContext = cnote;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load note.");
            }
        }

        public async void OnSaveBtnClickedC(object sender, EventArgs e)
        {
            var cnote = (CardNotes)BindingContext;
            if (!string.IsNullOrWhiteSpace(cnote.Name))
            {
                await App.Databasec.SaveCard(cnote);
            }

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }

        async void OnDeleteBtnClickedC(object sender, EventArgs e)
        {
            var cnote = (CardNotes)BindingContext;
            await App.Databasec.DeleteCard(cnote);

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }
    }
}