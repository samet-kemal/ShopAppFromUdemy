﻿using ShopApp.DataAccess.Abstract;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ShopApp.DataAccess.Concrete.Memory
{
    public class MemoryProductDal : IProductDal
    {
        public void Create(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            var products = new List<Product>()
            {
                new Product(){Id=1,Name="T-Shirt",ImageUrl="V-YakaT-Shirt.jpg",Price=30},
                new Product(){Id=2,Name="Bot",ImageUrl="Bot.jpg",Price=500},
                new Product(){Id=3,Name="Saat",ImageUrl="Saat.jpg",Price=30},
                new Product(){Id=4,Name="Kot",ImageUrl="slider2.jpg.jpg",Price=80},
                new Product(){Id=5,Name="Hırka",ImageUrl="slider1.jpg",Price=50},
                new Product(){Id=6,Name="T-Shirts",ImageUrl="slider3.jpg",Price=20},
                new Product(){Id=7,Name="Ceket",ImageUrl="Ceket.jpg",Price=300},

            };
            return products;
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Product GetOne(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetPopularProducts()
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
