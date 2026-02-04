using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intertek.Business.DTOs
{
    public class CustomerOrderSummaryDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int TotalOrders { get; set; }
        public decimal TotalSpent { get; set; }
        public decimal AvgOrderValue { get; set; }
        public DateTime LastOrderDate { get; set; }
    }
}
