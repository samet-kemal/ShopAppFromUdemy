using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Bussiness.Abstarct
{
    public interface IProductService
    {
        Product GetById(int Id);
        Product GetProductDetails(int id);

        List<Product> GetAll();
        List<Product> GetProductsByCategory(string category);
        void Create(Product entity);
        void Delete(Product entity);

        void Update(Product entity);

    }
}
