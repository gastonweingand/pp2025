using Bll.Interfaces;
using Dal.Factory;
using Dal.Interfaces;
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
        ICustomerRepository repository = Repository.GetCustomerInstance();

        public CustomerService()
        {
            
        }

        public void Add(Customer entity)
        {
            repository.Add(entity);
        }

        public void Delete(Guid id)
        {
            repository.Delete(id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return repository.GetAll();
        }

        public Customer GetById(Guid id)
        {
            return repository.GetById(id);
        }

        public bool IsActive(Customer customer)
        {
            //Desde el negocio validar por ejemplo cuándo un cliente es activo o no?

            //Customer getCustomer = repository.GetById(customer.IdCustomer);

            //return getCustomer.Active && getCustomer.FechaAlgo < DateTime
            return false;
        }

        public void Update(Customer entity)
        {
            repository.Update(entity);
        }
    }
}
