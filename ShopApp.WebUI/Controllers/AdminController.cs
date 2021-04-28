using Microsoft.AspNetCore.Mvc;
using ShopApp.Bussiness.Abstarct;
using ShopApp.Entities;
using ShopApp.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductService _productService;
        public AdminController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductModel model)
        {
            var entity = new Product()
            {
                Name=model.Name,
                Price=model.Price,
                Description=model.Description,
                ImageUrl=model.ImageUrl
            };
            _productService.Create(entity);

            return Redirect("Index");
        }
    }
}
