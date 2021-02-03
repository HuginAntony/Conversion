using Conversion.DataAccess.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Conversion.DataAccess
{
    public class ConversionDbContext : IdentityDbContext<ApplicationUser>
    {
        public ConversionDbContext()
        {
            
        }

        public ConversionDbContext(DbContextOptions<ConversionDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}