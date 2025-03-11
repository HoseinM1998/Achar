using Microsoft.AspNetCore.Mvc;

namespace Achar.Endpoint.Api.Controllers
{
    public class User : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
