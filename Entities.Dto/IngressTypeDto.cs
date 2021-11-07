using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class IngressTypeDto : BaseEntity<int>
    {
        public int IdType { get; set; }
        public int IdUser { get; set; }
        public string TypeName { get; set; }
        public string TypeDescription { get; set; }
        public override int ID { get => IdType; set => IdType = value; }
    }
}

