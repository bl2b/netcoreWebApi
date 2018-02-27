using XYC.Services.Abstract.Sample;
using XYC.Domain.Context.Sample;
using System.Collections.Generic;
using XYC.Domain.Entities.Sample;
using System.Linq;

namespace XYC.Services.Concrete.Sample
{
    
    public class NorthwindRepository: INorthwindRepository
    {
        private SampleContext _context;
        public NorthwindRepository(SampleContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customer.OrderBy(c => c.CompanyName).ToList();
        }
    }
}