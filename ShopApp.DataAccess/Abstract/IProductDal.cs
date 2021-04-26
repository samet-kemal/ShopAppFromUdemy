﻿using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ShopApp.DataAccess.Abstract
{
   public interface IProductDal:IRepository<Product>
    {
        List<Product> GetPopularProducts(int id);
        Product GetProductDetails(int id);
        List<Product> GetPopularProducts();
    }
}
