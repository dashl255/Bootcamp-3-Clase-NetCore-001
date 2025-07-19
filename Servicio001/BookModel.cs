namespace Servicio001
{
    public class BookModel
    {
        public string name { get; set; }
        public string author { get; set; }
        public int year { get; set; }

        public BookModel(string name, string author, int year)
        {
            this.name = name;
            this.author = author;
            this.year = year;
        }
    }
}
