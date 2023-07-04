using SQLite;

namespace Notes.Models
{
    public class CardNotes
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Symbol_id { get; set; }
    }
}
