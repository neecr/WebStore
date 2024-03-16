using AutoMapper;
using FluentValidation;
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
        private readonly IJwtProvider _jwtProvider;
        private readonly IMapper _mapper;
        private readonly IValidator<User> _validator;

        public UserService(IUserRepository userRepository, IMapper mapper, IJwtProvider jwtProvider,
            IValidator<User> validator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtProvider = jwtProvider;
            _validator = validator;
        }

        public string CreateToken(UserRequestDto user)
        {
            if (!_userRepository.IsUserExistsAndValid(user.Login, user.Password))
                throw new WrongCredentialsException("Incorrect login or password.");

            return _jwtProvider.GenerateToken();
        }

        public User Register(UserRequestDto user)
        {
            if (_userRepository.IsUserAlreadyExists(user.Login))
                throw new WrongCredentialsException("The user with such login is already registered");
            var newUser = _mapper.Map<User>(user);
            Validate(newUser);
            _userRepository.Register(newUser);
            return newUser;
        }

        public void Validate(User user)
        {
            var result = _validator.Validate(user);
            if (result.IsValid) return;
            throw new ValidationException($"Validation error: {result}");
        }
    }
}