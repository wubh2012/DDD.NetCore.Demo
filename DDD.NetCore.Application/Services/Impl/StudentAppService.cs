using AutoMapper;
using AutoMapper.QueryableExtensions;
using DDD.NetCore.Application.Services;
using DDD.NetCore.Application.ViewModel;
using DDD.NetCore.Domain;
using DDD.NetCore.Domain.Bus;
using DDD.NetCore.Domain.Commands;
using DDD.NetCore.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.NetCore.Application.Services.Impl
{
    public class StudentAppService : IStudentAppService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler Bus;

        public StudentAppService(IStudentRepository studentRepository, IMapper mapper, IMediatorHandler bus)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            Bus = bus;
        }


        public IEnumerable<StudentViewModel> GetAll()
        {
            return _studentRepository.GetAll().ProjectTo<StudentViewModel>(_mapper.ConfigurationProvider).ToList();
        }

        public StudentViewModel GetById(Guid id)
        {
            return _mapper.Map<StudentViewModel>(_studentRepository.GetById(id));
        }

        public void Register(StudentViewModel studentViewModel)
        {

            //RegisterStudentCommand registerStudentCommand = new RegisterStudentCommand(studentViewModel.Name, studentViewModel.Email, studentViewModel.BirthDate);
            //// 如果命令无效，证明有错误
            //if (!registerStudentCommand.IsValid())
            //{
            //    List<string> errorInfo = new List<string>();
            //    //获取到错误，请思考这个Result从哪里来的 
            //    foreach (var error in registerStudentCommand.ValidationResult.Errors)
            //    {
            //        errorInfo.Add(error.ErrorMessage);
            //    }
            //    //对错误进行记录，还需要抛给前台
            //}
            //_studentRepository.Add(_mapper.Map<Student>(studentViewModel));
            //_studentRepository.SaveChanges();


            var registerCommand = _mapper.Map<RegisterStudentCommand>(studentViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Remove(Guid id)
        {
            _studentRepository.Remove(id);
            _studentRepository.SaveChanges();
        }

        public void Update(StudentViewModel studentViewModel)
        {
            _studentRepository.Update(_mapper.Map<Student>(studentViewModel));
            _studentRepository.SaveChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
