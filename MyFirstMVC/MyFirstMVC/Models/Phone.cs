﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstMVC.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public double Price { get; set; }

        public bool InStock { get; set; }

        public Company Company { get; set; }
        public int CompanyId { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public IEnumerable<PhoneOnStock> PhoneOnStocks { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}
