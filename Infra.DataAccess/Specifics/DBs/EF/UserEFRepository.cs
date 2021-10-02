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
    public class UserEFRepository : EFRepository<Users>, IUserRepository
    {
        public UserEFRepository(WalletContext context, string identificator="IdUser") : base(context, identificator)
        {
        }
    }
}
