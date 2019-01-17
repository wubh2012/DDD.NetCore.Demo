using DDD.NetCore.Domain.Bus;
using DDD.NetCore.Domain.Commands;
using DDD.NetCore.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.NetCore.Domain.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IMediatorHandler _bus;
        public CommandHandler(IMediatorHandler bus)
        {
            _bus = bus;
        }
        protected void NotifyValidationErrors(Command message)
        {
            List<string> errorInfo = new List<string>();
            foreach (var error in message.ValidationResult.Errors)
            {
                //将错误信息提交到事件总线，派发出去
                _bus.RaiseEvent(new DomainNotification("", error.ErrorMessage));
            }

            //将错误信息收集一：缓存方法（错误示范）
            //_cache.Set("ErrorData", errorInfo);
        }
    }
}
