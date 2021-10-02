using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Utilities.IdGenerator
{
    public abstract class IDGeneratorProfile<T>
    {
        public abstract string GetNewId(T entity);
    }
}
