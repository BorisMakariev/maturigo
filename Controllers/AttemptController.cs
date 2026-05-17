using maturigo.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using maturigo.Models.ViewModels.Attempt;

namespace maturigo.Controllers
{
    public class AttemptController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AttemptService _attemptService;

        public AttemptController(UserManager<IdentityUser> userManager, AttemptService attemptService)
        {
            _userManager = userManager;
            _attemptService = attemptService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Make(string id)
        {
            MakeVM viewModel = new MakeVM();
            viewModel.examDTO = _attemptService.GetExamDtoByExamId(id);
            return View(viewModel);
        }
    }
}
