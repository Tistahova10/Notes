using Notes.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notes.Data
{
    public class CardRCR
    {

        readonly SQLiteAsyncConnection databaseC;

        public CardRCR(string dbPathC)
        {
            databaseC = new SQLiteAsyncConnection(dbPathC);
            databaseC.CreateTableAsync<CardNotes>().Wait();
        }

        public Task<List<CardNotes>> GetCardNotes()
        {
            //Get all notes.
            return databaseC.Table<CardNotes>().ToListAsync();
        }

        public Task<CardNotes> GetCardNotes(int id)
        {
            // Get a specific note.
            return databaseC.Table<CardNotes>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveCard(CardNotes cnote)
        {
            if (cnote.ID != 0)
            {
                // Update an existing note.
                return databaseC.UpdateAsync(cnote);
            }
            else
            {
                // Save a new note.
                return databaseC.InsertAsync(cnote);
            }
        }

        public Task<int> DeleteCard(CardNotes cnote)
        {
            // Delete a note.
            return databaseC.DeleteAsync(cnote);
        }
    }
}
