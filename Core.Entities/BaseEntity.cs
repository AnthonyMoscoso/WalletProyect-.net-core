using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public abstract class BaseEntity<TKey> : IEntity<TKey>
    {
        public abstract TKey  ID { get; set; }
        public DateTime CreateDate { get ; set ; }
        public DateTime LastUpdateDate { get; set; }
    }
}
