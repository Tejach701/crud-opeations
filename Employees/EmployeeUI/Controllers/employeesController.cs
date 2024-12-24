using Microsoft.AspNetCore.Mvc;

namespace EmployeeUI.Controllers
{
    public class employeesController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public employeesController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            await client.GetAsync("https://localhost:7015/api/employees");
            return View();
        }
    }
}
