using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DbModels.EF
{
    public class ForgetPassRequest
    {
        public int IdRequest { get; set; }
        public string Code { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
