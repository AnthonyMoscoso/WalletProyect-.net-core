
using Core.Entities.Utilities.IdGenerator.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Utilities.IdGenerator
{
    public abstract class IDGeneratorBase<T,TKey> : IIDGenerator<T,TKey>
    {
        public abstract TKey GetNewId(T entity);
    }
}
