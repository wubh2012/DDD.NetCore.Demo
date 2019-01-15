using DDD.NetCore.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.NetCore.Application.Interfaces
{
    public interface IStudentAppService : IDisposable
    {
        void Register(StudentViewModel customerViewModel);
        IEnumerable<StudentViewModel> GetAll();
        StudentViewModel GetById(Guid id);
        void Update(StudentViewModel customerViewModel);
        void Remove(Guid id);
    }
}
