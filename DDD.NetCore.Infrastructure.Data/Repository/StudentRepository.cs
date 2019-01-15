using DDD.NetCore.Domain;
using DDD.NetCore.Domain.Repository;
using DDD.NetCore.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.NetCore.Infrastructure.Data.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(StudyContext context) : base(context)
        {
        }

        public Student GetByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
