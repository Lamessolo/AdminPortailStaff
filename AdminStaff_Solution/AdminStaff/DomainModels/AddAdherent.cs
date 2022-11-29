using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminStaff.DomainModels
{
    public class AddAdherent
    {
        // On met les champs qui peuvent etre modifié pour un adherent
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public long Mobile { get; set; }
        public Guid GenderId { get; set; }
        public string PhysicalAdresse { get; set; }
        public string PostalAdresse { get; set; }

    }
}
