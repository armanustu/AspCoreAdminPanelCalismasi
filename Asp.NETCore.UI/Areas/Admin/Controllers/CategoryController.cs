using Asp.NETCore.UI.Validation;
using BusinessLayer.Concrete;
using DataAcessLayer.Abstract;
using DataAcessLayer.Concrete;
using DataAcessLayer.Repository;
using DataEntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;
namespace Asp.NETCore.UI.Area.Admin.Controllers
{
    [Area("Admin")]//https://localhost:58802/Admin/Category/Index

    public class CategoryController : Controller
    {

        ICategoryDAL _categoryDAL;
        IWriterDAL _writerDAL;

        public CategoryController(ICategoryDAL categoryDAL, IWriterDAL writerDAL)
        {
            _categoryDAL = categoryDAL;
            _writerDAL = writerDAL;
        }

        CategoryManager categoryManager = new CategoryManager(new CategoryRepository());
        public IActionResult Index(int page = 1)
        {
            string status = ""; 
                if (Request.Query["status"].ToString() != "") {
                    status = Request.Query["status"].ToString();              
                     if (status == "1")
                    {
                        ViewBag.StatusAdd = true;
                    }
                     if (status == "2")
                    {
                        ViewBag.StatusDelete = true;
                    }
                     if (status == "3")
                   {
                    ViewBag.StatusUpdate = true;
                   }
                     if (status == "4")
                    {
                    ViewBag.StatusAktif = true;
                    }
                   if(status=="0")
                {
                    ViewBag.StatusResult = false;
                }

            }            
           
            
            var categoryList = _categoryDAL.GetAll().ToPagedList(page, 7);

            return View(categoryList);
        }
        public IActionResult AddCategory()
        {
            List<SelectListItem> kategori = (from c in categoryManager.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = c.CategoryName,
                                                 Value = c.CategoryID.ToString()

                                             }).ToList();

            ViewBag.Category = kategori;           
            return View();
        }
        Context context = new Context();
        WriterManager writerManager = new WriterManager(new WriterRepository());
     
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {

            List<SelectListItem> kategori = (from c in categoryManager.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = c.CategoryName,
                                                 Value = c.CategoryID.ToString()

                                             }).ToList();
            ViewBag.Category = kategori;

            CategoriValidation validations = new CategoriValidation();
            var result = validations.Validate(category);
            if (result.IsValid)
            {
               
                _categoryDAL.Add(category);               
                return RedirectToAction("Index", "Category",new { status = "1" });

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                   
                }
            }
            return View();
        }


        public IActionResult DeleteCategory(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var kategori = _categoryDAL.GetByID(id);

            bool result = categoryManager.CategoryDelete(kategori);
            if (result == true)
            {
                return RedirectToAction("Index", "Category", new { status = "2" });
            }
            return RedirectToAction("AddCategory", "Category", new { status = "0" });
        }

        public IActionResult CategoryUpdate(int id)
        {
            if (id != null)
            {          
                var kategori = _categoryDAL.GetByID(id);
                if (kategori == null)
                {
                    return NotFound();
                }
                ViewBag.statusdurum = false;
                return View(kategori);
            }

            return View();
        }

        [HttpPost]
        public IActionResult CategoryUpdate(Category category)
        {
            if (category == null)
            {
                return NotFound();
            }
            bool durum = _categoryDAL.Update(category);
            if (durum == true)
            {
                
                return RedirectToAction("Index", "Category",new {status="3"});

            }
            return RedirectToAction("Index", "Category", new { status = "0" });
            return View();
        }

        public IActionResult CategoryAktifYap(int id)
        {
            if (id != null)
            {
                var kategori = _categoryDAL.GetByID(id);
                if (kategori == null)
                {
                    return NotFound();
                }
                kategori.CategoryStatus = true;
                bool result = _categoryDAL.Update(kategori);
                if (result == true)
                {
                return RedirectToAction("Index", "Category", new { status = "4" });
                }
                return RedirectToAction("Index", "Category", new { status = "0" });              
            }

            return View();
        }
      
    }
}