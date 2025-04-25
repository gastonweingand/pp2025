using Dal.Interfaces;
using Dal.Tools;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dal.Implementations.SqlServer.Adapters;

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

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            List<Customer> listCustomers = new List<Customer>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SelectAllStatement,
                                                    CommandType.Text, 
                                                    new SqlParameter[] { }))
            {

                //Mientras tenga un registro para la lectura...avanzo
                while (reader.Read())
                {
                    //Leemos cada tupla de la tabla
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                                        
                    Customer customer = CustomerAdapter.Current.Get(data);
                    listCustomers.Add(customer);
                }
            }

            return listCustomers;
        }

        public IEnumerable<Customer> GetByCreationDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Customer GetById(Guid id)
        {
            Customer customer = default;

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SelectOneStatement,
                                                 CommandType.Text,
                                                 new SqlParameter[] { 
                                                     new SqlParameter("@IdCustomer", id) }))
            {

                //Hacemos la lectura de un solo registro
                if (reader.Read())
                {
                    //Leemos cada tupla de la tabla
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    customer = CustomerAdapter.Current.Get(data);
                }
            }

            return customer;
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
