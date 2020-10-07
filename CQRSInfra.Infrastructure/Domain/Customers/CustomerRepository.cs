using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CQRSInfra.Domain.Customers;
using CQRSInfra.Domain.Customers.Orders;
using CQRSInfra.Infrastructure.Database;
using CQRSInfra.Infrastructure.SeedWork;

namespace CQRSInfra.Infrastructure.Domain.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly OrdersContext _context;

        public CustomerRepository(OrdersContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(Customer customer)
        {
            await this._context.Customers.AddAsync(customer);
        }

        public async Task<Customer> GetByIdAsync(CustomerId id)
        {
            return await this._context.Customers
                .IncludePaths(
                    CustomerEntityTypeConfiguration.OrdersList, 
                    CustomerEntityTypeConfiguration.OrderProducts)
                .SingleAsync(x => x.Id == id);
        }
    }
}