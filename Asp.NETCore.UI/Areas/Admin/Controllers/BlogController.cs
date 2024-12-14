using Asp.NETCore.UI.Area.Admin.Models;
using Asp.NETCore.UI.Areas.Admin.Models;
using BusinessLayer.Concrete;
using ClosedXML.Excel;
using DataAcessLayer.Repository;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Identity;
//Blog
namespace Asp.NETCore.UI.Area.Admin.Controllers
{
    [Area("Admin")]//https://localhost:58802/Admin/Blog/ExportStaticExcelBlogList
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new BlogRepository());
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog title";
                worksheet.Cell(1, 3).Value = "Blog Durum";
                int BlogRowCount = 2;
                foreach (var item in BlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    worksheet.Cell(BlogRowCount, 3).Value = item.Durum;

                    BlogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.opentxmlformats-officedocument.spreadsheetml.sheet", "Blog Çalışmaları.xlsx");
                }

            }
            return View();
        }
        public List<BlogModel> BlogList()
        {
            List<BlogModel> Blogmodel = new List<BlogModel>
        {
            new BlogModel{ ID=1, BlogName="C# Proglamaya Giriş",Durum=true},
            new BlogModel{ ID=2, BlogName="C# Proglamaya Giriş",Durum=true},
            new BlogModel{ ID=3, BlogName="C# Proglamaya Giriş",Durum =true}
        };
            return Blogmodel;
        }
        public IActionResult BlogListExcelExport()
        {
            return View();
        }
        public IActionResult DynamicExcelExport()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog title";
                worksheet.Cell(1, 3).Value = "Blog Durum";
                worksheet.Cell(1, 4).Value = "Blog Açıklama";
                worksheet.Cell(1, 5).Value = "Kategori ID";
                worksheet.Cell(1, 5).Value = "Kategori ID";
                worksheet.Cell(1, 6).Value = "Yazar ID";
                int BlogRowCount = 2;
                foreach (var item in Bloglist3())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    worksheet.Cell(BlogRowCount, 3).Value = item.Durum;
                    worksheet.Cell(BlogRowCount, 3).Value = item.BlogContent;
                    worksheet.Cell(BlogRowCount, 3).Value = item.CategoryID;
                    worksheet.Cell(BlogRowCount, 3).Value = item.WriterID;
                    BlogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.opentxmlformats-officedocument.spreadsheetml.sheet", "Blog Çalışmaları.xlsx");
                }

            }
            return View();
        }

        public List<BlogModel2> Bloglist3()
        {
            List<BlogModel2> lst = new List<BlogModel2>();
            lst = (from m in blogManager.GetList()
                   select new BlogModel2
                   {
                       BlogName = m.BlogTitle,
                       Durum = Convert.ToBoolean(m.BlogStatus),
                       ID = m.BlogID,
                       BlogContent = m.BlogContent,
                       CategoryID = m.CategoryID,
                       WriterID = m.WriterID

                   }).ToList();
            return lst.ToList();

        }
    }
}
