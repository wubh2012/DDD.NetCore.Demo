using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.NetCore.Domain.Repository
{
    public interface IStudentRepository : IRepository<Student>
    {
        //
        Student GetByEmail(string email);
    }
}
