using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Uow;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositorys
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IUnitOfWork uow) : base(uow) { }

        protected override void InsertCommandParameters(Customer entity, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@FirstName", entity.FirstName);
            cmd.Parameters.AddWithValue("@LastName", entity.LastName);
            cmd.Parameters.AddWithValue("@Phone", entity.Phone);
            cmd.Parameters.AddWithValue("@City", entity.City);
            cmd.Parameters.AddWithValue("@Country", entity.Country);
        }

        protected override void UpdateCommandParameters(Customer entity, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@FirstName", entity.FirstName);
            cmd.Parameters.AddWithValue("@LastName", entity.LastName);
            cmd.Parameters.AddWithValue("@Phone", entity.Phone);
            cmd.Parameters.AddWithValue("@City", entity.City);
            cmd.Parameters.AddWithValue("@Country", entity.Country);
        }

        protected override void DeleteCommandParameters(int id, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Id", id);
        }

        protected override void GetByIdCommandParameters(int id, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Id", id);
        }

        protected override Customer Map(SqlDataReader reader)
        {
            Customer objCustomer = new Customer();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    objCustomer.Id = Convert.ToInt32(reader["Id"].ToString());
                    objCustomer.FirstName = reader["FirstName"].ToString();
                    objCustomer.LastName = reader["LastName"].ToString();
                    objCustomer.Phone = reader["Phone"].ToString();
                    objCustomer.City = reader["City"].ToString();
                    objCustomer.Country = reader["Country"].ToString();
                }
            }
            return objCustomer;
        }

        protected override List<Customer> Maps(SqlDataReader reader)
        {
            List<Customer> objCustomers = new List<Customer>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Customer objCustomer = new Customer();
                    objCustomer.Id = Convert.ToInt32(reader["Id"].ToString());
                    objCustomer.FirstName = reader["FirstName"].ToString();
                    objCustomer.LastName = reader["LastName"].ToString();
                    objCustomer.Phone = reader["Phone"].ToString();
                    objCustomer.City = reader["City"].ToString();
                    objCustomer.Country = reader["Country"].ToString();
                    objCustomers.Add(objCustomer);
                }
            }
            return objCustomers;
        }

    }
}
