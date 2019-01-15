using DDD.NetCore.Application.ViewModel;
using DDD.NetCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace DDD.NetCore.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Student, StudentViewModel>();
        }
    }
}
