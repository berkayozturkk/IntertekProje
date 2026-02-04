using Intertek.Business.DTOs;
using Intertek.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intertek.Business.Interfaces
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomersAsync();
        Task<List<CustomerOrderSummaryDto>> GetTopSpendingCustomersAsync();
    }
}
