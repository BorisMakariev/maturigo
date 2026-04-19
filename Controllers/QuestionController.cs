using Microsoft.AspNetCore.Mvc;
using maturigo.Models.ViewModels;
using maturigo.Models.Entities;
using maturigo.Models.DTOs;
using maturigo.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace maturigo.Controllers
{
    public class QuestionController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ExamService _examService;
        private readonly QuestionService _questionService;

        public QuestionController(UserManager<IdentityUser> userManager, ExamService examService, QuestionService questionService)
        {
            _userManager = userManager;
            _examService = examService;
            _questionService = questionService;
        }

        public IActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                string userId = _userManager.GetUserId(User);
                var exams = _examService.GetExamsByUserId(userId);
                List<SelectListItem> examsForViewModel = new List<SelectListItem>();
                foreach (var exam in exams)
                {
                    examsForViewModel.Add(new SelectListItem { Value = exam.Id, Text = exam.Title });
                }
                QuestionCreateModel qc = new QuestionCreateModel();
                qc.dto = new QuestionDTO();
                //qc.dto.Body = "unholy bs";
                qc.Exams = examsForViewModel;
                return View(qc);
            }
            return Redirect("/Identity/Account/Login");
        }

        [HttpPost]
        public ActionResult Create(QuestionCreateModel viewModel)
        {
            if (User.Identity.IsAuthenticated)
            {
                Question questionForDb = new Question(viewModel.dto.ExamId, viewModel.dto.Body);
                _questionService.Create(questionForDb);

                string userId = _userManager.GetUserId(User);
                var exams = _examService.GetExamsByUserId(userId);
                List<SelectListItem> examsForViewModel = new List<SelectListItem>();
                foreach (var exam in exams)
                {
                    examsForViewModel.Add(new SelectListItem { Value = exam.Id, Text = exam.Title });
                }

                viewModel.Exams = examsForViewModel;

            }
            viewModel.dto = new QuestionDTO();
            return View(viewModel);
        }
    }
}
