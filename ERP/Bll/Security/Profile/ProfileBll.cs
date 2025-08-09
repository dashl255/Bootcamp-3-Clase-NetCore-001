using Azure.Core;
using ERP.CoreDB;
using ERP.Helper.Helper;
using ERP.Helper.Models;
using ERP.Models.Security.Profile;
using Newtonsoft.Json;

namespace ERP.Bll.Security.Profile
{
    public class ProfileBll : IProfileBll
    {
        BaseErpContext _context;
        IHttpContextAccessor _httpContext;
        public ProfileBll(BaseErpContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        public ResponseGeneralModel<ProfileResponseModel> Me()
        {
            string token = _httpContext.HttpContext.Request.Headers["token"];
            MethodsHelper<ProfileResponseModel> metHel = new MethodsHelper<ProfileResponseModel>();
            ResponseGeneralModel<ProfileResponseModel> decToken = metHel.DecodeJwtSession(token);
            if (decToken.code != 200) return decToken;

            SessionModel sessMod = JsonConvert.DeserializeObject<SessionModel>(decToken.message);

            var dataUs = (from us in _context.Usuarios
                          join comp in _context.Empresas on us.EmpresaId equals comp.EmpresaId
                          select new
                          {
                              us,
                              comp
                          }).FirstOrDefault((item) => item.us.UsuId == sessMod.id);

            ProfileResponseModel profResp = new ProfileResponseModel()
            {
                name = dataUs.us.UsuNombre,
                email = dataUs.us.Email,
                companyName = dataUs.comp.EmpresaNombre,
            };

            return new ResponseGeneralModel<ProfileResponseModel>(200, profResp, "");
        }
    }
}
