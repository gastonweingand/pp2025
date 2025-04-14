using Bll.Interfaces;
using Dal.Factory;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Services
{
    public class CustomerService : ICustomerService
    {
        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            return Repository.GetCustomerInstance().GetAll();
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsActive(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
