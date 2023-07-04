using SQLite;

namespace Notes.Models
{
    public class BoxNote
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
    }
}
