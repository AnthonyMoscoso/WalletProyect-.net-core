using Core.DataServices.Abstracts;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DataServices.Abstracts
{
    public interface IIngressService : IDataService<IngressDto,int>
    {
    }
}
