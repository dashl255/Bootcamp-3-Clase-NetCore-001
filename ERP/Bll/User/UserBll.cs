using ERP.CoreDB;

namespace ERP.Bll.User
{
    public class UserBll : IUserBll
    {
        BaseErpContext _context;

        public UserBll(BaseErpContext context)
        {
            _context = context;
        }

        public List<Usuario> GetUsers()
        {
            return _context.Usuarios.ToList();
        }
    }
}
