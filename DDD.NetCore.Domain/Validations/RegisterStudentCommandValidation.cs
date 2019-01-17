using DDD.NetCore.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.NetCore.Domain.Validations
{
    public class RegisterStudentCommandValidation : StudentValidation<RegisterStudentCommand>
    {
        public RegisterStudentCommandValidation()
        {
            ValidateName();//验证姓名
            ValidateBirthDate();//验证年龄
            ValidateEmail();//验证邮箱
            
            //可以自定义增加新的验证
        }
    }
}
