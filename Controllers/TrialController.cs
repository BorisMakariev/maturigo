using maturigo.Models.DTOs;
using maturigo.Models.ViewModels;
using maturigo.Services;
using Microsoft.AspNetCore.Mvc;

namespace maturigo.Controllers
{
    public class TrialController : Controller
    {
        private readonly ExamService _examService;
        public TrialController(ExamService examService)
        {
            _examService = examService;
        }

        public IActionResult Index()
        {
            TrialIndexModel viewModel = new TrialIndexModel();
            viewModel.Exams = _examService.GetAllExams()
                .Select(e => new ExamDTO
                { 
                    Title = e.Title
                }).ToList();
            return View(viewModel);
        }
    }
}
