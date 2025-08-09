using ERP.Helper.Models;
using ERP.Models.Security.Authentication;

namespace ERP.Bll.Security.Authentication
{
    public interface IAuthenticationBll
    {
        public ResponseGeneralModel<LoginResponseModel?> Login(LoginRequestModel requestModel);
        public ResponseGeneralModel<bool> Register(RegisterRequestModel requestModel);
        public ResponseGeneralModel<bool> ChangePassword(int userId, string currentPassword, string newPassword, string confirmPassword);
        bool ChangeUsername(int userId, string newUsername);
    }
}
