using ShopApp.Bussiness.Abstarct;
using ShopApp.DataAccess.Abstract;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Bussiness.Concrete
{
    public class CartManager : ICartService
    {
        private ICartDal _cartDal;
        public CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }

        public void AddToCart(string userId, int productId, int quantity)
        {
            var cart = GetCartByUserId(userId);
            if (cart !=null)
            {
                var index = cart.CartItemss.FindIndex(i => i.ProductId == productId);
                if (index<0)
                {
                    cart.CartItemss.Add(new CartItem()
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        CartId=cart.Id
                    });
                }
                else
                {
                    cart.CartItemss[index].Quantity += quantity;
                }
                _cartDal.Update(cart);
            }
        }

        public void ClearCart(string cartId)
        {
            _cartDal.ClearCart(cartId);
        }

        public void DeleteFromCart(string userId, int productId)
        {
            var cart = GetCartByUserId(userId);
            if (cart != null)
            {
                _cartDal.DeleteFromCart(cart.Id, productId);
            }

        }

        public Cart GetCartByUserId(string userId)
        {
            return _cartDal.GetByUserId(userId);
        }

        public void InitializeCart(string userId)
        {
            _cartDal.Create(new Cart() { UserId = userId });
        }
    }
}
