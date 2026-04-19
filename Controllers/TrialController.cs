using maturigo.Models.DTOs;
using maturigo.Models.ViewModels;
using maturigo.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace maturigo.Controllers
{
    public class TrialController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ExamService _examService;
        private readonly QuestionService _questionService;
        private readonly AnswerService _answerService;
        public TrialController(UserManager<IdentityUser> userManager, ExamService examService, QuestionService questionService, AnswerService answerService)
        {
            _userManager = userManager;
            _examService = examService;
            _questionService = questionService;
            _answerService = answerService;
        }

        public IActionResult Index()
        {
            TrialIndexModel viewModel = new TrialIndexModel();
            viewModel.Exams = _examService.GetAllExams()
                .Select(e => new ExamDTO
                { 
                    Title = e.Title,
                    Id = e.Id,
                }).ToList();
            return View(viewModel);
        }

        public IActionResult Trying(string id)
        {
            TrialTryingModel viewModel = new TrialTryingModel();
            viewModel.questions = _questionService.GetQuestionsByExamId(id)
                .Select(q => new QuestionDTO
                {
                    Body = q.Body
                }).ToList();
            return View(viewModel);
        }
    }
}
