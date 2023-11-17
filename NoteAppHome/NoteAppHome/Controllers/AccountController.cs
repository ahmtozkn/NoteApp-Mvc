
using NoteAppHome.Data;

using Microsoft.AspNetCore.Mvc;
using NoteAppHome.Models;
using NuGet.Versioning;

namespace NoteAppHome.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            string MailLogin = HttpContext.Session.GetString("email");
            if(!string.IsNullOrEmpty(MailLogin))
            {
                return Redirect("/Notebook/Index");
            }



            return View();
        }
        [HttpPost]
        public IActionResult Login(UserVm vm)
        {
          

            NoteDb db=new NoteDb();

            var Login=db.Users.FirstOrDefault(x=>x.Email==vm.Email); 
            
           


            if (Login!=null)
            {
                if (Login.Password == vm.Password)
                {
                    HttpContext.Session.SetString("email", vm.Email);
                    HttpContext.Session.SetString("LoginId", Login.Id.ToString());

                }
                else
                {
                    TempData["Message"] = "Şifre hatalı";
                    return View(vm);
                }


            }
            else
            {
                TempData["Message"] = "Böyle bir kullanıcı bulunamadı";
                return View(vm);

            }


            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Register() 
        {
        
            return View();
        }

        [HttpPost]

        public IActionResult Register(UserVm vm) 
        {
            NoteDb db=new NoteDb();
            if(vm.Password!=vm.PasswordT)
            {
                TempData["Message"] = "Şifreler uyuşmuyor";

                return View(vm);
            }

            var emailc=db.Users.FirstOrDefault(x=>x.Email==vm.Email);
            if (emailc != null)
            {
                TempData["Message"] = "Bu heasp zaten kayıtlı";
                return View(vm);
            }

            Data.User user=new  Data.User();
            user.Email = vm.Email;
            user.Password = vm.Password;
            user.FirstName= vm.FirstName;
            user.LastName= vm.LastName;

            db.Users.Add(user);
            db.SaveChanges();

           return RedirectToAction("Login");





            
        }

        public IActionResult AccountIndex()
        {

            NoteDb db = new NoteDb();
            string loginId = HttpContext.Session.GetString("LoginId");
            int a = Convert.ToInt32(loginId);
            if (loginId != null)
            {
                var AccountIn = db.Users.FirstOrDefault(x => x.Id == a);

                UserVm vm = new UserVm();
                vm.Id = AccountIn.Id;
                vm.Email = AccountIn.Email;
                vm.Password = AccountIn.Password;
                vm.FirstName = AccountIn.FirstName;
                vm.LastName = AccountIn.LastName;


                return View(vm);

            }

            return Redirect("/Account/Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("email");
            HttpContext.Session.Remove("LoginId");


            return RedirectToAction("Login");
        }


    }
}
