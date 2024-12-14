using BlogApi.DataAccess;
using BlogApi.EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BlogApi.Controllers
{
    //Not empty Api yüklediğimizde otomatikmen swager çalışacaktır
    //Bu kodlar Swager içinde çalıştığında get update post olarak çalışacaktır ki swager sonuçları görsün
    //Kontroll içinde yazılan bütün kodlar postman yada swagerde çalışması içindir.Bu api kodlarını             
    //sayfalar arası veri taşıma işlemi de gerçekleştirebiliyoruz. örneği Area içinde EmployeeTest kontrolü içinde yaptık
    //Sayfalaar arası veri taşımak için Blogapi sayfası ve sayfaya taşınacak kontrolür aynı anda çalışması gerekir
    //Proje sağ tuş özellikler aynı anda çalışması gereken başlangıç penceresinden aynı anda çalışması gerekenleri seçebilirsin 
    //apideki bilgileri tarayıcıda görebiliriz https://localhost:7093/api/Default/32 ile 32.id değeri görebiliriz
    //Bu bir deneme1

    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        Context context = new Context();

        [HttpGet]                       
        public IActionResult Index()
        {                          
            var employee = context.Employees.ToList();
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult EmplyeeAdd(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult FindEmployee(int id)
        {
            var employee = context.Employees.Where(x=>x.EmployeeID==id).FirstOrDefault();
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult EmployeeDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employee = context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                context.Remove(employee);
                context.SaveChanges();
                return Ok(employee);
            }
        }

        [HttpPut]
        public IActionResult UpdateEmployee(Employee employee)
        {
            context.Entry(employee).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();

        }
    }
}
