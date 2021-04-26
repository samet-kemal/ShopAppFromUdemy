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
                    context.AddRange(ProductCategory);
                }
                context.SaveChanges();
            }
        }
        private static Category[] Categories =
        {
            
            new Category(){Name="Kıyafet"},
            new Category(){Name="Aksesuar"},
            new Category(){Name="Ayakkabı"},
            new Category(){Name="Giyim"}

        };
        private static Product[] Products =
        {
            new Product(){Name="T-Shirt",ImageUrl="V-YakaT-Shirt.jpg",Price=30,Description="<p>Şık ve Rahat</p>"},
            new Product(){Name="Bot",ImageUrl="Bot.jpg",Price=500,Description="<p>Su Geçirmiyor ve Dayanıklı</p>"},
            new Product(){Name="Saat",ImageUrl="Saat.jpg",Price=30,Description="<p>Günlük Kullanım için ideal </p>"},
            new Product(){Name="Kot",ImageUrl="Kot.jpg",Price=80,Description="<p>Esnek ve Bedene Tam oturuyor</p>"},
            new Product(){Name="Hırka",ImageUrl="slider1.jpg",Price=50,Description="<p>Salaş ve Yünlü</p>"},
            new Product(){Name="T-Shirts",ImageUrl="slider3.jpg",Price=20,Description="<p>Hepsi çok rahat ve Kullanışlı</p>"},
            new Product(){Name="Ceket",ImageUrl="Ceket.jpg",Price=300,Description="<p>Şık ve Rahat</p>"},
        };
        private static ProductCategory[] ProductCategory =
        {
            new ProductCategory(){Product=Products[0],Category = Categories[0]},
            new ProductCategory(){Product=Products[0],Category = Categories[3]},
            new ProductCategory(){Product=Products[1],Category = Categories[2]},
            new ProductCategory(){Product=Products[1],Category = Categories[3]},
            new ProductCategory(){Product=Products[2],Category = Categories[1]},
            new ProductCategory(){Product=Products[2],Category = Categories[3]},
            new ProductCategory(){Product=Products[3],Category = Categories[0]},
            new ProductCategory(){Product=Products[3],Category = Categories[3]},
            new ProductCategory(){Product=Products[4],Category = Categories[0]},
            new ProductCategory(){Product=Products[4],Category = Categories[3]},
            new ProductCategory(){Product=Products[5],Category = Categories[0]},
            new ProductCategory(){Product=Products[5],Category = Categories[3]},
            new ProductCategory(){Product=Products[6],Category = Categories[0]},
            new ProductCategory(){Product=Products[6],Category = Categories[3]},



        };
    }
}
