using Microsoft.AspNetCore.Mvc;

namespace VidlyNew.Controllers
{
    public class RentalsController : Controller
    {
        public IActionResult New()
        {
            return View("New");
        }
    }
}
