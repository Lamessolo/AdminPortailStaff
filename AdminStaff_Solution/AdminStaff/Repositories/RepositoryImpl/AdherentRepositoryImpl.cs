using AdminStaff.DataModels;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Adherent>> GetAdherentsAsync()
        {
            return await context.Adherents.Include(nameof(Gender)).Include(nameof(Adresse)).ToListAsync();
        }
    }
}
