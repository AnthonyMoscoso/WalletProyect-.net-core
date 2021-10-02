using Core.Repository.Abstracts;
using Entities.DbModels.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.DataAccess.Abstracts
{
    public interface IUserRepository : IRepository<Users>
    {
        
    }
}
