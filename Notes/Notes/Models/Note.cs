using SQLite;

namespace Notes.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int Id_box { get; set; }
        public int Id_PropertyType { get; set; }
        public int Id_card { get; set; }
        public int Id_symbol { get; set; }
        public int Cabinet_number { get; set; }
        public string Floor { get; set; }
    }
}

