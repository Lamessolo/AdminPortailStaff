using AdminStaff.DomainModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminStaff.Profiles.AfterMaps
{
    public class AddAdherentAfterMaps : IMappingAction<AddAdherent, DataModels.Adherent>
    {
        public void Process(AddAdherent source, DataModels.Adherent destination, ResolutionContext context)
        {
            destination.Id = Guid.NewGuid();
            destination.Adresse = new DataModels.Adresse()
            {
                Id = new Guid(),
                PhysicalAdresse = source.PhysicalAdresse,
                PostalAdresse = source.PostalAdresse
                

            };
        }
    }
}
