namespace Ejercicio_estructurado.Helpers.Models
{
    public class ResponseGeneralModel<T>
    {
        public int code {  get; set; }
        public T data { get; set; }
        public string message { get; set; }

        public ResponseGeneralModel(int code, string message)
        {
            this.code = code;
            this.message = message;
        }

        public ResponseGeneralModel(int code, T data, string message)
        {
            this.code = code;
            this.data = data;
            this.message = message;
        }
    }
}
