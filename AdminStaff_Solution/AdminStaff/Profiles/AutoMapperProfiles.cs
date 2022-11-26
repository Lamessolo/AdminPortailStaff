using AdminStaff.DomainModels;
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
        }
       
    }
}
