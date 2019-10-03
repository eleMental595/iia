using iia.contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iia.contracts.interfaces
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomersAsync();

        Task<Customer> AddCustomer(Customer productRequest);

        Task<Customer> UpdateCustomer(Customer productRequest);

        Task DeleteCustomer(int customerId);

    }
}
