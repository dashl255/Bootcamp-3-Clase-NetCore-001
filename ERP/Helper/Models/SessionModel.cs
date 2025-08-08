namespace ERP.Helper.Models
{
    public class SessionModel
    {
        public int id { get; set; }
        public string name { get; set; }

        public SessionModel(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
