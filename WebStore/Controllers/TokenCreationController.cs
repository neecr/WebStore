using Microsoft.AspNetCore.Mvc;
using WebStore.Dto.RequestDtos;
using WebStore.Services.Interfaces;

namespace WebStore.Controllers
{
    [ApiController]
    public class TokenCreationController : Controller
    {
        private readonly IUserService _userService;

        public TokenCreationController(IUserService userService)
        {
            _userService = userService;
        }
        
        [Route("createToken")]
        [HttpPost]
        public IActionResult CreateToken(UserRequestDto user)
        {
            var token = _userService.CreateToken(user);
            return Ok(token);
        }
        
        [Route("register")]
        [HttpPost]
        public IActionResult Register(UserRequestDto user)
        {
            var newUser = _userService.Register(user);
            return Ok(newUser);
        }
    }
}