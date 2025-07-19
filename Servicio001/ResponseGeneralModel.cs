namespace Servicio001
{
    public class ResponseGeneralModel<T>
    {
        public int status { get; set; }
        public T data { get; set; }
        public string message { get; set; }

        public ResponseGeneralModel(int status, T data, string message)
        {
            this.status = status;
            this.data = data;
            this.message = message;
        }
    }
}
