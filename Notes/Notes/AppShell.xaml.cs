using Notes.Views;
using Xamarin.Forms;

namespace Notes
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NoteEntryPage), typeof(NoteEntryPage));
            Routing.RegisterRoute(nameof(BoxPage), typeof(BoxPage));
            Routing.RegisterRoute(nameof(SymbolPage), typeof(SymbolPage));
            Routing.RegisterRoute(nameof(CardPage), typeof(CardPage));
            Routing.RegisterRoute(nameof(PropertyTypePage), typeof(PropertyTypePage));
        }

    }
}