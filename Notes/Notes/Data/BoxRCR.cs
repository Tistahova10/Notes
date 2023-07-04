using Notes.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notes.Data
{
    public class BoxRCR
    {
        readonly SQLiteAsyncConnection databaseB;

        public BoxRCR(string dabPath)
        {
            databaseB = new SQLiteAsyncConnection(dabPath);
            databaseB.CreateTableAsync<BoxNote>().Wait();
        }

        public Task<List<BoxNote>> GetBoxNotesAsync()
        {
            //Get all notes.
            return databaseB.Table<BoxNote>().ToListAsync();
        }

        public Task<BoxNote> GetBoxNotes(int id)
        {
            // Get a specific note.
            return databaseB.Table<BoxNote>()
                            .Where(i => i.ID == id)
                            .FirstAsync();
        }
        public Task<int> SaveBoxNote(BoxNote bnote)
        {
            if (bnote.ID != 0)
            {
                // Update an existing note.
                return databaseB.UpdateAsync(bnote);
            }
            else
            {
                // Save a new note.
                return databaseB.InsertAsync(bnote);
            }
        }
        public Task<int> DeleteBox(BoxNote bnote)
        {
            return databaseB.DeleteAsync(bnote);
        }
    }
}