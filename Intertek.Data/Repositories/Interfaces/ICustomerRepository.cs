using Intertek.Model.Entities;
using Intertek.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intertek.Data.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomersAsync();
        Task<List<CustomerOrderSummary>> GetTopSpendingCustomersAsync(int topCount);
    }
}
