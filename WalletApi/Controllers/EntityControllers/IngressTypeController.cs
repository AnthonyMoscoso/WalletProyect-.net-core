
using Business.DataServices.Abstracts;
using Core.Entities.Utilities.EntityGenerator.Abstracts;
using Entities.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WalletApi.Controllers.EntityControllers.Base;

namespace WalletApi.Controllers.EntityControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IngressTypeController : EntityControllerBase<IngressTypeDto>
    {
        private readonly new IIngressTypeService _service;
        public IngressTypeController(IIngressTypeService service,IEntityGenerator<IngressTypeDto> entityGenerator) : base(service, entityGenerator)
        {
            _service = service;
        }
    }
}
