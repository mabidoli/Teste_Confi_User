using Confitec.Domain.Users;
using Confitec.Domain.Users.Enums;
using MediatR;
using System;

namespace Confitec.Application.Users.Commands
{
    public class CreateUserCommand : IRequest<User>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public DateTime BirthDate { get; set; }

        public EducationLevel EducationLevel { get; set; }
    }
}
