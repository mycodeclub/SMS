using BpstEducation.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;
using SchoolManagement.Models.Address;
using SchoolManagement.Models.User;

namespace SchoolManagement.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedRoles();
            modelBuilder.SeedSession();
            modelBuilder.SeedStandard();
            modelBuilder.SeedCountry();
            modelBuilder.SeedState();
            modelBuilder.SeedCities();
            modelBuilder.SeedRelation();
             modelBuilder.SeedFeeTypeMaster();
             modelBuilder.Entity<AppUser>().ToTable("AppUser");

         }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<SessionYear> SessionYears { get; set; }  //session 
        public DbSet<Student> Students { get; set; }       // student
        public DbSet<ParentOrGuardians> Parents { get; set; }     // parent
        public DbSet<Standard> Standards { get; set; }      //class/standards
        public DbSet<StudentFee> StudentFees { get; set; }     //feestructure
        public DbSet<Country> Countrys { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<StaffNewModel> StaffNewModels { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Relation> Relations { get; set; }
        public DbSet<SchoolManagement.Models.Fee.FeeTypeMaster> FeeTypeMaster { get; set; } = default!;
    }
}