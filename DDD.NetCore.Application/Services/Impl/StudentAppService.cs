using AutoMapper;
using AutoMapper.QueryableExtensions;
using DDD.NetCore.Application.Services;
using DDD.NetCore.Application.ViewModel;
using DDD.NetCore.Domain;
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

        public StudentAppService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
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
            _studentRepository.Add(_mapper.Map<Student>(studentViewModel));
            _studentRepository.SaveChanges();

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
