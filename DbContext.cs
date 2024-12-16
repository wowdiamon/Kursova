﻿using System.Collections.Generic;
namespace MyStoreNamespace
{
    public class DbContext
    {
        public List<Account> Accounts { get; set; }
        public List<Product> Products { get; set; }
        public List<Order> Orders { get; set; }

        public DbContext()
        {
            Accounts = new List<Account>
            {
                new AdminAccount("Admin","admin123")
            };

            Products = new List<Product>
            {
                new Product("Banana", 10)
            };
            Orders = new List<Order>();
        }
    }


    
}