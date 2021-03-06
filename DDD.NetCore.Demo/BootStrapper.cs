﻿using AutoMapper;
using DDD.NetCore.Application.AutoMapper;
using DDD.NetCore.Application.Services;
using DDD.NetCore.Application.Services.Impl;
using DDD.NetCore.Domain.Bus;
using DDD.NetCore.Domain.CommandHandlers;
using DDD.NetCore.Domain.Commands;
using DDD.NetCore.Domain.Events;
using DDD.NetCore.Domain.Repository;
using DDD.NetCore.Infrastructure.Data.Bus;
using DDD.NetCore.Infrastructure.Data.Context;
using DDD.NetCore.Infrastructure.Data.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.NetCore.UI
{
    public static class BootStrapper
    {
        public static void RegistetServices(IServiceCollection services)
        {
            /*
             * 添加依赖注入
             */

            // 应用层注入
            services.AddScoped<IStudentAppService, StudentAppService>();

            //命令总线
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            //领域通知
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            //领域事件
            services.AddScoped<IRequestHandler<RegisterStudentCommand, Unit>, StudentCommandHandler>();


            // 注入基础架构层
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<StudyContext>();

        }
    }

    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // 需要添加扩展 AutoMapper.Extensions.Microsoft.DependencyInjection
            //方式一：

            services.AddAutoMapper();
            AutoMapperConfig.RegisterMappings();
            // 使用
            // .ProjectTo<MentionUserDto>(_mapper.ConfigurationProvider)

        }
    }
}
