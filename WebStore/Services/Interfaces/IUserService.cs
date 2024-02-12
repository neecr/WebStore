using WebStore.Dto.RequestDtos;
using WebStore.Models;

namespace WebStore.Services.Interfaces
{
    public interface IUserService
    {
        public string CreateToken(UserRequestDto user);
        public User Register(UserRequestDto user);
    }
}

