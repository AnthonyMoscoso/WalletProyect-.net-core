using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DbModels.EF
{
    public class IngressType
    {
        public int IdType { get; set; }
        public int IdUser { get; set; }
        public string TypeName { get; set; }
        public string TypeDescription { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }


        public virtual ICollection<Ingress> Ingress { get; set; }
        public  Users User { get; set; }
    }
}
