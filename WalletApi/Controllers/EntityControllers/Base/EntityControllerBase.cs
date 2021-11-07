

using Core.DataServices.Abstracts;
using Core.Entities.Abstracts;
using Core.Entities.Utilities.EntityGenerator.Abstracts;
using Core.Entities.Utilities.ExpressionsConverter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using WalletApi.Middleware.Mapper;

namespace WalletApi.Controllers.EntityControllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityControllerBase<T, TKey> : ControllerBase
        where T : class, IEntity<TKey>, new()
    {

        protected IDataService<T,TKey> _service;
        protected IEntityGenerator<T> _entityGenerator;
        public EntityControllerBase(IDataService<T,TKey> service, IEntityGenerator<T> entityGenerator)
        {
            _service = service;
            _entityGenerator = entityGenerator;
        }


        [HttpGet]
        [Route("Count")]
        public IActionResult Count()
        {
            return Ok(_service.Count());
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{id}")]
        public IActionResult GetSingle(TKey id)
        {
            return Ok(_service.GetByKey(id));
        }


        [HttpGet]
        [Route("pag")]
        public IActionResult Get(string order, int pag, int elements)
        {
            return Ok(_service.GetPag(MappingExpressions.GetTPropertyExpressionFromStringParameter<T>(order), pag, elements));
        }


        [HttpGet]
        [Route("pagDesc")]
        public IActionResult GetDesc(string order, int pag, int elements)
        {
            return Ok(_service.GetPagDesc(MappingExpressions.GetTPropertyExpressionFromStringParameter<T>(order), pag, elements));
        }


        [HttpGet]
        [Route("order/{order}")]
        public IActionResult GetOrder(string order)
        {

            return Ok(_service.GetOrder(MappingExpressions.GetTPropertyExpressionFromStringParameter<T>(order)));
        }


        [HttpGet]
        [Route("orderDesc/{order}")]
        public IActionResult GetOrderDesc(string order)
        {

            return Ok(_service.GetOrder(MappingExpressions.GetTPropertyExpressionFromStringParameter<T>(order)));
        }

        [HttpGet]
        [Route("First/{order}")]
        public IActionResult GetFirst(string order)
        {

            return Ok(_service.GetFirst(MappingExpressions.GetTPropertyExpressionFromStringParameter<T>(order)));
        }


        [HttpGet]
        [Route("Last/{order}")]
        public IActionResult GetLast(string order)
        {

            return Ok(_service.GetLast(MappingExpressions.GetTPropertyExpressionFromStringParameter<T>(order)));
        }

        [HttpGet]
        [Route("Top/{order}/{quantity}")]
        public IActionResult GetTop(string order, int quantity)
        {

            return Ok(_service.GetTop(MappingExpressions.GetTPropertyExpressionFromStringParameter<T>(order), quantity));
        }

        [HttpGet]
        [Route("Property/{property}")]
        public IActionResult Count(string property)
        {

            return Ok(_service.GetProperty(MappingExpressions.GetTPropertyExpressionFromStringParameter<T>(property)));
        }

        [HttpGet]
        [Route("Max/{property}")]
        public IActionResult GetMax(string property)
        {
            var expression = MappingExpressions.GetTPropertyExpressionFromStringParameter<T>(property);
            return Ok(_service.GetMax(expression));
        }


        [HttpGet]
        [Route("Min/{property}")]
        public IActionResult GetMin(string property)
        {
            var expression = MappingExpressions.GetTPropertyExpressionFromStringParameter<T>(property);
            return Ok(_service.GetMin(expression));
        }

        [HttpGet]
        [Route("FirstProperty/{property}")]
        public IActionResult GetFirstProperty(string property)
        {
            var expression = MappingExpressions.GetTPropertyExpressionFromStringParameter<T>(property);
            return Ok(_service.GetFirstProperty(expression));
        }

        [HttpGet]
        [Route("LastProperty/{property}")]
        public IActionResult GetLastProperty(string property)
        {
            var expression = MappingExpressions.GetTPropertyExpressionFromStringParameter<T>(property);
            return Ok(_service.GetLastProperty(expression));
        }

        [HttpPost]
        public IActionResult Insert(T entity)
        {
            return Ok(_service.Insert(entity));
        }

        [HttpPut]
        public IActionResult Update(T entity)
        {
            return Ok(_service.Update(entity));
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public IActionResult Delete(TKey id)
        {
            return Ok(_service.Delete(id));
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("Generator/{num}")]
        public IActionResult Generator(int num = 1)
        {
            return Ok(_entityGenerator.GenerateEntities(num));
        }

      
    }
}
