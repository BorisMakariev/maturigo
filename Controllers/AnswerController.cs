using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using maturigo.Models.ViewModels;
using maturigo.Models.Entities;
using maturigo.Models.DTOs;
using maturigo.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace maturigo.Controllers
{
    public class AnswerController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ExamService _examService;
        private readonly QuestionService _questionService;
        private readonly AnswerService _answerService;

        public AnswerController(UserManager<IdentityUser> userManager, ExamService examService, QuestionService questionService, AnswerService answerService)
        {
            _userManager = userManager;
            _examService = examService;
            _questionService = questionService;
            _answerService = answerService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                string userId = _userManager.GetUserId(User);
                List<SelectListItem> examsForViewModel = _examService.GetExamsByUserId(userId)
                    .Select(e => new SelectListItem
                    {
                        Value = e.Id,
                        Text = e.Title
                    }).ToList();
                AnswerCreateModel ac = new AnswerCreateModel();
                ac.dto = new AnswerDTO();
                ac.Exams = examsForViewModel;
                return View(ac);
            }
            return Content("probably not logged in");
        }
        [HttpPost]
        public IActionResult Index(AnswerCreateModel viewModel)
        {
            string userId = _userManager.GetUserId(User);
            viewModel.Exams = _examService.GetExamsByUserId(userId)
            .Select(e => new SelectListItem
             {
                Value = e.Id,
                Text = e.Title
            }).ToList();
            if (viewModel.SelectedExamId != null)
            {
                viewModel.Questions = _questionService.GetQuestionsByExamId(viewModel.SelectedExamId)
                    .Select(q => new SelectListItem
                    {
                        Value = q.Id,
                        Text = q.Body
                    }).ToList();
            }
            if (viewModel.dto.QuestionId != null)
            {
                Answer answerForDb = new Answer(viewModel.dto.QuestionId, viewModel.dto.Body, viewModel.dto.IsCorrect);
                _answerService.Create(answerForDb);
            }
            return View(viewModel);
        }
    }
}
