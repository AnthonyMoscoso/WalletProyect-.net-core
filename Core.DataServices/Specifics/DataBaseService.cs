using AutoMapper;
using Core.DataServices.Abstracts;
using Core.Entities.Abstracts;
using Core.Entities.Utilities.Encrypt;
using Core.Entities.Utilities.ExpressionsConverter;
using Core.Entities.Utilities.IdGenerator.Abstracts;
using Core.Repository.Abstracts;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Core.DataServices.Specifics
{
    public abstract class DataBaseService<TEntity, T> : IDataService<TEntity>, IIDGenerator<TEntity>
        where TEntity : class, IEntity, new()
    {
        protected IMapper _mapper;
        protected IRepository<T> _repository;
        protected IValidator<TEntity> _validator;
        protected IEncrypterProfile<TEntity> _encryptor;
        protected string _name;
        public DataBaseService(IRepository<T> repository, IMapper mapper, IValidator<TEntity> validador, IEncrypterProfile<TEntity> encryptor)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validador;
            _encryptor = encryptor;
            _name = typeof(T).Name;
        }
        public int Delete(int id)
        {
            return _repository.Delete(id);
        }

        public IEnumerable<TEntity> Get()
        {
            IEnumerable<T> result = _repository.Get();
            IEnumerable<TEntity> list = _mapper.Map<IEnumerable<TEntity>>(result);
            return _encryptor != null ? _encryptor.DecryptRange(list) : list;

        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {

            IEnumerable<T> result = _repository.Get(MapExpression(predicate));
            IEnumerable<TEntity> list = _mapper.Map<IEnumerable<TEntity>>(result);
            return _encryptor != null ? _encryptor.DecryptRange(list) : list;

        }

        public TEntity GetSingle(int id)
        {
            T result = _repository.GetSingle(id);
            if (result != null)
            {
                TEntity entity = _mapper.Map<TEntity>(result);
                return _encryptor != null ? _encryptor.DecryptEntity(entity) : entity;
            }
            throw new Exception($"{_name} with Id {id} not was found");

        }

        public TEntity GetSingle(Expression<Func<TEntity, bool>> predicate)
        {

            T result = _repository.GetSingle(MapExpression(predicate));
            if (result != null)
            {
                TEntity entity = _mapper.Map<TEntity>(result);
                return _encryptor != null ? _encryptor.DecryptEntity(entity) : entity;
            }
            throw new Exception($"{_name} with  not was found");
        }

        public TEntity Insert(TEntity entity)
        {

            if (_validator != null)
            {
                ValidationResult validationResult = _validator.Validate(entity);
                if (validationResult.IsValid)
                {
                    entity.ID = Convert.ToInt32(GetNewId(entity));
                    return InsertEntity(entity);
                }
                throw new Exception(validationResult.Errors[0].ErrorCode + "\n " + validationResult.Errors[0].ErrorMessage);
            }
            else
            {
                return InsertEntity(entity);
            }
        }

        private TEntity InsertEntity(TEntity entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.LastUpdateDate = DateTime.Now;
            entity = _encryptor != null ? _encryptor.EncryptEntity(entity) : entity;
            T tentity = _mapper.Map<T>(entity);
            _repository.Insert(tentity);
            return GetSingle(entity.ID);
        }

        public TEntity Update(TEntity entity)
        {
            if (_validator != null)
            {
                ValidationResult validationResult = _validator.Validate(entity);
                if (validationResult.IsValid)
                {
                    return UpdateEntity(entity);
                }
                throw new Exception(validationResult.Errors[0].ErrorCode + "\n " + validationResult.Errors[0].ErrorMessage);
            }
            else
            {
                return UpdateEntity(entity);
            }

        }

        private TEntity UpdateEntity(TEntity entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            entity = _encryptor != null ? _encryptor.EncryptEntity(entity) : entity;
            T tentity = _mapper.Map<T>(entity);
            _repository.Update(tentity, entity.ID);
            return GetSingle(entity.ID);
        }

        public abstract string GetNewId(TEntity entity);

        public TProperty GetSingleProperty<TProperty>(Expression<Func<TEntity, TProperty>> property, Expression<Func<TProperty, bool>> filter)
        {
            return _repository.GetSingleProperty(MappingExpressions.MapTPropertyExpression<TEntity, TProperty,T>(property), filter);
        }

        public TProperty GetSingleProperty<TProperty>(Expression<Func<TEntity, TProperty>> property, Expression<Func<TEntity, bool>> entityFilter)
        {

            return _repository.GetSingleProperty(MappingExpressions.MapTPropertyExpression<TEntity, TProperty, T>(property), MapExpression(entityFilter));
        }

        public TProperty GetLastProperty<TProperty>(Expression<Func<TEntity, TProperty>> property)
        {
            return _repository.GetLastProperty(MappingExpressions.MapTPropertyExpression<TEntity, TProperty, T>(property));
        }

        public TProperty GetLastProperty<TProperty>(Expression<Func<TEntity, TProperty>> property, Expression<Func<TProperty, bool>> filter)
        {
            return _repository.GetLastProperty(MappingExpressions.MapTPropertyExpression<TEntity, TProperty, T>(property), filter);
        }

        public TProperty GetLastProperty<TProperty>(Expression<Func<TEntity, TProperty>> property, Expression<Func<TEntity, bool>> entityFilter)
        {
            return _repository.GetLastProperty(MappingExpressions.MapTPropertyExpression<TEntity, TProperty, T>(property), MapExpression(entityFilter));
        }

        public TProperty GetFirstProperty<TProperty>(Expression<Func<TEntity, TProperty>> property)
        {
            return _repository.GetFirstProperty(MappingExpressions.MapTPropertyExpression<TEntity, TProperty, T>(property));
        }

        public TProperty GetFirstProperty<TProperty>(Expression<Func<TEntity, TProperty>> property, Expression<Func<TProperty, bool>> filter)
        {
            return _repository.GetFirstProperty(MappingExpressions.MapTPropertyExpression<TEntity, TProperty, T>(property), filter);
        }

        public TProperty GetFirstProperty<TProperty>(Expression<Func<TEntity, TProperty>> property, Expression<Func<TEntity, bool>> entityFilter)
        {
            return _repository.GetFirstProperty(MappingExpressions.MapTPropertyExpression<TEntity, TProperty, T>(property), MapExpression(entityFilter));
        }

        public IEnumerable<TProperty> GetProperty<TProperty>(Expression<Func<TEntity, TProperty>> property)
        {

            return _repository.GetProperty(MappingExpressions.MapTPropertyExpression<TEntity, TProperty, T>(property));
        }

        public IEnumerable<TProperty> GetProperty<TProperty>(Expression<Func<TEntity, TProperty>> property, Expression<Func<TProperty, bool>> filter)
        {

            return _repository.GetProperty(MappingExpressions.MapTPropertyExpression<TEntity, TProperty, T>(property), filter);
        }

        public IEnumerable<TProperty> GetProperty<TProperty>(Expression<Func<TEntity, TProperty>> property, Expression<Func<TEntity, bool>> entityFilter)
        {

            Expression<Func<T, bool>> entity_expression = _mapper.Map<Expression<Func<T, bool>>>(property);
            return _repository.GetProperty(MappingExpressions.MapTPropertyExpression<TEntity, TProperty, T>(property), entity_expression);
        }

        public int Count()
        {
            return _repository.Count();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {

            return _repository.Count(MapExpression(predicate));
        }

        public int Count<TProperty>(Expression<Func<TEntity, TProperty>> property, Expression<Func<TProperty, bool>> predicate)
        {

            return _repository.Count(MappingExpressions.MapTPropertyExpression<TEntity, TProperty, T>(property), predicate);
        }

        public int Count<TProperty>(Expression<Func<TEntity, TProperty>> property, Expression<Func<TEntity, bool>> predicate)
        {

            return _repository.Count(MappingExpressions.MapTPropertyExpression<TEntity, TProperty, T>(property), MapExpression(predicate));
        }

        public IEnumerable<TEntity> GetOrder<TProperty>(Expression<Func<TEntity, TProperty>> property)
        {
            IEnumerable<T> result = _repository.GetOrder(MappingExpressions.MapTPropertyExpression<TEntity, TProperty, T>(property));
            IEnumerable<TEntity> list = _mapper.Map<IEnumerable<TEntity>>(result);
            return _encryptor != null ? _encryptor.DecryptRange(list) : list;
        }

        public IEnumerable<TEntity> GetPag<TProperty>(Expression<Func<TEntity, TProperty>> property, int pag, int element)
        {
            IEnumerable<T> result = _repository.GetPag(MappingExpressions.MapTPropertyExpression<TEntity, TProperty, T>(property), pag, element);
            IEnumerable<TEntity> list = _mapper.Map<IEnumerable<TEntity>>(result);
            return _encryptor != null ? _encryptor.DecryptRange(list) : list;
        }

        public IEnumerable<TEntity> GetOrder<TProperty>(Expression<Func<TEntity, TProperty>> property, Expression<Func<TEntity, bool>> expression)
        {
            IEnumerable<T> result = _repository.GetOrder(MappingExpressions.MapTPropertyExpression<TEntity, TProperty, T>(property), MapExpression(expression));
            IEnumerable<TEntity> list = _mapper.Map<IEnumerable<TEntity>>(result);
            return _encryptor != null ? _encryptor.DecryptRange(list) : list;
        }

        public IEnumerable<TEntity> GetOrder<TProperty>(Expression<Func<TEntity, TProperty>> property, Expression<Func<TEntity, bool>> expression, int pag, int element)
        {
            IEnumerable<T> result = _repository.GetOrder(MappingExpressions.MapTPropertyExpression<TEntity,TProperty, T>(property), MapExpression(expression), pag, element);
            IEnumerable<TEntity> list = _mapper.Map<IEnumerable<TEntity>>(result);
            return _encryptor != null ? _encryptor.DecryptRange(list) : list;
        }

        private Expression<Func<T, bool>> MapExpression(Expression<Func<TEntity, bool>> predicate)
        {
            return _mapper.Map<Expression<Func<T, bool>>>(predicate);
        }

        public TProperty GetMin<TProperty>(Expression<Func<TEntity, TProperty>> expression)
        {
            Expression<Func<T, TProperty>> e = MappingExpressions.MapTPropertyExpression<TEntity, TProperty, T>(expression);
            return _repository.GetMin(e);
        }

        public TProperty GetMin<TProperty>(Expression<Func<TEntity, TProperty>> expression, Expression<Func<TEntity, bool>> filter)
        {
            Expression<Func<T, TProperty>> e = MappingExpressions.MapTPropertyExpression<TEntity, TProperty, T>(expression);
            return _repository.GetMin(e, MapExpression(filter));
        }

        public TProperty GetMax<TProperty>(Expression<Func<TEntity, TProperty>> expression)
        {

            Expression<Func<T, TProperty>> e = MappingExpressions.MapTPropertyExpression<TEntity, TProperty, T>(expression);
            return _repository.GetMax(e);
        }

        public TProperty GetMax<TProperty>(Expression<Func<TEntity, TProperty>> expression, Expression<Func<TEntity, bool>> filter)
        {
            Expression<Func<T, TProperty>> e = MappingExpressions.MapTPropertyExpression<TEntity, TProperty, T>(expression);
            return _repository.GetMax(e, MapExpression(filter));
        }

        public IEnumerable<TEntity> GetOrderDesc<TProperty>(Expression<Func<TEntity, TProperty>> property)
        {
            Expression<Func<T, TProperty>> expression = _mapper.Map<Expression<Func<T, TProperty>>>(property);
            IEnumerable<T> result = _repository.GetOrderDesc(expression);
            IEnumerable<TEntity> list = _mapper.Map<IEnumerable<TEntity>>(result);
            return _encryptor != null ? _encryptor.DecryptRange(list) : list;
        }

        public IEnumerable<TEntity> GetOrderDesc<TProperty>(Expression<Func<TEntity, TProperty>> property, Expression<Func<TEntity, bool>> expression)
        {
            Expression<Func<T, TProperty>> expression_property = _mapper.Map<Expression<Func<T, TProperty>>>(property);
            IEnumerable<T> result = _repository.GetOrderDesc(expression_property, MapExpression(expression));
            IEnumerable<TEntity> list = _mapper.Map<IEnumerable<TEntity>>(result);
            return _encryptor != null ? _encryptor.DecryptRange(list) : list;
        }

        public IEnumerable<TEntity> GetOrderDesc<TProperty>(Expression<Func<TEntity, TProperty>> property, Expression<Func<TEntity, bool>> expression, int pag, int element)
        {
            Expression<Func<T, TProperty>> expression_property = _mapper.Map<Expression<Func<T, TProperty>>>(property);
            IEnumerable<T> result = _repository.GetOrderDesc(expression_property, MapExpression(expression),pag,element);
            IEnumerable<TEntity> list = _mapper.Map<IEnumerable<TEntity>>(result);
            return _encryptor != null ? _encryptor.DecryptRange(list) : list;
        }

        public IEnumerable<TEntity> GetPagDesc<TProperty>(Expression<Func<TEntity, TProperty>> property, int pag, int element)
        {
            Expression<Func<T, TProperty>> expression_property = _mapper.Map<Expression<Func<T, TProperty>>>(property);
            IEnumerable<T> result = _repository.GetPagDesc(expression_property, pag, element);
            IEnumerable<TEntity> list = _mapper.Map<IEnumerable<TEntity>>(result);
            return _encryptor != null ? _encryptor.DecryptRange(list) : list;
        }

        public TEntity GetFirst<TProperty>(Expression<Func<TEntity, TProperty>> orderProperty)
        {
            Expression<Func<T, TProperty>> expression_property = _mapper.Map<Expression<Func<T, TProperty>>>(orderProperty);
            T result = _repository.GetFirst(expression_property);
            TEntity entity = _mapper.Map<TEntity>(result);
            return _encryptor != null ? _encryptor.DecryptEntity(entity) : entity;
        }

        public TEntity GetLast<TProperty>(Expression<Func<TEntity, TProperty>> orderProperty)
        {
            Expression<Func<T, TProperty>> expression_property = _mapper.Map<Expression<Func<T, TProperty>>>(orderProperty);
            T result = _repository.GetLast(expression_property);
            TEntity entity = _mapper.Map<TEntity>(result);
            return _encryptor != null ? _encryptor.DecryptEntity(entity) : entity;
        }

        public IEnumerable<TEntity> GetTop<TProperty>(Expression<Func<TEntity, TProperty>> orderProperty, int quantity)
        {
            Expression<Func<T, TProperty>> expression_property = _mapper.Map<Expression<Func<T, TProperty>>>(orderProperty);
            IEnumerable<T> result = _repository.GetTop(expression_property, quantity);
            IEnumerable<TEntity> list = _mapper.Map<IEnumerable<TEntity>>(result);
            return _encryptor != null ? _encryptor.DecryptRange(list) : list;
        }

        public IEnumerable<TEntity> GetTop<TProperty>(Expression<Func<TEntity, TProperty>> orderProperty, int quantity, Expression<Func<TEntity, bool>> expression)
        {
            Expression<Func<T, TProperty>> expression_property = _mapper.Map<Expression<Func<T, TProperty>>>(orderProperty);
            IEnumerable<T> result = _repository.GetTop(expression_property, quantity, MapExpression(expression));
            IEnumerable<TEntity> list = _mapper.Map<IEnumerable<TEntity>>(result);
            return _encryptor != null ? _encryptor.DecryptRange(list) : list;
        }
    }
}
