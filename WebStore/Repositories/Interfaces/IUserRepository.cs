using WebStore.Models;

namespace WebStore.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public bool IsUserExists(string login, string password);
        public string CreateToken(User user);
        public User Register(User user);
    }
}
