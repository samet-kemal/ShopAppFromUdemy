﻿using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Bussiness.Abstarct
{
   public  interface IOrderService
    {
        void Create(Order entity);
    }
}
