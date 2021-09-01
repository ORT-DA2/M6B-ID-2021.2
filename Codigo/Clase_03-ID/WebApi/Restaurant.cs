using System;
using System.Collections.Generic;

namespace WebApi
{
    public class Restaurant
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public List<Product> Products { get; set; }
    }
}
