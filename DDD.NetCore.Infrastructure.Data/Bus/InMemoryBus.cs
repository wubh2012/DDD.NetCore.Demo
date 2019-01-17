using DDD.NetCore.Domain.Bus;
using DDD.NetCore.Domain.Commands;
using DDD.NetCore.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDD.NetCore.Infrastructure.Data.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        //构造函数注入
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            // MediatR 中介者的第二种方式，发布订阅模式
            return _mediator.Publish(@event);
        }

        /// <summary>
        /// 实现我们在IMediatorHandler中定义的接口
        /// 没有返回值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        public Task SendCommand<T>(T command) where T : Command
        {
            //MediatR 的第一种方式，请求响应方式
            return _mediator.Send(command);//这里要注意下 command 对象
        }
    }
}
