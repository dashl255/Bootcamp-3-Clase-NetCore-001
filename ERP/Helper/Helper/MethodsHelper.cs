using ERP.Helper.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ERP.Helper.Helper
{
    public class MethodsHelper<T>
    {
        public IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }

        public DataEncryptModel GetDataEncrypt(string key)
        {
            IConfiguration configuration = GetConfiguration();
            IConfigurationSection section = configuration.GetSection("encryptData").GetSection(key);
            return new DataEncryptModel(section.GetValue<string>("key"), section.GetValue<string>("iv"));
        }

        public ResponseGeneralModel<T> EncryptDataByMethod(string method, string text)
        {
            DataEncryptModel modelEncrypt = GetDataEncrypt(method);
            return AES256Encryption<T>.Encrypt(text, modelEncrypt.key, modelEncrypt.iv);
        }

        public ResponseGeneralModel<T> DesencryptDataByMethod(string method, string text)
        {
            DataEncryptModel modelEncrypt = GetDataEncrypt(method);
            return AES256Encryption<T>.Decrypt(text, modelEncrypt.key, modelEncrypt.iv);
        }

        public static ResponseGeneralModel<T> EncryptPassUser(string text)
        {
            return (new MethodsHelper<T>()).EncryptDataByMethod("passUser", text);
        }

        public static ResponseGeneralModel<T> DesencryptPassUser(string text)
        {
            return (new MethodsHelper<T>()).DesencryptDataByMethod("passUser", text);
        }

        public ResponseGeneralModel<T> GenerateJwtSession(SessionModel model)
        {
            IConfigurationSection section = GetConfiguration().GetSection("jwtSession");

            JwtGenerator<T> JWTG = new JwtGenerator<T>(
                SecretKey: section.GetValue<string>("secretKey"),
                Name: section.GetValue<string>("name"),
                Rol: section.GetValue<string>("rol"),
                Issuer: section.GetValue<string>("issuer"),
                Audience: section.GetValue<string>("audience"),
                DurationSec: section.GetValue<int>("durationSec")
            );

            string dataJwt = JsonConvert.SerializeObject(model);

            return JWTG.GenerateJwt(dataJwt);
        }

        public ResponseGeneralModel<T> DecodeJwtSession(string token)
        {
            IConfigurationSection section = GetConfiguration().GetSection("jwtSession");

            JwtGenerator<T> JWTG = new JwtGenerator<T>(
                SecretKey: section.GetValue<string>("secretKey"),
                Name: section.GetValue<string>("name"),
                Rol: section.GetValue<string>("rol"),
                Issuer: section.GetValue<string>("issuer"),
                Audience: section.GetValue<string>("audience"),
                DurationSec: section.GetValue<int>("durationSec")
            );

            return JWTG.DeserializeJwt(token);
        }
    }
}
