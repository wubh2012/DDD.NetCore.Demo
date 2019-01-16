using DDD.NetCore.Domain.Core.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.NetCore.Domain.Core.Commands
{
    public class RegisterStudentCommand : StudentCommand
    {
        public RegisterStudentCommand(string name, string email, DateTime birthdate)
        {
            Name = name;
            Email = email;
            BirthDate = birthdate;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterStudentCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
