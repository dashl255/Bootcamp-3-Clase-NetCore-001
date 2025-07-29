using Ejercicio_estructurado.Helpers.Helper;
using Ejercicio_estructurado.Helpers.Models;
using Ejercicio_estructurado.Helpers.Vars;
using Ejercicio_estructurado.Models.Classroom;
using System.Collections.Generic;

namespace Ejercicio_estructurado.Validator.Classroom
{
    public class ClassroomValidate
    {

        public ResponseGeneralModel<List<ClassroomModel>> AddClassroom(ClassroomAddRequest model)
        {
            ValidateHelper<List<ClassroomModel>> validaH = new ValidateHelper<List<ClassroomModel>>();

            ResponseGeneralModel<List<ClassroomModel>> valName = validaH.ValidResp(model.name, "name", Min: 4, Max: 12, ListRegExp: new List<string>() { VarHelper.regExParamString });
            if (valName.code != 200) return valName;


            if(model.year < 2000 || model.year > 3000)
            {
                return new ResponseGeneralModel<List<ClassroomModel>>(400, null, Message.ErrorParamsGeneral, Message.validateParamYearClassroom);
            }

            return new ResponseGeneralModel<List<ClassroomModel>>(200, "");
        }
    }
}
