using Notes.Data;
using System;
using System.IO;
using Xamarin.Forms;

namespace Notes
{
    public partial class App : Application
    {
        static NoteDatabase database;
        public static NoteDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new NoteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                }
                return database;
            }
        }

        static BoxRCR databaseB;

        public static BoxRCR Databaseb
        {
            get
            {
                if (databaseB == null)
                {
                    databaseB = new BoxRCR(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BoxNotes.db3"));
                }
                return databaseB;
            }
        }

        static SymbolRCR databaseS;

        public static SymbolRCR Databases
        {
            get
            {
                if (databaseS == null)
                {
                    databaseS = new SymbolRCR(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SumbolNotes.db3"));
                }
                return databaseS;
            }
        }

        static CardRCR databaseC;

        public static CardRCR Databasec
        {
            get
            {
                if (databaseC == null)
                {
                    databaseC = new CardRCR(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CardNotes.db3"));
                }
                return databaseC;
            }
        }
        static PropertyRCR databaseP;

        public static PropertyRCR Databasep
        {
            get
            {
                if (databaseP == null)
                {
                    databaseP = new PropertyRCR(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PropertyNotes.db3"));
                }
                return databaseP;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}