using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminStaff.DomainModels
{
    public class Adresse
    {

        public Guid Id { get; set; }

        public string PhysicalAdresse { get; set; }

        public string PostalAdresse { get; set; }
    
        public Guid AdherentId { get; set; }
    }
}
