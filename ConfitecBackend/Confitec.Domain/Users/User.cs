using Confitec.Domain.Users.Enums;
using System;

namespace Confitec.Domain.Users
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public DateTime BirthDate { get; set; }

        public EducationLevel EducationLevel { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastModified { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} - {EmailAddress}";
        }
    }
}
