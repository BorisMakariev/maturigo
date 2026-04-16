using Microsoft.AspNetCore.Mvc;

namespace maturigo.Controllers
{
    public class QuestionController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
