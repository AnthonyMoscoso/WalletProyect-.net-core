using Core.Entities.Utilities.Encrypt;
using Entities.DbModels.EF;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.EncryptServices.Profiles
{
    public class ExpenseTypeEncrypterProfile : BaseEncryterProfile<ExpenseTypeDto>
    {
        public ExpenseTypeEncrypterProfile(IEncrypt encrypt) : base(encrypt)
        {
           // AddParameter(w => w.TypeName);
        }
    }
}
