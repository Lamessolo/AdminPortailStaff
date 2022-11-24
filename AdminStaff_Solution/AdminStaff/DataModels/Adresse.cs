using System;

namespace AdminStaff.DataModels
{
    public class Adresse
    {

        public Guid Id { get; set; }

        public string PhysicalAdresse { get; set; }

        public string PostalAdresse { get; set; }

        // Navigation property 


        public Guid AdherentId { get; set; }

    }
}