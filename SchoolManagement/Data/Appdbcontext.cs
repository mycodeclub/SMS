﻿using BpstEducation.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;
using SchoolManagement.Models.Address;
using SchoolManagement.Models.Fee;
using SchoolManagement.Models.User;
using SchoolManagement.ProcModels;

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
            modelBuilder.SeedFeeType();






            modelBuilder.SeedStandard();
            modelBuilder.SeedStandardFee();
            modelBuilder.SeedCountry();
            modelBuilder.SeedState();
            modelBuilder.SeedCities();
            modelBuilder.SeedRelation();
            modelBuilder.Entity<AppUser>().ToTable("AppUser");
            modelBuilder.Entity<SessionDetailsDto>().HasNoKey();



        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<SessionYear> SessionYears { get; set; }  //session 
        public DbSet<FeeType> FeeTypes { get; set; }
        public DbSet<Standard> Standards { get; set; }      //class/standards
        public DbSet<StandardFee> StandardFees { get; set; }

        public DbSet<Student> Students { get; set; }       // student
        public DbSet<ParentOrGuardians> Parents { get; set; }     // parent
        public DbSet<Relation> Relations { get; set; }
     
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        //---------------------------------------------------------------------

        public DbSet<SessionDetailsDto> SessionDetailsDtoRaw { get; set; }
        public DbSet<SessionFee> SessionFee { get; set; }
    }
}