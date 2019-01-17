using DDD.NetCore.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.NetCore.Domain.CommandHandlers
{
    /// <summary>
    /// 领域通知处理程序，把所有的通知信息都放在事件总线中
    /// 
    /// </summary>
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {

        // 通知信息列表
        private List<DomainNotification> _notifications;
        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            _notifications.Add(notification);
            return Task.CompletedTask;
        }
        // 获取当前生命周期内的全部通知信息
        public virtual List<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        // 判断在当前总线对象周期中，是否存在通知信息
        public virtual bool HasNotifications()
        {
            return GetNotifications().Any();
        }
    }
}
