using Microsoft.AspNetCore.Mvc;

namespace AzadCharity.Admin.Controllers
{
    public class CharityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
