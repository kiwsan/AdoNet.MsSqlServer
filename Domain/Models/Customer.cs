using Domain.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Models
{
    public class Customer : Entity, IAggregateRoot
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        /// <summary>
        /// Validation Check
        /// </summary>
        protected override void Validate()
        {
            throw new NotImplementedException();
        }

    }
}
