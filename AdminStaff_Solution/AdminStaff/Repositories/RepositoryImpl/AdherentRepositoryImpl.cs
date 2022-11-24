using AdminStaff.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminStaff.Repositories.RepositoryImpl
{
    public class AdherentRepositoryImpl : IAdherentRepository
    {
        private readonly AdminStaffContext context;

        public AdherentRepositoryImpl(AdminStaffContext context)
        {
            this.context = context;
        }

        public List<Adherent> GetAdherents()
        {
            return context.Adherents.ToList();
        }
    }
}
