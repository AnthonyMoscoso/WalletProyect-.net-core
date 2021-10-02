using Core.Entities.Utilities.EntityGenerator;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.GenerateEntityServices
{
    public class IngressTypeGeneratorProfile : BaseGeneratorProfile<IngressTypeDto>
    {
        public IngressTypeGeneratorProfile()
        {
            RuleForParameter(w => w.CreateDate).DateEnd(new DateTime(2190, 12, 31)).DateStart(new DateTime(1985, 02, 10));
            RuleForParameter(w => w.TypeName).MaxLeng(8).TextFormat(Core.Entities.Utilities.EntityGenerator.Abstracts.TextFormats.OnlyText);
            RuleForParameter(w => w.TypeDescription).MinLeng(12).MaxLeng(700).TextFormat(Core.Entities.Utilities.EntityGenerator.Abstracts.TextFormats.OnlyNums);
        }
    }
}
