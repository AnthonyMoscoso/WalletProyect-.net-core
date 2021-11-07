using Business.DataServices.Abstracts;
using Core.Entities.Utilities.EntityGenerator.Abstracts;
using Core.Entities.Utilities.ExpressionsConverter;
using Entities.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq.Expressions;
using WalletApi.Controllers.EntityControllers.Base;
using WalletApi.Middleware.Mapper;

namespace WalletApi.Controllers.EntityControllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class IngressController : EntityControllerBase<IngressDto, int>
    {
        private readonly new IIngressService _service;
        public IngressController(IIngressService service, IEntityGenerator<IngressDto> entityGenerator) : base(service, entityGenerator)
        {
            _service = service;
        }

        [AllowAnonymous]
        [Route("Max/{property}")]
        [HttpGet]
        public new IActionResult GetMax(string property)
        {
           var X = MappingExpressions.GetTPropertyExpressionFromStringParameter<IngressDto,decimal>(property);
            return Ok(_service.GetMax(X));
        }

        [AllowAnonymous]
        [Route("hello")]
        [HttpGet]
        public  IActionResult hello()
        {
          
            return Ok(_service.GetProperty(w=> w.IdIngress, x=> x >12));
        }

    }
}

