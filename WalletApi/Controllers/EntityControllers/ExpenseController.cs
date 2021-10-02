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
    public class ExpenseController :EntityControllerBase<ExpenseDto>
    {
        private readonly new IExpenseService _service;

        public ExpenseController(IExpenseService service, IEntityGenerator<ExpenseDto> entityGenerator) : base(service, entityGenerator)
        {
            _service = service;

        }


    }
}
