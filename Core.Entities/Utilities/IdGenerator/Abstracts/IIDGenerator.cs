using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Utilities.IdGenerator.Abstracts
{
    public interface IIDGenerator<T>
    {
        string GetNewId(T entity);
     
    }
}
