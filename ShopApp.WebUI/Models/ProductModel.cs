using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        //[Required]
        //[StringLength(60,MinimumLength =10,ErrorMessage ="Ürün ismi minimum 10 ,maximum 60 karakter olmalıdır.")]
        public string Name { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 20, ErrorMessage = "Açıklama Kısmı minimum 20 maximum 100 Karakter içermelidir.")]
        public string Description { get; set; }
        [Required(ErrorMessage ="Fiyat Belirtiniz.")]
        [Range(1,100000)]
        public decimal Price { get; set; }
        public List<Category> SelectedCategories { get; set; }
    }
}
