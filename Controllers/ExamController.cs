using Microsoft.AspNetCore.Mvc;
using maturigo.Models.DTOs;
using maturigo.Models.Entities;
using Microsoft.AspNetCore.Identity;
using maturigo.Services;

namespace maturigo.Controllers
{
    public class ExamController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ExamService _examService;

        public ExamController(UserManager<IdentityUser> userManager, ExamService examService)
        {
            _userManager = userManager;
            _examService = examService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ExamDTO exam)
        {
            if (User.Identity.IsAuthenticated)
            {
                string userId = _userManager.GetUserId(User);
                Exam examForDb = new Exam(userId, exam.Title);
                _examService.Create(examForDb);
                return Content("created new exam");
            }
            return Content("probably not logged in, didnt create new exam");
        }

    }
}
