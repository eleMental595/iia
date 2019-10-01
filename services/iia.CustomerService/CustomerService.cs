using iia.contracts.interfaces;
using iia.contracts.Models;
using iia.DataService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iia.CategoryService
{
    public class CustomerService : ICustomerService
    {
        private IDataService _dataService;

        public CustomerService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<Customer> AddCustomer(Customer customerRequest)
        {
            var result = await _dataService.GetResults<EntityEntry<Customer>>(async (dataContext) =>
            {
                var NewCustomer = await dataContext.Customers.AddAsync(customerRequest);
                await dataContext.SaveChangesAsync();
                return NewCustomer;
            });

            return result.Entity;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _dataService.GetResults<List<Customer>>(async (dataContext) =>
             {
                 return await dataContext.Customers.ToListAsync();
             });
        }

        public async Task<Customer> UpdateCustomer(Customer customerRequest)
        {
            var result = await _dataService.GetResults<EntityEntry<Customer>>(async (dataContext) =>
            {
                var entity = await dataContext.Customers.FindAsync(customerRequest.Id);
                if (entity != null)
                {
                    entity = customerRequest;
                    var updatedCustomer = dataContext.Customers.Update(entity);
                    await dataContext.SaveChangesAsync();
                    return updatedCustomer;
                }
                else
                {
                    throw new Exception("Record not found");
                }
            });

            return result.Entity;
        }

        public async Task DeleteCustomer(int Id)
        {
            var result = await _dataService.GetResults<EntityEntry<Customer>>(async (dataContext) =>
            {
                Customer CustomerToDelete = new Customer() { Id = Id };
                dataContext.Customers.Attach(CustomerToDelete);
                var DeletedCustomer = dataContext.Customers.Remove(CustomerToDelete);
                await dataContext.SaveChangesAsync();
                return DeletedCustomer;
            });
        }


    }
}
