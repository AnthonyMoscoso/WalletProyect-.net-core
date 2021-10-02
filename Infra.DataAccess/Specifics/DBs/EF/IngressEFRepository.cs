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
    public class IngressEFRepository : EFRepository<Ingress>, IIngressRepository
    {
        public IngressEFRepository(WalletContext context, string identificator="IdIngress") : base(context, identificator)
        {
            _context = context;
        }
    }
}
