using Core.Entities.Utilities.Encrypt;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.EncryptServices.Profiles
{
    public class IngressTypeEncrypterProfile : BaseEncryterProfile<IngressTypeDto>
    {
        public IngressTypeEncrypterProfile(IEncrypt encrypt) : base(encrypt)
        {
            //AddParameter(w=> w.TypeName);
        }
    }
}
