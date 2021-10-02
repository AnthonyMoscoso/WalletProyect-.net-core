using Core.Entities.Utilities.Encrypt;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.EncryptServices.Profiles
{
    public class UserEncrypterProfile : BaseEncryterProfile<UserDto>
    {
        public UserEncrypterProfile(IEncrypt encrypt) : base(encrypt)
        {
            AddParameter(w => w.Password);
            AddParameter(w => w.Phone);
            AddParameter(w=> w.Email);
        }
         

    }
}
