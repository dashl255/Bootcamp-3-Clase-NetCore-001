using ERP.Helper.Models;
using ERP.Models.Security.Profile;

namespace ERP.Bll.Security.Profile
{
    public interface IProfileBll
    {
        public ResponseGeneralModel<ProfileResponseModel> Me();
    }
}
