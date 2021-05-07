﻿using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Bussiness.Abstarct
{
   public  interface ICartService
    {
        void InitializeCart(string userId);

        Cart GetCartByUserId(string userId);

        void AddToCart(string userId, int productId, int quantity);
        void DeleteFromCart(string userId, int productId);
        void ClearCart(string cartId);
    }
}
