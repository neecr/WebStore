using Microsoft.EntityFrameworkCore;
using WebStore.Data;
using WebStore.Models;
using WebStore.Repositories.Interfaces;

namespace WebStore.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public bool IsUserExistsAndValid(string login, string password)
        {
            return _context.Users.AsNoTracking().Any(user =>
                user.Login == login && user.Password == password);
        }

        public bool IsUserAlreadyExists(string login)
        {
            return _context.Users.AsNoTracking().Any(user => user.Login == login);
        }
        public User Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}