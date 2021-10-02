using Core.Repository.Specifics.DBs.EF;
using Entities.DbModels.EF;
using Infra.DataAccess.Abstracts;
using Infra.DataAccess.Specifics.DBs.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.DataAccess.Specifics.DBs.EF
{
    public class IngressTypeEFRepository : EFRepository<IngressType>, IIngressTypeRepository
    {
        public IngressTypeEFRepository(WalletContext context, string identificator="IdType") : base(context, identificator)
        {
        }
    }
}
