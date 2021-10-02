using Core.Entities.Utilities.EntityGenerator;
using Core.Entities.Utilities.EntityGenerator.Abstracts;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.GenerateEntityServices
{
    public  class UserGeneratorProfile : BaseGeneratorProfile<UserDto>
    {
        public UserGeneratorProfile()
        {
            RuleForParameter(w => w.ID).IsUnique().MinValue(567);
            RuleForParameter(w => w.BirthDate).DateStart(new DateTime(1990,01,01)).DateEnd(new DateTime(1992,12,31));
            RuleForParameter(w => w.Email).IsEmail().TextFormat(TextFormats.OnlyText);
            RuleForParameter(w => w.Phone).IsPhoneNumber().IsUnique();
            RuleForParameter(w => w.Username).MaxLeng(10).TextFormat(TextFormats.OnlyText).IsUnique();
            RuleForParameter(w => w.LastUpdateDate).DateStart(new DateTime(2009, 03, 04,23,55,45));
            RuleForParameter(w => w.CreateDate).DateEnd(new DateTime(2020, 02, 29));

        }
    }
}
