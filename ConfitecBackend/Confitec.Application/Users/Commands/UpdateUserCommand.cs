using MediatR;
using System;

namespace Confitec.Application.Users.Commands
{
    public class UpdateUserCommand : IRequest<int>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; }

        public DateTime BirthDate { get; set; }

        public int EducationLevel { get; set; }
    }
}
