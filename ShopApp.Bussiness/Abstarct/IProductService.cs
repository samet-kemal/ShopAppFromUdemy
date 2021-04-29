using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Bussiness.Abstarct
{
    public interface IProductService
    {
        Product GetById(int Id);
        Product GetByIdWithCategories(int id);

        Product GetProductDetails(int id);

        List<Product> GetAll();
        List<Product> GetProductsByCategory(string category,int page,int pageSize);
        void Create(Product entity);
        void Delete(Product entity);

        void Update(Product entity);
        int GetCountByCategory(string category);
        void Update(Product entity, int[] categoryIds);
    }
}
