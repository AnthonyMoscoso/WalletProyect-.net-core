using Business.DataServices.Abstracts;
using Core.Entities.Utilities.EntityGenerator.Abstracts;
using Entities.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WalletApi.Controllers.EntityControllers.Base;

namespace WalletApi.Controllers.EntityControllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : EntityControllerBase<UserDto, int>
    {
        private readonly new IUserService _service;

        public UserController(IUserService service, IEntityGenerator<UserDto> entityGenerator) : base(service, entityGenerator)
        {
            _service = service;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Register")]
        public IActionResult Register(UserDto userDto)
        {
            
            return Ok(_service.Register(userDto));
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("GeneratorUser/{num}")]
        public IActionResult GeneratorUser(int num = 1)
        {
            _entityGenerator.AddRuleForParameter(w => w.Email).ParamsFilter(new List<string>() { "Mario@gmail.com", "Pedro@Gmail.com" });
            _entityGenerator.AddRuleForParameter(w => w.Phone).IsUnique(false).IsPhoneNumber(false).TextFormat(TextFormats.OnlyText);
            return Ok(_entityGenerator.GenerateEntities(num));
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("ForgetPassword")]
        public IActionResult ForgetEmail([FromBody]string email)
        {
            return Ok(_service.ForgetPassword(email));
        }

      
    }
}
