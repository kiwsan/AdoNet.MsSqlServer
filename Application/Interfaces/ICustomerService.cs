using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Interfaces
{
    public interface ICustomerService
    {

        int Add(Customer person);

        int Update(Customer person);

        int Delete(int id);

        Customer GetById(int id);

        IEnumerable<Customer> GetAll();

    }
}
