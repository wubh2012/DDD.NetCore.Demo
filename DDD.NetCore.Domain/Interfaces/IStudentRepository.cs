using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.NetCore.Domain.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        //
        Student GetByEmail(string email);
    }
}
