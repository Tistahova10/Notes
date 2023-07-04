using Notes.Models;
using System;
using Xamarin.Forms;

namespace Notes.Views
{
    [QueryProperty(nameof(ItemIdS), nameof(ItemIdS))]
    public partial class SymbolPage : ContentPage
    {
        public string ItemIdS
        {
            set
            {
                LoadSNote(value);
            }
        }
        public SymbolPage()
        {
            InitializeComponent();

            BindingContext = new SumbolNotes();
        }

        async void LoadSNote(string itemIdS)
        {
            try
            {
                int id = Convert.ToInt32(itemIdS);
                SumbolNotes snote = await App.Databases.GetSumbolNotes(id);
                BindingContext = snote;

            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load note.");
            }
        }

        public async void OnSaveBtnClickedS(object sender, EventArgs e)
        {
            var snote = (SumbolNotes)BindingContext;
            if (!string.IsNullOrWhiteSpace(snote.Symbol)||(!string.IsNullOrWhiteSpace(snote.Descriprion))||(!string.IsNullOrWhiteSpace(snote.Unit))||(!string.IsNullOrWhiteSpace(snote.Pow10)))
            {
                await App.Databases.SaveSymbol(snote);
            }
            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }

        async void OnDeleteBtnClickedS(object sender, EventArgs e)
        {
            var snote = (SumbolNotes)BindingContext;
            await App.Databases.DeleteSymbol(snote);

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }
    }
}