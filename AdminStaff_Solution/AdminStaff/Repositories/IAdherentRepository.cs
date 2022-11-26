using AdminStaff.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminStaff.Repositories
{
 public   interface IAdherentRepository
    {
         Task <List<Adherent>> GetAdherentsAsync();


    }
}
