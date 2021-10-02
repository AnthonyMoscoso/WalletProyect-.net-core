
using Core.Entities.Utilities.IdGenerator.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Utilities.IdGenerator
{
    public abstract class IDGeneratorBase<T> : IIDGenerator<T>
    {
        public abstract string GetNewId(T entity);
    }
}
