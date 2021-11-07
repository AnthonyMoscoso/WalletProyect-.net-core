using AutoMapper;
using Business.DataServices.Abstracts;
using Core.DataServices.Specifics;
using Core.Entities.Utilities.Encrypt;
using Core.Repository.Abstracts;
using Entities.DbModels.EF;
using Entities.Dto;
using FluentValidation;
using Infra.DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.DataServices.Specifics
{
    public class IngressService : DataBaseService<IngressDto, Ingress,int>, IIngressService
    {
        protected new IIngressRepository _repository;
        public IngressService(IIngressRepository repository, IMapper mapper, IValidator<IngressDto> validador, IEncrypterProfile<IngressDto> encryptor) : base(repository, mapper, validador, encryptor)
        {
            _repository = repository;
        }

        public override int  GetNewId(IngressDto entity)
        {
            IEnumerable<Ingress> list = _repository.Get(w => w.IdUser == entity.IdUser);
            int lastData = list.OrderBy(w => w.IdIngress).LastOrDefault() != null ? list.OrderBy(w => w.IdIngress).LastOrDefault().IdIngress : 0;
            string sIdUser = entity.IdUser.ToString();
            string sLastDataId = lastData.ToString();
            string idWithoutUser = lastData != 0 ? sLastDataId.Remove(0, sIdUser.Length) : 0.ToString();
            int idValue = Convert.ToInt32(idWithoutUser);
            idValue++;
            string idFormat = $"{sIdUser}{idValue}";
            return Convert.ToInt32( idFormat);
        }
    }
}
