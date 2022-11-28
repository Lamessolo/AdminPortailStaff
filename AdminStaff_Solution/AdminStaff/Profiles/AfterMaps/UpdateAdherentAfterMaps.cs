using AdminStaff.DomainModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminStaff.Profiles.AfterMaps
{
    public class UpdateAdherentAfterMaps : IMappingAction<UpdateAdherent, DataModels.Adherent>
    {
        public void Process(UpdateAdherent source, DataModels.Adherent destination, ResolutionContext context)
        {
            destination.Adresse = new DataModels.Adresse()
            {
                PhysicalAdresse = source.PhysicalAdresse,
                PostalAdresse = source.PostalAdresse
            };
        }
    }
}
