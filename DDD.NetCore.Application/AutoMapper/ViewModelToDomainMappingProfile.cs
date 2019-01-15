using AutoMapper;
using DDD.NetCore.Application.ViewModel;
using DDD.NetCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.NetCore.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<StudentViewModel, Student>();
        }
    }
}
