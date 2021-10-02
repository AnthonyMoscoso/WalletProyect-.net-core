using AutoMapper;
using Entities.DbModels.EF;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WalletApi.Middleware.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<Users, UserDto>().ReverseMap();
            CreateMap<Ingress, IngressDto>().ReverseMap();
            CreateMap<IngressType, IngressTypeDto>().ReverseMap();
            CreateMap<Expense, ExpenseDto>().ReverseMap();
            CreateMap<ExpenseType, ExpenseTypeDto>().ReverseMap();
           
        }
    }
}
