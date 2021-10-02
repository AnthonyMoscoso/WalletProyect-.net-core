using Core.Entities.Utilities.Encrypt;
using Entities.DbModels.EF;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.EncryptServices.Profiles
{
    public class ExpenseEncrypterProfile : BaseEncryterProfile<ExpenseDto>
    {
        public ExpenseEncrypterProfile(IEncrypt encrypt) : base(encrypt)
        {
          //  AddParameter(w=> w.Tittle);
        }
    }
}
