using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public static class ValidationTool
    {
        //IValidator=>Classımı inherit ettiğim AbstractValidator classının miras aldığı interface nesnesidir.
        //if yerine ValidationTool da ilgili classlarım için yazılan RuleFor ve class nesnesinin bağlantısını yapıp,kontrolleri sağlamasını/doğrulama yapması gereken işlemleri oluşturduk

        public static void Validate(IValidator validator,object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
