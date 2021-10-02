using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto.EF
{
    public class ForgetPassRequestDto
    {
        public int IdRequest { get; set; }
        public string Code { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
