using Application.Interfaces;
using Autofac;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitTestProject.Startup;

namespace UnitTestProject.Services
{

    [TestFixture]
    public class CustomerServiceNUnitTest : NUnitTestBase
    {

        [Test]
        public void GetAll_Test()
        {

            var customerService = _container.Resolve<ICustomerService>();

            var objCostomers = customerService.GetAll();

            Assert.IsNotNull(objCostomers);

            foreach (var objCostomer in objCostomers)
            {

                Console.WriteLine($"FirstName: {objCostomer.FirstName}");
                Console.WriteLine($"LastName: {objCostomer.LastName}");
                Console.WriteLine($"Phone: {objCostomer.Phone}");
                Console.WriteLine($"City: {objCostomer.City}");
                Console.WriteLine($"Country: {objCostomer.Country}");
                Console.WriteLine("-------------------------------");
            }
        }

        [TestCase(1)]
        public void GetById_Test(int id)
        {

            var customerService = _container.Resolve<ICustomerService>();

            var objCostomer = customerService.GetById(id);

            Assert.IsNotNull(objCostomer);

            Console.WriteLine($"FirstName: {objCostomer.FirstName}");
            Console.WriteLine($"LastName: {objCostomer.LastName}");
            Console.WriteLine($"Phone: {objCostomer.Phone}");
            Console.WriteLine($"City: {objCostomer.City}");
            Console.WriteLine($"Country: {objCostomer.Country}");
            Console.WriteLine("-------------------------------");
        }

    }
}
