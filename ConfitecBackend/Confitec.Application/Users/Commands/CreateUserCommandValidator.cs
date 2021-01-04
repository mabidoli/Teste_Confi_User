using FluentValidation;
using System;

namespace Confitec.Application.Users.Commands
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            {
                RuleFor(v => v.FirstName)
                    .MaximumLength(50)
                    .NotNull()
                    .NotEmpty();

                RuleFor(v => v.LastName)
                    .MaximumLength(200)
                    .NotNull()
                    .NotEmpty();

                RuleFor(v => v.EmailAddress)
                    .EmailAddress()
                    .NotNull()
                    .NotEmpty();

                RuleFor(v => v.BirthDate)
                    .LessThan(DateTime.Now.Date);

                RuleFor(v => v.EducationLevel)
                    .IsInEnum();
            }
        }
    }
}
