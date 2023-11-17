using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NoteAppHome.Data;
using NoteAppHome.Models;

namespace NoteAppHome.Controllers
{
    public class NoteController : Controller
    {
        public IActionResult Index(int Id)
        {
            NoteDb db = new NoteDb();
            var Note = db.Notes.Where(x => x.NoteBookId == Id).Select(x => new NoteVm()
            {
                Id = x.Id,
                Content = x.Content,
                NoteBookName = x.NoteBook.Name,
                Title = x.Title
            }).ToList();

            return View(Note);
        }
        public IActionResult Create()
        {

            NoteDb noteDb = new NoteDb();
            string loginId = HttpContext.Session.GetString("LoginId");
            int a = Convert.ToInt32(loginId);

            NoteDb db = new NoteDb();
            ViewBag.Note = db.NoteBooks.Where(x=>x.UserId==a).Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            return View();
        }

        public IActionResult Save(NoteVm vm)
        {
            NoteDb db = new NoteDb();

            if (vm.Id > 0)
            {
                var Note = db.Notes.FirstOrDefault(x => x.Id == vm.Id);

                Note.Content = vm.Content;
                Note.NoteBookId = vm.NoteBookId;
                Note.Title = vm.Title;
               
               
            }


            else
            {
                db.Notes.Add(new Note()
                {
                    Content = vm.Content,
                    NoteBookId = vm.NoteBookId,
                    Title = vm.Title
                }).ToString();

            }




        db.SaveChanges();

        return Redirect("/Notebook/Index");
           
        }


        public IActionResult Delete(int Id)
        {
            NoteDb db = new NoteDb();
            var delnot = db.Notes.FirstOrDefault(x => x.Id == Id);
            db.Notes.Remove(delnot);
            db.SaveChanges();

            return Redirect("/NoteBook/Index");

        }

        public IActionResult Update(int id)
        {
           
           NoteDb db = new NoteDb();
            string loginId = HttpContext.Session.GetString("LoginId");
            int a = Convert.ToInt32(loginId);

            var noteupdate = db.Notes.FirstOrDefault(x => x.Id == id);

            NoteVm vm = new NoteVm();
            vm.Id = noteupdate.Id;
            vm.Id = noteupdate.Id;
            vm.Content = noteupdate.Content;
            vm.Title = noteupdate.Title;


            ViewBag.Note = db.NoteBooks.Where(x=>x.UserId==a).Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();




            return View(vm);


        }
    }
}
