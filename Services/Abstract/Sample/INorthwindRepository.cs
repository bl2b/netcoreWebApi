using System.Collections.Generic;
using XYC.Domain.Entities.Sample;

namespace XYC.Services.Abstract.Sample
{
    public interface INorthwindRepository
    {
        IEnumerable<Customer> GetCustomers();
        //IEnumerable<Customer> GetCustomer(string customerId);
    }
}