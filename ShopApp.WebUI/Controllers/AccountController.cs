using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Bussiness.Abstarct;
using ShopApp.WebUI.Extensions;
using ShopApp.WebUI.Identity;
using ShopApp.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IEmailSender _emailSender;
        private ICartService _cartService;

        public AccountController(ICartService cartService, UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager, IEmailSender emailSender)
        {
            _cartService = cartService;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }
        public IActionResult Register()
        {
            return View(new RegisterModel());
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);

            }
            var user = new ApplicationUser
            {
                UserName = model.Username,
                Email = model.Email,
                FullName = model.FullName

            };

            var result = await _userManager.CreateAsync(user,model.Password);
            if (result.Succeeded)
            {
                //Token Oluşturma
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = Url.Action("ConfirmEmail", "Account", new
                {
                    userId = user.Id,
                    token = code
                });
                //Email Gönderme
                await _emailSender.SendEmailAsync(model.Email, "Hasabınızı Onaylayın", $"Onay için Linke<a href='http://localhost:64299/{callbackUrl}'>Tıklayınız.</a>");

                TempData.Put("message",new ResultMessage()
               {
                    Title="Hesap Onayı",
                    Message="Eposta Adresinize Gelen Link ile Hesabınzı Onaylayınız",
                    Css="warning"
                });


                return RedirectToAction("login","account" );
            }
            ModelState.AddModelError("","Bilinmeyen Bir Hata Oluştu Lütfen YEniden Deneyiniz");
            return View(model);
        }

        /*---------------------------LOG-IN------------------------------------------------------------------------------------------*/

        public IActionResult Login(string ReturnUrl=null)
        {
            return View(new LoginModel{ 
                ReturnUrl = ReturnUrl
            });
        }
        [HttpPost]
        public async Task<IActionResult> Login (LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user ==null)
            {
                ModelState.AddModelError("", "Bu Email ile eşleşen Bir Hesap Bulunmuyor!");
                return View(model);
            }

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("", "Lütfen Hesabınızı Mail ile Onaylayınız!");
                return View(model);
            }


            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false ,false);
            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl??"~/");
            }
            ModelState.AddModelError("", "Girilen Mail veya Paralo Bilgisi Yanlış");

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            TempData.Put("message", new ResultMessage()
            {
                Title = "Oturum Kapatıldı",
                Message = "Hesabınız güvenli Bir Şeklilde Sonlandırıldı",
                Css = "warning"
            });


            return Redirect("~/");
        }

        /*--------------------------Confirmation--------------------------------*/

        public async Task<IActionResult> ConfirmEmail(string userId,string token)
        {
            if (userId==null || token == null)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Hesap Onayı",
                    Message = " Hesabınzı Onayı için Bilgileriniz Yanlış",
                    Css = "danger"
                });

                return Redirect("~/");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user!=null)
            {
            var result = await _userManager.ConfirmEmailAsync(user,token);
            if (result.Succeeded)
            {
                    //create Cart Object
                    _cartService.InitializeCart(user.Id);


                    TempData.Put("message", new ResultMessage()
                    {
                        Title = "Hesap Onayı",
                        Message = " Hesabınız Başarı ile Onaylanmıştır",
                        Css = "success"
                    });
                    return RedirectToAction("Login");
            }

            }

            TempData.Put("message", new ResultMessage()
            {
                Title = "Hesap Onayı",
                Message = " Hesabınız Onaylanamadı ",
                Css = "danger"
            });
            return View();
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string Email)
        {
            if (string.IsNullOrEmpty(Email))
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Forgot Password",
                    Message = " Bilgileriniz Hatalı",
                    Css = "danger"
                });
                return View();
            }
            var user =await  _userManager.FindByEmailAsync(Email);

            if (user == null)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Forgot Password",
                    Message = "Eposta adresi le ilişkili Bir Kullanıcı Bulunamadı ",
                    Css = "danger"
                });
                return View();
            }
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            var callbackUrl = Url.Action("ResetPassword", "Account", new
            {
                token = code
            });
            //Email Gönderme
            await _emailSender.SendEmailAsync(Email, "ResetPassword", $"Paralonızı Yenilemek için Linke<a href='http://localhost:64299/{callbackUrl}'>Tıklayınız.</a>");

            TempData.Put("message", new ResultMessage()
            {
                Title = "Forgot Password",
                Message = "Paralo Yenilemek için hesabınıza mail Gönderildi ",
                Css = "warning"
            });

            return RedirectToAction("login", "account");

        }

        public IActionResult ResetPassword( string userId,string token)
        {
            if ( token == null)
            {
                return RedirectToAction("Home","Index");
            }
            var model = new ResetPasswordModel { Token = token };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return RedirectToAction("Home", "Index");

            }
            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }
            
            return View(model);
        }
        /*------------------------------AccesDeniedd Page----------------------- */
        public IActionResult Accessdenied()
        {
            return View();
        }
    }
}
