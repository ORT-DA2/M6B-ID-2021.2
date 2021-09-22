using System;
using System.Collections.Generic;

namespace Domain
{
    public class Restaurant
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public int OwnerId { get; set; }
        public User Owner { get; set; }

        public List<Product> Products { get; set; }

        public void Validate()
        {
            if (this.Id != 0)
            {
                throw new InvalidOperationException("The Id must be 0");
            }

            if (String.IsNullOrEmpty(this.Name))
            {
                throw new InvalidOperationException("The Name can't be null or empty");
            }

            if (String.IsNullOrEmpty(this.Address))
            {
                throw new InvalidOperationException("The Address can't be null or empty");
            }

            if (this.OwnerId == 0)
            {
                throw new ArgumentNullException("The Owner can't be null");
            }
        }
    }
}
