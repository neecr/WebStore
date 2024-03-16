using WebStore.Models;

namespace WebStore.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public bool IsUserExistsAndValid(string login, string password);
        public bool IsUserAlreadyExists(string login);
        public User Register(User user);
    }
}
