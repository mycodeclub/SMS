using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

namespace BpstEducation.Data
{
    public static class ModelBuilderExtention
    {
        public static void SeedRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(

               new IdentityRole() { Id = "1", Name = "Staff", NormalizedName = "STAFF", ConcurrencyStamp = "1" }
               );
        }
    }
}