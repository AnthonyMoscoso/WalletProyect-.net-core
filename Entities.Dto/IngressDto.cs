using Core.Entities;
using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class IngressDto : BaseEntity<int>
    {
        public int IdIngress { get; set; }
        public int? IdType { get; set; }
        public int IdUser { get; set; }
        public string Tittle { get; set; }
        public float Quantity { get; set; }
        public string Description { get; set; }
        public DateTime IngressDate { get; set; }
        public override int ID { get => IdIngress; set => IdIngress = value; }
 
    }
}
