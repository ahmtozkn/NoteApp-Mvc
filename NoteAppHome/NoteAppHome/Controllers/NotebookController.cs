using Microsoft.AspNetCore.Mvc;
using NoteAppHome.Data;
using NoteAppHome.Models;

namespace NoteAppHome.Controllers
{
    public class NotebookController : Controller
    {
        public IActionResult Index()
        {
            NoteDb noteDb = new NoteDb();
            string loginId = HttpContext.Session.GetString("LoginId");
            int a = Convert.ToInt32(loginId);


            if (loginId != null) { 
            
            var NoteBook = noteDb.NoteBooks.Where(x=>x.UserId==a).Select(x => new NoteBookVm()
            {
                Id = x.Id,
                NoteBookName = x.Name,
            }).ToList();

            return View(NoteBook);
            
            }

            return Redirect("/Account/Login");

        }

        public IActionResult Create()
        {
            string loginId = HttpContext.Session.GetString("LoginId");

            if(loginId!= null) 
            { 


           int a = Convert.ToInt32(loginId);
            NoteBookVm vm= new NoteBookVm();
            vm.UserID = a;
            ViewBag.Id = a;
            return View();

           }

            return Redirect("/Account/Login");
        }

        public IActionResult Save(NoteBookVm vm)
        {
            NoteDb noteDb = new NoteDb();

            if (vm.Id > 0)
            {
                var Noteupdate = noteDb.NoteBooks.FirstOrDefault(x => x.Id == vm.Id);

                Noteupdate.Name = vm.NoteBookName;



            }

            else
            {
              string loginId = HttpContext.Session.GetString("LoginId");
              int a = Convert.ToInt32(loginId);

                var NoteBookSave = noteDb.NoteBooks.Add(new NoteBook()
                {

                    Name = vm.NoteBookName,
                    UserId = a


                }).ToString();
            }
            noteDb.SaveChanges();


            return RedirectToAction("Index");
        }
        public IActionResult Update(int Id)
        {

            NoteDb noteDb = new NoteDb();
            var Notebook = noteDb.NoteBooks.FirstOrDefault(x => x.Id == Id);
            NoteBookVm vm = new NoteBookVm();
            vm.Id = Notebook.Id;
            vm.NoteBookName = Notebook.Name;



            return View(vm);
        }

        public IActionResult Delete(int Id)
        {
            NoteDb noteDb = new NoteDb();
            var Notebookdel = noteDb.NoteBooks.FirstOrDefault(x => x.Id == Id);
            noteDb.NoteBooks.Remove(Notebookdel);
            noteDb.SaveChanges();



            return RedirectToAction("Index");
        }
    }
}
