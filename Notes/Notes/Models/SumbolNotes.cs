using SQLite;

namespace Notes.Models
{
    public class SumbolNotes
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Symbol { get; set; }
        public string Descriprion { get; set; }
        public string Unit { get; set; }
        public string Pow10 { get; set; }

    }
}
