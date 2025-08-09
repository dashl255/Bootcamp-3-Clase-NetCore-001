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
        public bool ChangeUsername(int userId, string newUsername)
        {
            var user = _context.Usuarios.FirstOrDefault(u => u.UsuId == userId);
            if (user == null)
                throw new Exception("Usuario no encontrado");

            if (string.IsNullOrWhiteSpace(newUsername))
                throw new Exception("El nuevo nombre no puede estar vacío");

            user.UsuNombre = newUsername;
            _context.SaveChanges();

            return true;
        }


    }
}
