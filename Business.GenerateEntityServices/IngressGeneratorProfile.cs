using Core.Entities.Utilities.EntityGenerator;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.GenerateEntityServices
{
    public class IngressGeneratorProfile : BaseGeneratorProfile<IngressDto>
    {
        public IngressGeneratorProfile()
        {
            RuleForParameter(w => w.Quantity).MinValue(0);
            RuleForParameter(w => w.Tittle).TextFormat(Core.Entities.Utilities.EntityGenerator.Abstracts.TextFormats.OnlyText);
            RuleForParameter(w => w.CreateDate).DateStart(DateTime.Now);
            RuleForParameter(w => w.LastUpdateDate).DateStart(DateTime.Now);
            RuleForParameter(w => w.IngressDate).DateStart(DateTime.Now);
        }
    }
}
