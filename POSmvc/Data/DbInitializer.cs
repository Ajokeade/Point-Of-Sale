using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POSmvc.Models;

namespace POSmvc.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PosContext context)
        {
            context.Database.EnsureCreated();

            // Look for any customer.
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }
            // initialize customers
            var customers = new Customer[]
            {
                new Customer{FirstName="Adebayo", LastName="Salami", Email="Adebayo23@yahoo.com", PhoneNo= "08065748934"},
                new Customer{FirstName="Friday", LastName="Ayelumelo", Email="FriAyelo@yahoo.com", PhoneNo= "07045693443"},
                new Customer{FirstName="John", LastName="Badeyo", Email="Johndeyo@gmail.com", PhoneNo= "08065748934"}
            };

            foreach (Customer c in customers)
            {
                context.Customers.Add(c);
            }
            context.SaveChanges();

            // initialize categories
            var categories = new Category[]
            {
                new Category{Name="Fruits", Description="Natural fruits"},
                new Category{Name="Soft Drinks", Description="Non Alcoholic Drinks "},
                new Category{Name="Baby Items", Description="Items for babies below 12years"},
                new Category{Name="Food", Description="common food items"},
            };
            foreach (Category c in categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();

            // initialize Products
            var products = new Product[]
            {
                new Product{ Name="Banana", Price=200, QuantityAvailable=50,
                CategoryID=categories.Single(c=>c.Name=="Fruits").ID},

                new Product{ Name="Apple", Price=100, QuantityAvailable=25,
                CategoryID=categories.Single(c=>c.Name=="Fruits").ID},

                new Product{ Name="Maltina", Price=200, QuantityAvailable=70,
                CategoryID=categories.Single(c=>c.Name=="Soft Drinks").ID},

                new Product{ Name="Straberry", Price=500, QuantityAvailable=60,
                CategoryID=categories.Single(c=>c.Name=="Fruits").ID},

                new Product{ Name="Rice", Price=15000, QuantityAvailable=10,
                CategoryID=categories.Single(c=>c.Name=="Food").ID},

                new Product{ Name="Pampers", Price=1500, QuantityAvailable=40,
                CategoryID=categories.Single(c=>c.Name=="Baby Items").ID},


            };
            foreach (Product p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();
            // initialize Sales
            //var sales = new Sales[]
            //{
            //    new Sales{CustomerID=customers.Single(c=>c.LastName=="Salami").ID, TotalAmount=3000,AmountPaid=3000,Balance=0, TransctionID=101, TranscationDate=DateTime.Parse("2019-03-03") },
            //    new Sales{CustomerID=customers.Single(c=>c.LastName=="Ayelumelo").ID, TotalAmount=33500,AmountPaid=33000,Balance=500,TransctionID=102,TranscationDate= DateTime.Parse("2019-05-06") },

            //   new Sales{CustomerID=customers.Single(c=>c.LastName=="Salami").ID, TotalAmount=1000,AmountPaid=1000,Balance=0,TransctionID=103, TranscationDate=DateTime.Parse("2019-02-27") },

            //};
            //foreach(Sales s in sales)
            //{
            //    context.Sales.Add(s);
            //}
            //context.SaveChanges();
            //// initialize salesDetails
            //var salesDetails = new SalesDetail[]
            //{
            //    new SalesDetail{ProductID=products.Single(p=>p.Name=="Banana").ID, QuantityPurchased=5, SubTotal=1000,
            //    SalesID= sales.Single(s=>s.TransctionID==101).ID, DatePurchased=DateTime.Parse("2019-03-03")},
            //    new SalesDetail{ProductID=products.Single(p=>p.Name=="Apple").ID, QuantityPurchased=5, SubTotal=500,
            //    SalesID= sales.Single(s=>s.TransctionID==101).ID,DatePurchased= DateTime.Parse("2019-03-03")},
            //    new SalesDetail{ProductID=products.Single(p=>p.Name=="Pampers").ID, QuantityPurchased=1, SubTotal=1500,
            //    SalesID= sales.Single(s=>s.TransctionID==101).ID, DatePurchased=DateTime.Parse("2019-03-03")},

            //    new SalesDetail{ProductID=products.Single(p=>p.Name=="Rice").ID, QuantityPurchased=2, SubTotal=30000,
            //    SalesID= sales.Single(s=>s.TransctionID==102).ID, DatePurchased=DateTime.Parse("2019-05-06") },
            //    new SalesDetail{ProductID=products.Single(p=>p.Name=="Straberry").ID, QuantityPurchased=4, SubTotal=2000,
            //    SalesID= sales.Single(s=>s.TransctionID==102).ID, DatePurchased=DateTime.Parse("2019-05-06")},
            //    new SalesDetail{ProductID=products.Single(p=>p.Name=="Pampers").ID, QuantityPurchased=1, SubTotal=1500,
            //    SalesID= sales.Single(s=>s.TransctionID==102).ID, DatePurchased=DateTime.Parse("2019-05-06")},

            //     new SalesDetail{ProductID=products.Single(p=>p.Name=="Maltina").ID, QuantityPurchased=5, SubTotal=1000,
            //    SalesID= sales.Single(s=>s.TransctionID==103).ID, DatePurchased=DateTime.Parse("2019-02-27")},

            //};

            //foreach(SalesDetail s in salesDetails)
            //{
            //    context.SalesDetails.Add(s);
            //}
            //context.SaveChanges();
        }
    }
}
