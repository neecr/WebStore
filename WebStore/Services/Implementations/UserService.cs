using AutoMapper;
using WebStore.Dto.RequestDtos;
using WebStore.Exceptions;
using WebStore.Models;
using WebStore.Repositories.Interfaces;
using WebStore.Services.Interfaces;

namespace WebStore.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
    
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public string CreateToken(UserRequestDto user)
        {
            if (!_userRepository.IsUserExists(user.Login, user.Password)) 
                throw new WrongCredentialsException("Incorrect login or password.");
            
            return _userRepository.CreateToken(_mapper.Map<User>(user));
        }

        public User Register(UserRequestDto user)
        {
            var newUser = _mapper.Map<User>(user);
            _userRepository.Register(newUser);
            return newUser;
        }
    }
}

