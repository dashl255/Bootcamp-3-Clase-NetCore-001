using ERP.Bll.Security.Profile;
using ERP.Filters;
using ERP.Helper.Data;
using ERP.Helper.Models;
using ERP.Models.Security.Authentication;
using ERP.Models.Security.Profile;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ERP.Controllers.Security
{
    [Route("api/Security/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(SessionUserFilter))]
    public class ProfileController : ControllerBase
    {
        IProfileBll bll;

        public ProfileController(IProfileBll bll)
        {
            this.bll = bll;
        }

        [HttpPost("Me")]
        public ResponseGeneralModel<ProfileResponseModel> GetProfile()
        {
            try
            {
                return bll.Me();
            }
            catch (Exception ex)
            {
                return new ResponseGeneralModel<ProfileResponseModel>(500, null, MessageHelper.errorGeneral, ex.ToString());
            }
        }
    }
}
