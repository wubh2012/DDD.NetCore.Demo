using DDD.NetCore.Domain.Bus;
using DDD.NetCore.Domain.Commands;
using DDD.NetCore.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DDD.NetCore.Domain.Repository;

namespace DDD.NetCore.Domain.CommandHandlers
{
    public class StudentCommandHandler : CommandHandler,
        IRequestHandler<RegisterStudentCommand, Unit>
    {
        private readonly IStudentRepository _studentRepository;
        public StudentCommandHandler(IStudentRepository studentRepository, IMediatorHandler bus) : base(bus)
        {
            _studentRepository = studentRepository;
        }

        public Task<Unit> Handle(RegisterStudentCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                //TODO 收集错误信息,通知给UI
                NotifyValidationErrors(request);
                return Task.FromResult(new Unit());
            }

            var student = new Student(Guid.NewGuid(), request.Name, request.Email, request.BirthDate);
            _studentRepository.Add(student);
            _studentRepository.SaveChanges();
            //TODO 提交成功后，发送邮件用户注册成功

            return Task.FromResult(new Unit());
        }
    }
}
