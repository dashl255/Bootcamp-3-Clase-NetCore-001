using ERP.CoreDB;

namespace ERP.Bll.User
{
    public interface IUserBll
    {
        public List<Usuario> GetUsers();
       public bool ChangeUsername(int userId, string newUsername);

    }
}
