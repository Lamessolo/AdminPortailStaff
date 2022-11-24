using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminStaff.DataModels
{
    public class Adherent
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }

        public string ProfileImage { get; set; }

        public long Mobile { get; set; }

        public Guid GenderId { get; set; }

        // Navigation properties

        public Gender Gender { get; set; }
        public Adresse Adresse { get; set; }
    }
}
