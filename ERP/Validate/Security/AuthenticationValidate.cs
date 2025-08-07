﻿using Ejercicio_estructurado.Helpers.Helper;
using Ejercicio_estructurado.Helpers.Vars;
using ERP.Helper.Models;
using ERP.Models.Security.Authentication;

namespace ERP.Validate.Security
{
    public class AuthenticationValidate
    {
        public ResponseGeneralModel<LoginResponseModel> Login(LoginRequestModel model)
        {
            ValidateHelper<LoginResponseModel> validaH = new ValidateHelper<LoginResponseModel>();

            return new ResponseGeneralModel<LoginResponseModel>(200, "");
        }

        public ResponseGeneralModel<bool> Register(RegisterRequestModel model)
        {
            ValidateHelper<bool> validaH = new ValidateHelper<bool>();

            ResponseGeneralModel<bool> valEmail = validaH.ValidResp(model.email, "email", Min: 8, Max: 25, ListRegExp: new List<string>() { VarHelper.RegExpEmail });
            if (valEmail.code != 200) return valEmail;

            return new ResponseGeneralModel<bool>(200, "");
        }
    }
}
