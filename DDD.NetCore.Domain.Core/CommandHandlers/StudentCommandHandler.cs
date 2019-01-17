using DDD.NetCore.Domain.Core.Bus;
using DDD.NetCore.Domain.Core.Commands;
using DDD.NetCore.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.NetCore.Domain.Core.CommandHandlers
{
    public class StudentCommandHandler : CommandHandler,
        IRequestHandler<RegisterStudentCommand, Unit>
    {
        public StudentCommandHandler(IMediatorHandler bus) : base(bus)
        {
        }

        public Task<Unit> Handle(RegisterStudentCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                //收集错误信息,通知给UI
            }
            var student = new Student(Guid.NewGuid(), request.Name, request.Email, request.BirthDate);
            throw new NotImplementedException();
        }
    }
}
