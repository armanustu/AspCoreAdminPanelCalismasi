using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Asp.NETCore.UI.Areas.Admin.Controllers
{
    [Area("Admin")]//https://localhost:58802/Admin/Employee/Index UI ve blog api birlikte çalışması gerekir
    public class EmployeeController : Controller
    {
        public async Task<IActionResult> Index()
        {

            string status = "";
            if (Request.Query["status"].ToString() != "")
                status = Request.Query["status"].ToString();
            if (status != "")
            {
                if (status == "1")
                    ViewBag.Status = true;
                if (status == "2")
                    ViewBag.Güncelle = true;
                if (status == "3")
                    ViewBag.Ekle = true;
            }
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7093/api/Default");
            var jsonstring = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<EmployeeClass>>(jsonstring);
            return View(values);
        }

        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeClass employeeClass)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(employeeClass);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7093/api/Default", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { status = "3" });
            }
            return RedirectToAction("Index", new { status = "0" });
            //return View(employeeClass);
        }
      
        public async Task<IActionResult>EditEmployee(int id)
        {
            var httpclient = new HttpClient();
            var responseMessage = await httpclient.GetAsync("https://localhost:7093/api/Default/" +id);
           
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonEmployee = await responseMessage.Content.ReadAsStringAsync();
                 var values = JsonConvert.DeserializeObject<EmployeeClass>(jsonEmployee);
                return View(values);
            }
            return RedirectToAction("Index","Employee" );

        }
        [HttpPost]
        public async Task<IActionResult> EditEmployee(EmployeeClass employeeClass)
        {

            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(employeeClass);
            var content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:7093/api/Default", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { status = "2" });
            }
            return RedirectToAction("Index", new { status = "0" });
         
        
        }        
       
        public async Task<IActionResult> EmployeeDelete(int id)
        {
            var httpclient = new HttpClient();
            var responseMessage = await httpclient.DeleteAsync("https://localhost:7093/api/Default/" + id);
            bool durum = responseMessage.IsSuccessStatusCode;

            if (responseMessage.IsSuccessStatusCode)
            {
                ViewBag.Status = durum;
                return RedirectToAction("Index", new { status = "1" });
               
            }
            return RedirectToAction("Index", new { status = "0" });
        }
		public class EmployeeClass
            {
            public int EmployeeID { get; set; }
            public string? EmployeeName { get; set; }
        }
    }
}
