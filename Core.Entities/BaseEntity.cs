using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public abstract class BaseEntity : IEntity
    {
        public abstract int ID { get; set; }
        public DateTime CreateDate { get ; set ; }
        public DateTime LastUpdateDate { get; set; }
    }
}
