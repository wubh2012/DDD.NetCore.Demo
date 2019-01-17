using DDD.NetCore.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.NetCore.Domain.Core.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IMediatorHandler _bus;
        public CommandHandler(IMediatorHandler bus)
        {
            _bus = bus;
        }

    }
}
