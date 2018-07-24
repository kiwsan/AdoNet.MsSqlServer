using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Uow;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class CustomerService : ICustomerService
    {

        private ICustomerRepository _customerRepository;
        private IUnitOfWork _unitOfWork;

        public CustomerService(ICustomerRepository repository, IUnitOfWork uow)
        {
            _customerRepository = repository;
            _unitOfWork = uow;
        }

        public int Add(Customer customer)
        {
            int i = 0;
            try
            {
                // _unitOfWork.BeginTransaction();
                SqlTransaction sqlTransaction = _unitOfWork.BeginTransaction();
                string strSql = "Insert into Customer (FirstName, LastName, City, Country, Phone) VALUES (@FirstName, @LastName, @City, @Country, @Phone)";
                i = _customerRepository.Insert(customer, strSql, sqlTransaction);

                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return i;
        }

        public int Update(Customer customer)
        {
            int i = 0;
            try
            {
                SqlTransaction sqlTransaction = _unitOfWork.BeginTransaction();
                string strSql = "Update Customer set FirstName = @FirstName, LastName = @LastName, City = @City, Country = @Country, Phone = @Phone Where Id = @Id";
                i = _customerRepository.Update(customer, strSql, sqlTransaction);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return i;
        }

        public int Delete(int id)
        {
            int i = 0;
            try
            {
                SqlTransaction sqlTransaction = _unitOfWork.BeginTransaction();
                string strSql = "Delete from Customer Where Id = @Id";
                i = _customerRepository.Delete(id, strSql, sqlTransaction);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return i;
        }

        public Customer GetById(int id)
        {
            string strSql = "select * from dbo.Customer where id = @id";
            return _customerRepository.GetById(id, strSql);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customerRepository.GetAll("SELECT * FROM Customer");
        }

    }
}
