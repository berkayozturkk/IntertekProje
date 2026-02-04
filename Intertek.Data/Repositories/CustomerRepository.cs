using Intertek.Data.Helpers;
using Intertek.Data.Repositories.Interfaces;
using Intertek.Model.Entities;
using Intertek.Model.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intertek.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbHelper _dbHelper;

        public CustomerRepository(IDbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            try
            {
                var sql = "SELECT CustomerId, AccountNumber FROM Sales.Customer";
                var dataTable = await _dbHelper.ExecuteQueryAsync(sql);

                var customers = new List<Customer>();
                foreach (DataRow row in dataTable.Rows)
                {
                    var customer = new Customer
                    {
                        CustomerId = row["CustomerId"] != DBNull.Value ? Convert.ToInt32(row["CustomerId"]) : 0,
                        AccountNumber = row["AccountNumber"] != DBNull.Value ? row["AccountNumber"].ToString() : string.Empty
                    };
                    customers.Add(customer);
                }

                return customers;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting all customers", ex);
            }
            finally
            {
            }
        }

        public async Task<List<CustomerOrderSummary>> GetTopSpendingCustomersAsync(int topCount)
        {
            try
            {
                var sql = @"
                    SELECT TOP (@TopCount)
                        c.CustomerID AS CustomerId,
                        p.FirstName + ' ' + p.LastName AS CustomerName,
                        COUNT(soh.SalesOrderID) AS TotalOrders,
                        SUM(soh.TotalDue) AS TotalSpent,
                        AVG(soh.TotalDue) AS AvgOrderValue,
                        MAX(soh.OrderDate) AS LastOrderDate
                    FROM Sales.Customer c
                    INNER JOIN Person.Person p ON c.PersonID = p.BusinessEntityID
                    INNER JOIN Sales.SalesOrderHeader soh ON c.CustomerID = soh.CustomerID
                    WHERE p.PersonType = 'IN'
                    GROUP BY c.CustomerID, p.FirstName, p.LastName
                    HAVING COUNT(soh.SalesOrderID) > 1
                    ORDER BY TotalSpent DESC";

                var parameters = new[]
                {
                    _dbHelper.CreateParameter("@TopCount", topCount, SqlDbType.Int)
                };

                var dataTable = await _dbHelper.ExecuteQueryAsync(sql, parameters);
                return MapDataTableToCustomerOrderSummary(dataTable);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting top {topCount} spending customers", ex);
            }
        }

        private List<CustomerOrderSummary> MapDataTableToCustomerOrderSummary(DataTable dataTable)
        {
            var result = new List<CustomerOrderSummary>();

            foreach (DataRow row in dataTable.Rows)
            {
                var summary = MapDataRowToCustomerOrderSummary(row);
                result.Add(summary);
            }

            return result;
        }

        private CustomerOrderSummary MapDataRowToCustomerOrderSummary(DataRow row)
        {
            return new CustomerOrderSummary
            {
                CustomerId = row["CustomerId"] != DBNull.Value ? Convert.ToInt32(row["CustomerId"]) : 0,
                CustomerName = row["CustomerName"] != DBNull.Value ? row["CustomerName"].ToString() : string.Empty,
                TotalOrders = row["TotalOrders"] != DBNull.Value ? Convert.ToInt32(row["TotalOrders"]) : 0,
                TotalSpent = row["TotalSpent"] != DBNull.Value ? Convert.ToDecimal(row["TotalSpent"]) : 0,
                AvgOrderValue = row["AvgOrderValue"] != DBNull.Value ? Convert.ToDecimal(row["AvgOrderValue"]) : 0,
                LastOrderDate = row["LastOrderDate"] != DBNull.Value ? Convert.ToDateTime(row["LastOrderDate"]) : DateTime.MinValue
            };
        }
    }
}
