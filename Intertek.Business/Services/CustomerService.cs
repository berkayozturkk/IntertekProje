using Intertek.Business.DTOs;
using Intertek.Business.Interfaces;
using Intertek.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intertek.Business.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly Data.Repositories.Interfaces.ICustomerRepository _customerRepository;

        public CustomerService(Data.Repositories.Interfaces.ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<List<Customer>> GetAllCustomersAsync()
        {
            return _customerRepository.GetAllCustomersAsync();
        }

        public async Task<List<CustomerOrderSummaryDto>> GetTopSpendingCustomersAsync()
        {
            var customerEntities = await _customerRepository.GetTopSpendingCustomersAsync(1000);

            var customerDtos = customerEntities.Select(c => new CustomerOrderSummaryDto
            {
                CustomerId = c.CustomerId,
                CustomerName = c.CustomerName,
                TotalOrders = c.TotalOrders,
                TotalSpent = c.TotalSpent,
                AvgOrderValue = c.AvgOrderValue,
                LastOrderDate = c.LastOrderDate
            }).ToList();

            return customerDtos;
        }
    }
}
