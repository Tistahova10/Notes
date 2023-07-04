using Notes.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notes.Data
{
    public class SymbolRCR
    {
        readonly SQLiteAsyncConnection databaseS;

        public SymbolRCR(string dbPathS)
        {
            databaseS = new SQLiteAsyncConnection(dbPathS);
            databaseS.CreateTableAsync<SumbolNotes>().Wait();
        }

        public Task<List<SumbolNotes>> GetSumbolNotes()
        {
            //Get all notes.
            return databaseS.Table<SumbolNotes>().ToListAsync();
        }

        public Task<SumbolNotes> GetSumbolNotes(int id)
        {
            // Get a specific note.
            return databaseS.Table<SumbolNotes>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }
        public Task<int> SaveSymbol(SumbolNotes snote)
        {
            if (snote.ID != 0)
            {
                // Update an existing note.
                return databaseS.UpdateAsync(snote);
            }
            else
            {
                // Save a new note.
                return databaseS.InsertAsync(snote);
            }
        }

        public Task<int> DeleteSymbol(SumbolNotes snote)
        {
            // Delete a note.
            return databaseS.DeleteAsync(snote);
        }
    }
}