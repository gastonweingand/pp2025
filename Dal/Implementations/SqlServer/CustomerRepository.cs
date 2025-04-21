using Dal.Interfaces;
using Dal.Tools;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Implementations.SqlServer
{
    internal class CustomerRepository : ICustomerRepository
    {

        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Customer] (Name) VALUES (@Name)";
        }

        private string UpdateStatement
        {
            get => "UPDATE [dbo].[Customer] SET (Name = @Name) WHERE IdCustomer = @IdCustomer";
        }

        private string DeleteStatement
        {
            get => "DELETE FROM [dbo].[Customer] WHERE IdCustomer = @IdCustomer";
        }

        private string SelectOneStatement
        {
            get => "SELECT IdCustomer, Name FROM [dbo].[Customer] WHERE IdCustomer = @IdCustomer";
        }

        private string SelectAllStatement
        {
            get => "SELECT IdCustomer, Name FROM [dbo].[Customer]";
        }
        #endregion


        public void Add(Customer entity)
        {
            //SqlHelper.ExecuteScalar(this.InsertStatement,
            //    System.Data.CommandType.Text, 
            //    new System.Data.SqlClient.SqlParameter { }())
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetByCreationDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
