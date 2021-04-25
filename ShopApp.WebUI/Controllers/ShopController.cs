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

    public class ShopController : Controller
    {
        private IProductService _productService;

        public ShopController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product product = _productService.GetById((int)id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        public IActionResult List()
        {
            return View(new ProductListModel()
            {
                Products = _productService.GetAll()
            });
        }
    }
}
