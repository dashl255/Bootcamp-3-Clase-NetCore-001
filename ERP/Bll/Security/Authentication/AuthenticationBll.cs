using ERP.CoreDB;
using ERP.Helper.Data;
using ERP.Helper.Helper;
using ERP.Helper.Models;
using ERP.Models.Security.Authentication;

namespace ERP.Bll.Security.Authentication
{
    public class AuthenticationBll : IAuthenticationBll
    {
        BaseErpContext _context;

        public AuthenticationBll(BaseErpContext context)
        {
            _context = context;
        }

        public ResponseGeneralModel<LoginResponseModel?> Login(LoginRequestModel requestModel)
        {
           
            Usuario? userFind = _context.Usuarios.FirstOrDefault(user => user.Email == requestModel.email);

            if (userFind == null)
            {
                return new ResponseGeneralModel<LoginResponseModel?>(404, null, MessageHelper.loginIncorrect);
            }

            bool passwordMatch = MethodsHelper<bool>.VerifyPassword(requestModel.password, userFind.Clave);

            if (!passwordMatch)
            {
                return new ResponseGeneralModel<LoginResponseModel?>(404, null, MessageHelper.loginIncorrect);
            }

      
            Empresa companyFind = _context.Empresas.First(item => item.EmpresaId == userFind.EmpresaId);

            LoginResponseModel loginModel = new LoginResponseModel
            {
                id = userFind.UsuId,
                name = userFind.UsuNombre,
                companyName = companyFind.EmpresaNombre
            };

            SessionModel sessionModel = new SessionModel(userFind.UsuId, userFind.UsuNombre);
            ResponseGeneralModel<LoginResponseModel?> jwt = (new MethodsHelper<LoginResponseModel?>()).GenerateJwtSession(sessionModel);

            if (jwt.code != 200) return jwt;

            loginModel.jwt = jwt.message;

            return new ResponseGeneralModel<LoginResponseModel?>(200, loginModel, "");
        }

        public ResponseGeneralModel<bool> Register(RegisterRequestModel requestModel)
        {
            // ... (Your register logic is fine as it uses EncryptPassUser) ...
            Usuario? usuarioExist = _context.Usuarios.FirstOrDefault(item => item.Email == requestModel.email);
            if (usuarioExist != null)
            {
                return new ResponseGeneralModel<bool>(400, false, MessageHelper.registerErrorExist);
            }

            Usuario? lastUser = _context.Usuarios.OrderByDescending(item => item.UsuId).FirstOrDefault();
            ResponseGeneralModel<string> encryptedPassword = MethodsHelper<string>.EncryptPassUser(requestModel.password);
            if (encryptedPassword.code != 200) return new ResponseGeneralModel<bool>(encryptedPassword.code, false, encryptedPassword.message, encryptedPassword.messageDev);

            Usuario userModel = new Usuario
            {
                UsuId = lastUser != null ? (lastUser.UsuId + 1) : 1,
                UsuNombre = requestModel.name,
                Email = requestModel.email,
                Clave = encryptedPassword.message,
                EmpresaId = requestModel.companyId,
                Estado = 1,
            };

            _context.Usuarios.Add(userModel);
            _context.SaveChanges();

            return new ResponseGeneralModel<bool>(200, true, "");
        }

        public ResponseGeneralModel<bool> ChangePassword(int userId, string currentPassword, string newPassword, string confirmPassword)
        {
            // ... (Validation from controller) ...
            // PRUEBA DE DIAGNÓSTICO TEMPORAL
            string passwordOriginal = "prueba123";
            // 1. Encriptar la contraseña de prueba
            ResponseGeneralModel<string> encrypted = MethodsHelper<string>.EncryptPassUser(passwordOriginal);

            // 2. Desencriptar el resultado de la encriptación inmediatamente
            ResponseGeneralModel<string> decrypted = MethodsHelper<string>.DesencryptPassUser(encrypted.message);

            // 3. Comprobar si el resultado desencriptado coincide con el original
            if (decrypted.message != passwordOriginal)
            {
                // Si esta condición es verdadera, significa que tus métodos Encrypt/Desencrypt no funcionan
                // Y el problema está en tu clase AES256Encryption o en la configuración de la clave/IV
                return new ResponseGeneralModel<bool>(500, false, "ERROR DE DIAGNÓSTICO: La encriptación/desencriptación es inconsistente.");
            }
            // FIN DE LA PRUEBA DE DIAGNÓSTICO TEMPORAL

            var user = _context.Usuarios.FirstOrDefault(u => u.UsuId == userId);
            if (user == null)
            {
                return new ResponseGeneralModel<bool>(404, false, "El usuario no existe.");
            }

            // Verify the current password using decryption
            bool isCurrentPasswordCorrect = MethodsHelper<bool>.VerifyPassword(currentPassword, user.Clave);

            if (!isCurrentPasswordCorrect)
            {
                return new ResponseGeneralModel<bool>(404, false, "La contraseña actual es incorrecta.");
            }

            // Encrypt the new password
            ResponseGeneralModel<string> encryptedNew = MethodsHelper<string>.EncryptPassUser(newPassword);
            if (encryptedNew.code != 200)
                return new ResponseGeneralModel<bool>(400, false, "Error al encriptar la nueva contraseña.");

            user.Clave = encryptedNew.message;
            _context.SaveChanges();

            return new ResponseGeneralModel<bool>(200, true, "Contraseña actualizada correctamente.");
        }

        public bool ChangeUsername(int userId, string newUsername)
        {
            throw new NotImplementedException();
        }
    }
}