using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DbModels.EF
{
    public class Ingress
    {
        public int IdIngress { get; set; }
        public int? IdType { get; set; }
        public int IdUser { get; set; }
        public string Tittle { get; set; }
        public float Quantity { get; set; }
        public string Description { get; set; }
        public DateTime IngressDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public IngressType IngressType { get; set; }
        public Users User { get; set; }

    }
}
