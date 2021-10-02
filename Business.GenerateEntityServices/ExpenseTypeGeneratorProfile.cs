using Core.Entities.Utilities.EntityGenerator;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.GenerateEntityServices
{
    public class ExpenseTypeGeneratorProfile : BaseGeneratorProfile<ExpenseTypeDto>
    {
        public ExpenseTypeGeneratorProfile()
        {
            RuleForParameter(w => w.ID).MaxValue(900).MinValue(200);
            RuleForParameter(w => w.CreateDate).DateEnd(new DateTime(1996, 12, 31)).DateStart(new DateTime(1950, 05, 24));
                }
    }
}
