using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Utilities.IdGenerator.Abstracts
{
    public interface IIDGenerator<T, TKey>
    {
        TKey GetNewId(T entity);
     
    }
}
