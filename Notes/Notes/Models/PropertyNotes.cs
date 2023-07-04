using SQLite;


namespace Notes.Models
{
    public class PropertyNotes
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Keys { get; set; }
        public string Descripsion { get; set; }
    }
}
