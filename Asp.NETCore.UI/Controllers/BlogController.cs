using Asp.NETCore.UI.Validation;
using BusinessLayer.Concrete;
using DataAcessLayer.Abstract;
using DataAcessLayer.Concrete;
using DataAcessLayer.Repository;
using DataEntityLayer.Concrete;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Vml;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Mail;

namespace Asp.NETCore.UI.Controllers
{
    public class BlogController : Controller
    {
        IBlogDAL _blogdal;
        ICategoryDAL _categorydal;
        ICommentDAL _commentdal;
        private readonly IWebHostEnvironment env;

        public BlogController(IBlogDAL blogdal,ICategoryDAL categorydal, IWebHostEnvironment env, ICommentDAL commentdal)
        {
            _categorydal = categorydal;
            _blogdal = blogdal;
            this.env = env;
            _commentdal = commentdal;
        }

        BlogManager blogManager = new BlogManager(new BlogRepository());
        CategoryManager categoryManager = new CategoryManager(new CategoryRepository());
        WriterManager writerManager = new WriterManager(new WriterRepository());
        CommentManager commentManager = new CommentManager(new CommentRepository());
        public IActionResult BlogIndex()
        {
            var blog = _blogdal.GetListBlogWithCategory();
            return View(blog);
        }     
        public IActionResult BlogDetails(int id)
        {
            bool success = false;
            string? message = null;
            if (Request.Query["success"].ToString() != "")
            {
                success = Convert.ToBoolean(Request.Query["success"].ToString());
                if (success)
                {
                    message = "İşlem Başarılı Olmuştur";
                }
                else
                {
                    message = "İşlem Başarısız Olmuştur";
                }
            }
            var blog = _blogdal.BlogGetByID(id);           
          
            var comments = commentManager.GetByID(id);
            ViewBag.data = comments;
            ViewData["Message"] = message;
            return View(blog);
        }

        public IActionResult BlogReadAll(int id)
        {
            
            var blog=blogManager.GetListBlogByWriter(id);
            return View(blog);
        }
        [HttpPost]
        public IActionResult CommentForm(Comment comment)
        {
            CommentManager commentManager = new CommentManager(new CommentRepository());
            BlogManager blogManager = new BlogManager(new BlogRepository());
            int id1 = Convert.ToInt32(Request.Form["BlogId"].ToString());
            int? id2;           
            var blog = _blogdal.BlogGetByID(id1);
            id2 = blog.WriterID;
            string CommentUsername = "";
            string CommentTitle = "";
            string CommentContent = "";
            bool success = false;
            int id = 0;
            CommentUsername = Request.Form["CommentUserName"].ToString();
            CommentTitle = Request.Form["CommentTitle"].ToString();
            CommentContent = Request.Form["CommentContent"].ToString();
            id = Convert.ToInt32(Request.Form["BlogId"]);
            comment.CommentUserName = CommentUsername;
            comment.CommentTitle = CommentTitle;
            comment.CommentContent = CommentContent;
            comment.CommentDate = DateTime.Now;
            comment.Commentstatus = true;
            comment.WriterID = id2;
            comment.BlogScore = 0;
            _commentdal.Add(comment);
            
            success = true;
            return RedirectToAction("BlogDetails", "Blog", new { id = id, success = success });
        }


        Context context = new Context();
        public ActionResult BlogListByWriter()//Yazar göre Blogları getir
        {
            var mail = User.Identity.Name;
            int BlogID = context.Writers.Where(x => x.WriterMail == mail).Select(m => m.WriterID).FirstOrDefault();
            var blog = blogManager.GetListBlogByWriter(BlogID);
            return View(blog);
        }

        public IActionResult BlogListWithKategoriName()
        {

            var result = _blogdal.GetListBlogWithCategory();
            return View(result);
        }

        public IActionResult GetListBlogWithCategoryWithID()
        {
            var mail = User.Identity.Name;
            int WriterID = context.Writers.Where(x => x.WriterMail == mail).Select(m => m.WriterID).FirstOrDefault();
            var Blog = _blogdal.GetListBlogWithCategoryWithID(WriterID);
           
            return View(Blog);
        }

