using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;
using System;

namespace SchoolManagement.Data
{
    public class Appdbcontext : IdentityDbContext<AppUser>
    {
        public Appdbcontext(DbContextOptions<Appdbcontext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<AppUser> appUsers { get; set; }
       

        public DbSet<Student> students { get; set; }       // student
        public DbSet<Standard> standards { get; set; }      //class/standards
        public DbSet<Sessionofclass> sessionclass { get; set; }  //session
        public DbSet<Feestructure> feestructures {  get; set; }     //feestructure

        public DbSet<Parent>Parents { get; set; }     // parent
        public DbSet<SchoolManagement.Models.Contact> Contact { get; set; } = default!;





       //foreign key concept in below
     


    }
}