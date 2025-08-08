namespace ERP.Helper.Models
{
    public class DataEncryptModel
    {
        public string key {  get; set; }
        public string iv { get; set; }

        public DataEncryptModel(string key, string iv)
        {
            this.key = key;
            this.iv = iv;
        }
    }
}
