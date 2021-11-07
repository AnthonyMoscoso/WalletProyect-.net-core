using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Abstracts
{
    public interface IEntity<TKey>
    {

        TKey ID { get; set; }
        DateTime CreateDate { get; set; }
        DateTime LastUpdateDate { get; set; }
    }
}
