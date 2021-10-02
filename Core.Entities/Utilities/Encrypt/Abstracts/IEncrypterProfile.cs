using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Utilities.Encrypt
{
    public interface IEncrypterProfile<T> 
    {
        /// <summary>
        /// Return the same entity descrypt
        /// </summary>
        /// <param name="entity"> the entity to be descrypt </param>
        /// <returns></returns>
        T DecryptEntity(T entity);
        T EncryptEntity(T entity);

        IEnumerable<T> DecryptRange(IEnumerable<T> list);
        IEnumerable<T> EncryptList(IEnumerable<T> list);
    }
}
