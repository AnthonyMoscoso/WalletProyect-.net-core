using Core.Repository.Abstracts;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace Core.Repository.Specifics.DBs.EF
{
    public abstract class EFRepository<T> : IRepository<T>
        where T : class, new()
    {
        protected DbContext _context;
        protected string _identificator;
        protected string _name;
        protected DbSet<T> _table;
        public EFRepository(DbContext context, string identificator)
        {
            _context = context;
            _identificator = identificator;
            _name = typeof(T).Name;
            _table = _context.Set<T>();

        }
        public int Count()
        {
            
            return _table.Count();
        }
        public int Count(Expression<Func<T, bool>> predicate)
        {
            return _table.Count(predicate);
        }
        public int Count<TProperty>(Expression<Func<T, TProperty>> property, Expression<Func<TProperty, bool>> predicate)
        {
            return _table.Select(property).Count(predicate);
        }
        public int Count<TProperty>(Expression<Func<T, TProperty>> property, Expression<Func<T, bool>> predicate)
        {
            return _table.Where(predicate).Select(property).Count();
        }
        public int Delete(int id)
        {
            T search = GetSingle(id);
            if (search != null)
            {
                _table.Remove(search);
                Save();
                return id;
            }
            throw new Exception($"{_name} with {_identificator} : {id} not was found");

        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public IEnumerable<T> Get()
        {
 
            return _table;
        }
        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _table.Where(predicate);
        }
        public TProperty GetFirstProperty<TProperty>(Expression<Func<T, TProperty>> property)
        {
            MemberExpression memberExpression = property.Body as MemberExpression;
            string property_name = memberExpression.Member.Name;
            return _table.Select(property).OrderBy(w => property_name).FirstOrDefault();
        }
        public TProperty GetFirstProperty<TProperty>(Expression<Func<T, TProperty>> property, Expression<Func<TProperty, bool>> filter)
        {
            MemberExpression memberExpression = property.Body as MemberExpression;
            string property_name = memberExpression.Member.Name;
            return _table.Select(property).Where(filter).OrderBy(w => property_name).FirstOrDefault();
        }
        public TProperty GetFirstProperty<TProperty>(Expression<Func<T, TProperty>> property, Expression<Func<T, bool>> entityFilter)
        {
            MemberExpression memberExpression = property.Body as MemberExpression;
            string property_name = memberExpression.Member.Name;
            return _table.Where(entityFilter).Select(property).OrderBy(w => property_name).FirstOrDefault();
        }
        public TProperty GetLastProperty<TProperty>(Expression<Func<T, TProperty>> property)
        {
            MemberExpression memberExpression = property.Body as MemberExpression;
            string property_name = memberExpression.Member.Name;
            return _table.Select(property).OrderBy(w => property_name).LastOrDefault();
        }
        public TProperty GetLastProperty<TProperty>(Expression<Func<T, TProperty>> property, Expression<Func<TProperty, bool>> filter)
        {
            MemberExpression memberExpression = property.Body as MemberExpression;
            string property_name = memberExpression.Member.Name;
            return _table.Select(property).Where(filter).OrderBy(w => property_name).LastOrDefault();
        }
        public TProperty GetLastProperty<TProperty>(Expression<Func<T, TProperty>> property, Expression<Func<T, bool>> entityFilter)
        {
            MemberExpression memberExpression = property.Body as MemberExpression;
            string property_name = memberExpression.Member.Name;
            return _table.Where(entityFilter).Select(property).OrderBy(w => property_name).LastOrDefault();
        }
        public IEnumerable<T> GetOrder<TProperty>(Expression<Func<T, TProperty>> property)
        {           
            return _table.OrderBy(property).ToList();
        }
        public IEnumerable<T> GetOrder<TProperty>(Expression<Func<T, TProperty>> property, Expression<Func<T, bool>> expression)
        {
            return _table.Where(expression).OrderBy(property).ToList();
        }
        public IEnumerable<T> GetOrder<TProperty>(Expression<Func<T, TProperty>> property, Expression<Func<T, bool>> expression, int pag, int element)
        {
            return _table.Where(expression).OrderBy(property).Take((pag - 1) * element).Take(element);
        }
        public IEnumerable<T> GetPag<TProperty>(Expression<Func<T, TProperty>> property, int pag, int element)
        {
            return _table.OrderBy(property).Skip((pag - 1) * element).Take(element);
        }
        public IEnumerable<T> GetPagDesc<TProperty>(Expression<Func<T, TProperty>> property, int pag, int element)
        {
            return _table.OrderByDescending(property).Skip((pag - 1) * element).Take(element);
        }
        public IEnumerable<TProperty> GetProperty<TProperty>(Expression<Func<T, TProperty>> property)
        {
            return _table.Select(property);
        }
        public IEnumerable<TProperty> GetProperty<TProperty>(Expression<Func<T, TProperty>> property, Expression<Func<TProperty, bool>> filter)
        {
            return _table.Select(property).Where(filter);
        }
        public IEnumerable<TProperty> GetProperty<TProperty>(Expression<Func<T, TProperty>> property, Expression<Func<T, bool>> entityFilter)
        {
            return _table.Where(entityFilter).Select(property);
        }
        public T GetSingle(int id)
        {
            return _table.Find(id);
        }
        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return _table.SingleOrDefault(predicate);
        }
        public TProperty GetSingleProperty<TProperty>(Expression<Func<T, TProperty>> property, Expression<Func<TProperty, bool>> filter)
        {
            return _table.Select(property).Where(filter).SingleOrDefault();
        }
        public TProperty GetSingleProperty<TProperty>(Expression<Func<T, TProperty>> property, Expression<Func<T, bool>> entityFilter)
        {
            return _table.Where(entityFilter).Select(property).SingleOrDefault();
        }
        public T Insert(T entity)
        {
            _table.Add(entity);
            Save();
            return entity;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public T Update(T entity, int id)
        {
            T search = GetSingle(id);
            if (search != null)
            {
                _context.Entry(search).CurrentValues.SetValues(entity);
            }
            throw new Exception($"{_name} with {_identificator} : {id} not was found");
        }
        public TProperty GetMax<TProperty>(Expression<Func<T, TProperty>> property)
        {

            return _table.Max(property);
        }
        public TProperty GetMax<TProperty>(Expression<Func<T, TProperty>> property, Expression<Func<T, bool>> filter)
        {
            
            return _table.Where(filter).Max(property);
        }
        public TProperty GetMin<TProperty>(Expression<Func<T, TProperty>> property)
        {

            return _table.Min(property);
        }
        public TProperty GetMin<TProperty>(Expression<Func<T, TProperty>> property, Expression<Func<T, bool>> filter)
        {

            return _table.Where(filter).Min(property);
        }
        public IEnumerable<T> GetOrderDesc<TProperty>(Expression<Func<T, TProperty>> property)
        {
            return _table.OrderByDescending(property);
        }
        public IEnumerable<T> GetOrderDesc<TProperty>(Expression<Func<T, TProperty>> property, Expression<Func<T, bool>> expression)
        {
            return _table.Where(expression).OrderByDescending(property);
        }
        public IEnumerable<T> GetOrderDesc<TProperty>(Expression<Func<T, TProperty>> property, Expression<Func<T, bool>> expression, int pag, int element)
        {
            return _table.Where(expression).OrderByDescending(property).Skip((pag-1)*element).Take(element);
        }

        public T GetFirst<TProperty>(Expression<Func<T, TProperty>> orderProperty)
        {
            return _table.OrderBy(orderProperty).FirstOrDefault();
        }

        public T GetLast<TProperty>(Expression<Func<T, TProperty>> orderProperty)
        {
            return _table.OrderBy(orderProperty).LastOrDefault();
        }

        public IEnumerable<T> GetTop<TProperty>(Expression<Func<T, TProperty>> orderProperty, int quantity)
        {
            return _table.OrderBy(orderProperty).Take(quantity);
        }

        public IEnumerable<T> GetTop<TProperty>(Expression<Func<T, TProperty>> orderProperty, int quantity, Expression<Func<T, bool>> expression)
        {
            return _table.Where(expression).OrderBy(orderProperty).Take(quantity);
        }
    }
}
