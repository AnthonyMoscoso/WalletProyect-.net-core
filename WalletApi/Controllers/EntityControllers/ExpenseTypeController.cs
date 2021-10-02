using Business.DataServices.Abstracts;
using Core.Entities.Utilities.EntityGenerator.Abstracts;
using Entities.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalletApi.Controllers.EntityControllers.Base;

namespace WalletApi.Controllers.EntityControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExpenseTypeController : EntityControllerBase<ExpenseTypeDto>
    {
        private readonly new IExpenseTypeService _service;
        public ExpenseTypeController(IExpenseTypeService service, IEntityGenerator<ExpenseTypeDto> entityGenerator) : base(service, entityGenerator)
        {
            _service = service;
        }

        
    }
}
