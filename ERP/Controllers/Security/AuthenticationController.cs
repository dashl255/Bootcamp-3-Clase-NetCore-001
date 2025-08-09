using ERP.Bll.Security.Authentication;
using ERP.Helper.Data;
using ERP.Helper.Models;
using ERP.Models.Security.Authentication;
using ERP.Validate.Security;
using Microsoft.AspNetCore.Mvc;
using ERP.Bll.User;
namespace ERP.Controllers.Security
{
    [Route("api/Security/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationBll bll;

        public AuthenticationController(IAuthenticationBll bll)
        {
            this.bll = bll;
        }

        [HttpPost("Login")]
        public ResponseGeneralModel<LoginResponseModel?> Login(LoginRequestModel requestModel)
        {
            try
            {
                return bll.Login(requestModel);
            }
            catch (Exception ex)
            {
                return new ResponseGeneralModel<LoginResponseModel?>(500, null, MessageHelper.errorGeneral, ex.ToString());
            }
        }

        [HttpPost("Register")]
        public ResponseGeneralModel<bool> Register(RegisterRequestModel requestModel)
        {
            try
            {
                ResponseGeneralModel<bool> validate = (new AuthenticationValidate()).Register(requestModel);
                if (validate.code != 200) return validate;

                return bll.Register(requestModel);
            }
            catch (Exception ex)
            {
                return new ResponseGeneralModel<bool>(500, false, MessageHelper.errorGeneral, ex.ToString());
            }
        }

        [HttpPut("ChangePassword")]
        public ResponseGeneralModel<bool> ChangePassword([FromBody] ChangePasswordRequestModel requestModel)
        {
            try
            {
    
                int userId = 1;

                // Aquí puedes agregar la validación de contraseñas si no está en el BLL
                if (requestModel.NewPassword != requestModel.ConfirmPassword)
                {
                    return new ResponseGeneralModel<bool>(400, false, "Las contraseñas no coinciden", null);
                }

                return bll.ChangePassword(userId, requestModel.CurrentPassword, requestModel.NewPassword, requestModel.ConfirmPassword);
            }
            catch (Exception ex)
            {
                return new ResponseGeneralModel<bool>(500, false, MessageHelper.errorGeneral, ex.ToString());
            }

            [HttpPut("ChangeUsername/{userId}")]
           ResponseGeneralModel<bool> ChangeUsername(int userId, [FromBody] ChangeUsernameRequestModel requestModel)
            {
                try
                {
                    // Validación del nombre de usuario en el controlador
                    if (string.IsNullOrWhiteSpace(requestModel.NewUsername))
                    {
                        return new ResponseGeneralModel<bool>(400, false, "El nuevo nombre de usuario no puede estar vacío.", null);
                    }

                    // Llama al BLL para cambiar el nombre de usuario
                    bool result = bll.ChangeUsername(userId, requestModel.NewUsername);

                    if (result)
                    {
                        return new ResponseGeneralModel<bool>(200, true, "Nombre de usuario actualizado correctamente.");
                    }
                    else
                    {
                        return new ResponseGeneralModel<bool>(404, false, "Usuario no encontrado o no se pudo actualizar.");
                    }
                }
                catch (Exception ex)
                {
                    return new ResponseGeneralModel<bool>(500, false, MessageHelper.errorGeneral, ex.ToString());
                }
            }

        }
    }

    // Modelo de solicitud para cambiar la contraseña
    public class ChangePasswordRequestModel
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}