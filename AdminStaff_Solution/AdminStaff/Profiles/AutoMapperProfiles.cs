using AdminStaff.DomainModels;
using AdminStaff.Profiles.AfterMaps;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminStaff.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DataModels.Adherent, Adherent>().ReverseMap();
            CreateMap<DataModels.Adresse, Adresse>().ReverseMap();
            CreateMap<DataModels.Gender, Gender>().ReverseMap();
            CreateMap<UpdateAdherent, DataModels.Adherent>()
                .AfterMap<UpdateAdherentAfterMaps>();
               
        }
       
    }
}