        public IActionResult BlogDelete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            bool durum = false;
            var result = _blogdal.BlogGetByID(id);			
            result.BlogStatus = false;
			if (result != null)
            {
                bool result2 = _blogdal.Delete(result); 
                
                if (result2 == true)
                {
                    durum = true;   
                    ViewBag.Status = true;
                    return RedirectToAction("GetListBlogWithCategoryWithID");
                                  
                }
                else
                {
                    result.BlogStatus = result2;
                }
            }
            else
            {
                return NotFound();
            }
			return View();

		}
        public IActionResult EditBlog(int id)
        {
       
            var blogresult = _blogdal.BlogGetByID(id);

            List<SelectListItem> valuecategory = (from m in _categorydal.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = m.CategoryName,
                                                      Value = m.CategoryID.ToString()
                                                  }).ToList();
            List<SelectListItem> valuewriter = (from m in writerManager.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = m.WriterName,
                                                    Value = m.WriterID.ToString()
                                                }).ToList();
            ViewBag.Category = valuecategory;
            ViewBag.Writer = valuewriter;
            return View(blogresult);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {

            blog.BlogCreateDate = DateTime.Now;
            blog.BlogStatus = true;
            BlogValidation validations = new BlogValidation();
            var result = validations.Validate(blog);
            bool blogresult = false;
            if (result.IsValid)
            {
                blogresult = blogManager.BlogUpdate(blog);                   
                ViewBag.Status = true;
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            List<SelectListItem> valuecategory = (from m in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = m.CategoryName,
                                                      Value = m.CategoryID.ToString()
                                                  }).ToList();
            List<SelectListItem> valuewriter = (from m in writerManager.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = m.WriterName,
                                                    Value = m.WriterID.ToString()
                                                }).ToList();
            ViewBag.Category = valuecategory;
            ViewBag.Writer = valuewriter;
            if (blogresult == true)
            {

                return RedirectToAction("GetListBlogWithCategoryWithID"); 

            }
            return View();
        }

        public IActionResult AddBlog()
        {

            List<SelectListItem> valuecategory = (from m in _categorydal.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = m.CategoryName,
                                                      Value = m.CategoryID.ToString()
                                                  }).ToList();

            ViewBag.Category = valuecategory;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBlog(Blog blog, IFormFile uploadThumb, IFormFile uploadImage)
        {
            string thumb = "";
            string image = "";

            if ((uploadThumb != null && uploadThumb.Length != 0 && string.IsNullOrEmpty(uploadThumb.FileName) == false) || (uploadImage != null && uploadImage.Length != 0 && string.IsNullOrEmpty(uploadImage.FileName) == false))
            {
                string wwwroot = env.WebRootPath;
                string content = System.IO.Path.Combine(wwwroot, "content");

                if (uploadThumb != null && uploadThumb.Length != 0 && string.IsNullOrEmpty(uploadThumb.FileName) == false)
                {
                    FileInfo thumbInfo = new FileInfo(uploadThumb.FileName);
                    string thumbExtension = thumbInfo.Extension;
                    string thumbNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(thumbInfo.FullName);
                    string thumbNewFileName = "Resim_" + Guid.NewGuid().ToString().Replace("-", "").Substring(0, 5) + thumbExtension;
                    string thumbImagePath = System.IO.Path.Combine(content, thumbNewFileName);

                    using (FileStream fs = new FileStream(thumbImagePath, FileMode.Create, FileAccess.Write, FileShare.Write, 4096, true))
                    {
                        try
                        {
                            await uploadThumb.CopyToAsync(fs);
                            await fs.FlushAsync();
                            await fs.DisposeAsync();
                            thumb = thumbNewFileName;
                        }
                        catch { }
                    }
                }//thumb

                if (uploadImage != null && uploadImage.Length != 0 && string.IsNullOrEmpty(uploadImage.FileName) == false)
                {
                    FileInfo imageInfo = new FileInfo(uploadImage.FileName);
                    string imageExtension = imageInfo.Extension;
                    string imageNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(imageInfo.FullName);
                    string imageNewFileName = "Resim_" + Guid.NewGuid().ToString().Replace("-", "").Substring(0, 5) + imageExtension;
                    string imageImagePath = System.IO.Path.Combine(content, imageNewFileName);

                    using (FileStream fs = new FileStream(imageImagePath, FileMode.Create, FileAccess.Write, FileShare.Write, 4096, true))
                    {
                        try
                        {
                            await uploadImage.CopyToAsync(fs);
                            await fs.FlushAsync();
                            await fs.DisposeAsync();
                            image = imageNewFileName;
                        }
                        catch { }
                    }
                }

            }
            List<SelectListItem> valuecategory = (from m in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = m.CategoryName,
                                                      Value = m.CategoryID.ToString()
                                                  }).ToList();

            ViewBag.Category = valuecategory;
            var mail = User.Identity.Name;
            int WriterID = context.Writers.Where(x => x.WriterMail == mail).Select(m => m.WriterID).FirstOrDefault();
            blog.WriterID = WriterID;
            // var Blog = blogManager.GetListBlogWithCategoryWithID(WriterID);
            //blogManager.BlogAdd(blog);



            // ViewBag.Writer = valuewriter;

            BlogValidation blogvalidation = new BlogValidation();
            var result = blogvalidation.Validate(blog);
            if (result.IsValid)
            {
                blog.BlogThumnailImage = thumb;
                blog.BlogImage = image;
                blogManager.BlogAdd(blog);
                ViewBag.Status = true;
                return View();

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                ViewBag.Status = false;
            }
            ViewBag.Status = false;
            return View();

        }

    }
}
