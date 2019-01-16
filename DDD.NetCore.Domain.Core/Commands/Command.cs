using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.NetCore.Domain.Core.Commands
{
    public abstract class Command
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }
        protected Command()
        {
            Timestamp = DateTime.Now;
        }
        public abstract bool IsValid();
    }
}
