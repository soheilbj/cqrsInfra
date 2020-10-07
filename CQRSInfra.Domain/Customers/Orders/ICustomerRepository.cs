﻿using System.Threading.Tasks;

namespace CQRSInfra.Domain.Customers.Orders
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(CustomerId id);

        Task AddAsync(Customer customer);
    }
}