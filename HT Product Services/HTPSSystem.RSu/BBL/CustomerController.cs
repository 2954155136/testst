using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region
using HTPSSystem.RSu.DAL;
using HTPSSystem.RSu.Data.Entities;
#endregion
namespace HTPSSystem.RSu.BBL
{
    public class CustomerController
    {
        public List<Customer> Customer_List()
        {
            using (var context = new HTPSContext())
            {
                return context.Customers.ToList();
            }

        }
        public Customer Customer_Find(int customerid)
        {
            using (var context = new HTPSContext())
            {
                return context.Customers.Find(customerid);
            }
        }
        public int Customer_Add(Customer newcustomer)
        {
            using (var context = new HTPSContext())
            {
                context.Customers.Add(newcustomer);
                context.SaveChanges();
                return newcustomer.CustomerID;
            }
        }
      
    }
}
