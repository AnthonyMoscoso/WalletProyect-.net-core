
using Business.DataServices.Abstracts;
using Entities.Dto;
using Entities.Dto.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WalletApi.Middleware.Authentication;

namespace WalletApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserService _service;
        public LoginController(IConfiguration config,IUserService service)
        {
            _config = config;
            _service = service;
        }

        [HttpPost]
        public IActionResult Login(LoginRequest loginRequest)
        {
            IActionResult response = Unauthorized();

            UserDto user = _service.Login(loginRequest);
            if (user!=null)
            {
                string tokenString = TokenGenerator.GenerateJSONWebToken(_config,user);
                response = Ok(new TokenAuthentication() { Token = tokenString }) ;
            }
            
            return response;
        }
    }
}
