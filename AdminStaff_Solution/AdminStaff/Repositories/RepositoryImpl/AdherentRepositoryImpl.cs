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

        public async Task<Adherent> GetAdherentByIdAsync(Guid adherentId)
        {
            return await context.Adherents.Include(nameof(Gender)).Include(nameof(Adresse))
                .FirstOrDefaultAsync(x=> x.Id == adherentId);
        }

        public async Task<List<Gender>> GetGendersAsync()
        {
            return await context.Genders.ToListAsync();
        }

        public async Task<bool> Exists(Guid adherentId)
        {
            return await context.Adherents.AnyAsync(x => x.Id == adherentId);
        }

        public async Task<Adherent> UpdateAdherent(Guid adherentId, Adherent adherentUpdated)
        {
            var adherentExisting = await GetAdherentByIdAsync(adherentId);
            if(adherentExisting != null)
            {
                adherentExisting.FirstName = adherentUpdated.FirstName;
                adherentExisting.LastName = adherentUpdated.LastName;
                adherentExisting.DateOfBirth = adherentUpdated.DateOfBirth;
                adherentExisting.Email = adherentUpdated.Email;
                adherentExisting.GenderId = adherentUpdated.GenderId;
                adherentExisting.Mobile = adherentUpdated.Mobile;
                adherentExisting.Adresse.PhysicalAdresse= adherentUpdated.Adresse.PhysicalAdresse;
                adherentExisting.Adresse.PostalAdresse = adherentUpdated.Adresse.PostalAdresse;

                await context.SaveChangesAsync();
                return adherentExisting;
            }

            return null;
        }

        public async  Task<Adherent> AddAdherent(Adherent adherentAdd)
        {
            var adherent = await context.Adherents.AddAsync(adherentAdd);
            await context.SaveChangesAsync();
            return adherent.Entity;
        }
    }
}
