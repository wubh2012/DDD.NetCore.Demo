using DDD.NetCore.Domain.Core.Models;
using System;

namespace DDD.NetCore.Domain
{
    public class Student : Entity
    {

        protected Student() { }

        public Student(Guid id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Address = new Address();
        }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        /// <summary>
        /// 户籍
        /// </summary>
        public Address Address { get; private set; }
    }
}
