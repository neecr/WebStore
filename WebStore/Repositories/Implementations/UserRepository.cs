using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebStore.Data;
using WebStore.Exceptions;
using WebStore.Models;
using WebStore.Repositories.Interfaces;

namespace WebStore.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IJwtProvider _jwtProvider;

        public UserRepository(DataContext context, IJwtProvider jwtProvider)
        {
            _context = context;
            _jwtProvider = jwtProvider;
        }

        public bool IsUserExists(string login, string password)
        {
            return _context.Users.Any(user =>
                user.Login == login && user.Password == password);
        }

        public string CreateToken(User inputUser)
        {
            return _jwtProvider.GenerateToken();
        }

        public User Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}