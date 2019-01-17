using DDD.NetCore.Domain.CommandHandlers;
using DDD.NetCore.Domain.Events;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.NetCore.UI.ViewComponents
{
    /// <summary>
    /// 自定义错误显示组件
    /// </summary>
    public class AlertsViewComponent : ViewComponent
    {

        private readonly DomainNotificationHandler _notifications;

        // 构造函数注入
        public AlertsViewComponent(INotificationHandler<DomainNotification> notifications)
        {
            //_cache = cache;
            _notifications = (DomainNotificationHandler)notifications;
        }

        /// <summary>
        /// Alerts 视图组件
        /// 可以异步，也可以同步，注意方法名称，同步的时候是Invoke
        /// 我写异步是为了为以后做准备
        /// </summary>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //老版本
            //var notificacoes = await Task.Run(() => (List<string>)ViewBag.ErrorData);
            ////遍历错误信息，赋值给 ViewData.ModelState
            //notificacoes?.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c));
            //return View();

            // 从通知处理程序中，获取全部通知信息，并返回给前台
            var notificacoes = await Task.FromResult((_notifications.GetNotifications()));
            notificacoes.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c.Value));
            return View();
        }

    }
}
