namespace ERP.Helper.Models
{
    public class ResponseGeneralModel<T>
    {
        public int code { get; set; }
        public T data { get; set; }
        public string message { get; set; }
        public string messageDev { get; set; }

        public ResponseGeneralModel(int code, string message)
        {
            this.code = code;
            this.message = message;
        }

        public ResponseGeneralModel(int code, string data, string message, string messageDev)
        {
            this.code = code;
            this.message = message;
            bool isDebug = (new ConfigurationBuilder()).AddJsonFile("appsettings.json").Build().GetSection("isDebug").Get<bool>();
            if (isDebug)
            {
                this.messageDev = messageDev;
            }
        }

        public ResponseGeneralModel(int code, T data, string message)
        {
            this.code = code;
            this.data = data;
            this.message = message;
        }
    }
}
