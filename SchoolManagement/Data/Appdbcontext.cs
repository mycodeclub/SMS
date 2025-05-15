using BpstEducation.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;
using SchoolManagement.Models.Address;
using SchoolManagement.Models.User;
using SchoolManagement.ProcModels;
using SchoolManagement.Models.Fee;

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
                    // Path to the SQL script file
        var sqlFilePath = Path.Combine(Directory.GetCurrentDirectory(), "sqlScripts", "proc_GetSessionDetailsByStandard.sql");
            // Check if the file exists
            if (File.Exists(sqlFilePath))
            {
                var sqlScript = File.ReadAllText(sqlFilePath);
                modelBuilder.HasAnnotation("Relational:ExecuteSql", sqlScript);
            }
            else
            { 
                            throw new FileNotFoundException($"SQL script file not found: {sqlFilePath}");
             }
 
            modelBuilder.SeedRoles();
            modelBuilder.SeedSession();
            modelBuilder.SeedStandard();
            modelBuilder.SeedCountry();
            modelBuilder.SeedState();
            modelBuilder.SeedCities();
            modelBuilder.SeedRelation();
            modelBuilder.SeedFeeTypeMaster();
            modelBuilder.Entity<AppUser>().ToTable("AppUser");
            modelBuilder.Entity<SessionDetailsDto>().HasNoKey();


            modelBuilder.Entity<SessionFeeMaster>()
                .HasOne(s => s.Standard)
                .WithMany() // or .WithOne() if one-to-one
                .HasForeignKey(s => s.StandardId)
                .OnDelete(DeleteBehavior.Restrict); // <== disable cascade

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<SessionYear> SessionYears { get; set; }  //session 
        public DbSet<Models.Fee.SessionFeeMaster> SessionFee { get; set; } 
        public DbSet<Student> Students { get; set; }       // student
        public DbSet<ParentOrGuardians> Parents { get; set; }     // parent
        public DbSet<Standard> Standards { get; set; }      //class/standards
        public DbSet<StudentFee> StudentFees { get; set; }     //feestructure
        public DbSet<Country> Countrys { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Relation> Relations { get; set; }
        public DbSet< Models.Fee.FeeTypeMaster> FeeTypeMaster { get; set; }
        public DbSet<SessionDetailsDto> SessionDetailsDtoRaw { get; set; }
        public DbSet<SchoolManagement.Models.Fee.SessionFeeMaster> SesionFeeMaster { get; set; } 

    }
}