using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Bussiness.Abstarct
{
    public interface ICategoryService
    {
        Category GetById(int Id);
        Category GetByIdWithProducts(int Id);
        List<Category> GetAll();
        void Create(Category entity);
        void Delete(Category entity);

        void Update(Category entity);
        void DeleteFromCategory(int categoryId, int productId);
    }
}
