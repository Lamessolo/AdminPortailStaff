using Microsoft.EntityFrameworkCore;


namespace AdminStaff.DataModels
{
    public class AdminStaffContext :DbContext
    {

        public AdminStaffContext(DbContextOptions<AdminStaffContext> options):base (options)
        {

        }

        public DbSet<Adherent> Adherents { get; set; }

        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<Gender> Genders { get; set; }

    }
}
