using Microsoft.EntityFrameworkCore;
using ParkyApi.Models;

namespace ParkyApi.Data
{
    public class EFContext:DbContext
    {
        public EFContext(DbContextOptions<EFContext> options):base(options)
        {

        }

        public DbSet<NationalParks> NationalParks { get; set; }
    }
}
