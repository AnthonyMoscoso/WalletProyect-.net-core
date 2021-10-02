﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataServices.Abstracts
{
    public interface IDataService<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int Count(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="property"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int Count<TProperty>(Expression<Func<T, TProperty>> property, Expression<Func<TProperty, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="property"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int Count<TProperty>(Expression<Func<T, TProperty>> property, Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Insert a entity in table 
        /// </summary>
        /// <param name="entity">entity to insert</param>
        /// <returns>the entity</returns>
        T Insert(T entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Update(T entity);

        /// <summary>
        /// Delete entity searching for id
        /// </summary>
        /// <param name="id">id to search</param>
        /// <returns>the id of entity to delete</returns>
        int Delete(int id);

        /// <summary>
        /// Get a single entity search by id
        /// </summary>
        /// <param name="id">identificator in table</param>
        /// <returns>entity founded</returns>
        T GetSingle(int id);

        /// <summary>
        /// Get a single entity filter by expression
        /// </summary>
        /// <param name="predicate">filter expression</param>
        /// <returns>Entity founded</returns>
        T GetSingle(Expression<Func<T, bool>> predicate);


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="orderProperty"></param>
        /// <returns></returns>
        T GetFirst<TProperty>(Expression<Func<T, TProperty>> orderProperty);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="orderProperty"></param>
        /// <returns></returns>
        T GetLast<TProperty>(Expression<Func<T, TProperty>> orderProperty);
        /// <summary>
        /// Get all values from table
        /// </summary>
        /// <returns>collection from db</returns>
        IEnumerable<T> Get();

        /// <summary>
        /// Get all values from table filter by expression
        /// </summary>
        /// <param name="predicate">Ling expression</param>
        /// <returns>Collection form db filter</returns>
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Get all values from table filter by expression order by filter
        /// </summary>
        /// <param name="predicate">Ling expression</param>
        /// <param name="orderBy">order filter</param>
        /// <returns>Collection form db filter by expression order by order parameter </returns>
        IEnumerable<T> GetOrder<TProperty>(Expression<Func<T, TProperty>>predicate);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="property"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        IEnumerable<T> GetOrder<TProperty>(Expression<Func<T, TProperty>> property, Expression<Func<T, bool>> expression);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="property"></param>
        /// <param name="expression"></param>
        /// <param name="pag"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        IEnumerable<T> GetOrder<TProperty>(Expression<Func<T, TProperty>> property, Expression<Func<T, bool>> expression, int pag, int element);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="property"></param>
        /// <returns></returns>
        IEnumerable<T> GetOrderDesc<TProperty>(Expression<Func<T, TProperty>> property);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="property"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        IEnumerable<T> GetOrderDesc<TProperty>(Expression<Func<T, TProperty>> property, Expression<Func<T, bool>> expression);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="propertyOrder"></param>
        /// <param name="expression"></param>
        /// <param name="pag"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        IEnumerable<T> GetOrderDesc<TProperty>(Expression<Func<T, TProperty>> property, Expression<Func<T, bool>> expression, int pag, int element);


        IEnumerable<T> GetTop<TProperty>(Expression<Func<T, TProperty>> orderProperty, int quantity);

        IEnumerable<T> GetTop<TProperty>(Expression<Func<T, TProperty>> orderProperty, int quantity, Expression<Func<T, bool>> expression);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <param name="pag"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        IEnumerable<T> GetPag<TProperty>(Expression<Func<T, TProperty>> property, int pag, int element);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="property"></param>
        /// <param name="pag"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        IEnumerable<T> GetPagDesc<TProperty>(Expression<Func<T, TProperty>> property, int pag, int element);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="property"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        TProperty GetSingleProperty<TProperty>(Expression<Func<T, TProperty>> property, Expression<Func<TProperty, bool>> filter);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="property"></param>
        /// <param name="entityFilter"></param>
        /// <returns></returns>
        TProperty GetSingleProperty<TProperty>(Expression<Func<T, TProperty>> property, Expression<Func<T, bool>> entityFilter);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="property"></param>
        /// <returns></returns>
        TProperty GetLastProperty<TProperty>(Expression<Func<T, TProperty>> property);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="property"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        TProperty GetLastProperty<TProperty>(Expression<Func<T, TProperty>> property, Expression<Func<TProperty, bool>> filter);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="property"></param>
        /// <param name="entityFilter"></param>
        /// <returns></returns>
        TProperty GetLastProperty<TProperty>(Expression<Func<T, TProperty>> property, Expression<Func<T, bool>> entityFilter);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="property"></param>
        /// <returns></returns>
        TProperty GetFirstProperty<TProperty>(Expression<Func<T, TProperty>> property);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="property"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        TProperty GetFirstProperty<TProperty>(Expression<Func<T, TProperty>> property, Expression<Func<TProperty, bool>> filter);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="property"></param>
        /// <param name="entityFilter"></param>
        /// <returns></returns>
        TProperty GetFirstProperty<TProperty>(Expression<Func<T, TProperty>> property, Expression<Func<T, bool>> entityFilter);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="property"></param>
        /// <returns></returns>
        IEnumerable<TProperty> GetProperty<TProperty>(Expression<Func<T, TProperty>> property);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="property"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        IEnumerable<TProperty> GetProperty<TProperty>(Expression<Func<T, TProperty>> property, Expression<Func<TProperty, bool>> filter);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="property"></param>
        /// <param name="entityFilter"></param>
        /// <returns></returns>
        IEnumerable<TProperty> GetProperty<TProperty>(Expression<Func<T, TProperty>> property, Expression<Func<T, bool>> entityFilter);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        TProperty GetMin<TProperty>(Expression<Func<T, TProperty>> expression);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expression"></param>
        /// <param name="entityFilte"></param>
        /// <returns></returns>
        TProperty GetMin<TProperty>(Expression<Func<T, TProperty>> expression, Expression<Func<T, bool>> entityFilte);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        TProperty GetMax<TProperty>(Expression<Func<T, TProperty>> expression);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expression"></param>
        /// <param name="entityFilte"></param>
        /// <returns></returns>
        TProperty GetMax<TProperty>(Expression<Func<T, TProperty>> expression, Expression<Func<T, bool>> entityFilte);

    }
}
