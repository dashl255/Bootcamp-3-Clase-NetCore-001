namespace Ejercicio_estructurado.Helpers.Vars
{
    public class VarHelper
    {

        public static string VarEncryptPassword = "passwordEncrypt";
        public static string VarEncryptDataSession = "dataSession";

        public static string regExParamString = @"^(?=.{4,12}$)[A-Za-z0-9]+(?: [A-Za-z0-9]+)*$";

        public static string RegExpEmail = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";





        public static string EndpointSmtpSend = "SendSmtp";
    }
}
