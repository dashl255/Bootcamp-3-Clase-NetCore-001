using Ejercicio_estructurado.Helpers.Models;
using Ejercicio_estructurado.Helpers.Vars;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.RegularExpressions;

namespace Ejercicio_estructurado.Helpers.Helper
{
    public class ValidateHelper<T>
    {

        public ResponseGeneralModel<T> ValidResp(string Value, string Name, int? Max = null, int? Min = null, List<string>? ListRegExp = null, string? MsjMinV = null, string? MsjMaxV = null, List<string>? ListMsjRegExp = null)
        {
            if (Max != null)
            {
                if (!MaxLength(Value, Max ?? 0)) return new ResponseGeneralModel<T>(
                    400,
                    Message.ErrorParamsGeneral
                    //MsjMaxV ?? "El parametro " + Name + " excede el límite de " + Max + " caracteres"
                );
            }
            if (Min != null)
            {
                if (!MinLength(Value, Min ?? 0)) return new ResponseGeneralModel<T>(
                    400,
                    Message.ErrorParamsGeneral
                    //MsjMinV ?? "El parametro " + Name + " debe tener un mínimo de " + Min + " caracteres"
                );
            }

            if (ListRegExp != null)
            {
                for (int i = 0; i < ListRegExp.Count; i++)
                {
                    if (!RegExpVald(Value, ListRegExp[i]))
                    {
                        bool isMsjPers = ListMsjRegExp != null ? ListMsjRegExp.Count >= (i - 1) : false;
                        return new ResponseGeneralModel<T>(
                            400,
                            Message.ErrorParamsGeneral
                            //isMsjPers ? ListMsjRegExp[i] : "El parametro " + Name + " no cumple con la expresión regular " + ListRegExp[i]
                        );
                    }
                }
            }


            return new ResponseGeneralModel<T>(200, "");
        }

        bool MaxLength(string Value, int Max)
        {
            return (Value.Length <= Max);
        }

        bool MinLength(string Value, int Min)
        {
            return (Value.Length >= Min);
        }

        bool RegExpVald(string Value, string RegExp)
        {
            Regex RegE = new Regex(RegExp);
            return RegE.IsMatch(Value);
        }


        bool EmailValid(string Value)
        {
            string RegExpEmail = VarHelper.RegExpEmail;
            return RegExpVald(Value, RegExpEmail);
        }
    }
}
