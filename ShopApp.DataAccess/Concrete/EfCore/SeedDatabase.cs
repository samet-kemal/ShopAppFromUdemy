using Microsoft.EntityFrameworkCore;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopApp.DataAccess.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new ShopContext();
            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Categories.Count() == 0)
                {
                    context.Categories.AddRange(Categories);
                }
                if (context.Products.Count() == 0)
                {
                    context.Products.AddRange(Products);
                }
                context.SaveChanges();
            }
        }
        private static Category[] Categories =
        {
            new Category(){Name="Kıyafet"},
            new Category(){Name="Aksesuar"},
            new Category(){Name="Ayakkabı"},

        };
        private static Product[] Products =
        {
            new Product(){Name="T-Shirt",ImageUrl="V-YakaT-Shirt.jpg",Price=30},
            new Product(){Name="Bot",ImageUrl="Bot.jpg",Price=500},
            new Product(){Name="Saat",ImageUrl="Saat.jpg",Price=30},
            new Product(){Name="Kot",ImageUrl="slider2.jpg.jpg",Price=80},
            new Product(){Name="Hırka",ImageUrl="slider1.jpg",Price=50},
            new Product(){Name="T-Shirts",ImageUrl="slider3.jpg",Price=20},
            new Product(){Name="Ceket",ImageUrl="Ceket.jpg",Price=300},
        };
    }
}
