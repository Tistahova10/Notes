using Notes.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notes.Data
{
    public class PropertyRCR
    {

        readonly SQLiteAsyncConnection databaseP;

        public PropertyRCR(string dbPathP)
        {
            databaseP = new SQLiteAsyncConnection(dbPathP);
            databaseP.CreateTableAsync<PropertyNotes>().Wait();
        }

        public Task<List<PropertyNotes>> GetProperty()
        {
            //Get all notes.
            return databaseP.Table<PropertyNotes>().ToListAsync();
        }

        public Task<PropertyNotes> GetProperty(int id)
        {
            // Get a specific note.
            return databaseP.Table<PropertyNotes>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveProperty(PropertyNotes pnote)
        {
            if (pnote.ID != 0)
            {
                // Update an existing note.
                return databaseP.UpdateAsync(pnote);
            }
            else
            {
                // Save a new note.
                return databaseP.InsertAsync(pnote);
            }
        }

        public Task<int> DeleteProperty(PropertyNotes pnote)
        {
            // Delete a note.
            return databaseP.DeleteAsync(pnote);
        }
    }
}
