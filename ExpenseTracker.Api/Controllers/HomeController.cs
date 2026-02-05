using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }           
    }
}
