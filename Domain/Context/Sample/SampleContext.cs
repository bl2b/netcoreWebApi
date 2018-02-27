using Microsoft.EntityFrameworkCore;
using XYC.Domain.Entities.Sample;

namespace XYC.Domain.Context.Sample
{
    public class SampleContext: DbContext
    {
        public SampleContext(DbContextOptions<SampleContext> options)
           : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // add your own confguration here
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        }
        
        public DbSet<Customer> Customer { get; set; }
    }
}