using maturigo.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using maturigo.Models.ViewModels.Attempt;
using maturigo.Models.DTOs;
using maturigo.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace maturigo.Controllers
{
    public class AttemptController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AttemptService _attemptService;
        private readonly QuestionService _questionService;
        private readonly ExamService _examService;
        private readonly AnswerService _answerService;
        private readonly GivenAnswerService _givenAnswerService;

        public AttemptController(UserManager<IdentityUser> userManager, AttemptService attemptService, QuestionService questionService, ExamService examService, AnswerService answerService, GivenAnswerService givenAnswerService)
        {
            _userManager = userManager;
            _attemptService = attemptService;
            _questionService = questionService;
            _examService = examService;
            _answerService = answerService;
            _givenAnswerService = givenAnswerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Make(string id)
        {
            if (User.Identity.IsAuthenticated == false) return Redirect("/Identity/Account/Login");
            string userId = _userManager.GetUserId(User);
            MakeVM viewModel = new MakeVM()
            {
                UserId = userId
            };

            ExamDTO examDtoForVM = new ExamDTO();
            Exam exam = _examService.GetExamById(id);
            if (exam == null)
            {
                return null;
            }
            examDtoForVM.Title = exam.Title;
            examDtoForVM.Id = exam.Id;
            List<QuestionDTO> questionDTOs = new List<QuestionDTO>();
            List<Question> questions = _questionService.GetQuestionsByExamId(examDtoForVM.Id);
            foreach (Question question in questions)
            {
                List<AnswerDTO> answerDTOs = new List<AnswerDTO>();
                List<Answer> answers = _answerService.GetAnswersByQuestionId(question.Id);
                foreach (Answer answer in answers)
                {
                    answerDTOs.Add(new AnswerDTO
                    {
                        QuestionId = answer.QuestionId,
                        Body = answer.Body,
                        IsCorrect = answer.IsCorrect,
                        Id = answer.Id
                    });
                }
                questionDTOs.Add(new QuestionDTO
                {
                    Id = question.Id,
                    ExamId = question.ExamId,
                    Body = question.Body,
                    Answers = answerDTOs
                });
            }
            examDtoForVM.Questions = questionDTOs;
            viewModel.examDTO = examDtoForVM;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Make(MakeVM returnedVM)
        {
            int score = 0;
            foreach (var question in returnedVM.examDTO.Questions)
            {
                if (question.GivenAnswerId == null)
                {
                    foreach (var answer in question.Answers)
                    {
                        if (answer.IsCorrect)
                        {
                            score++;
                        }
                    }
                }else
                {
                    Answer answer = _answerService.GetAnswerById(question.GivenAnswerId);
                    if (answer.IsCorrect)
                    {
                        score++;
                    }
                }
            }
            DateTime submitTime = DateTime.Now;
            Attempt attempt = new Attempt()
            {
                ExamId = returnedVM.examDTO.Id,
                UserId = returnedVM.UserId,
                Score = score,
                SubmissionDate = submitTime,
            };
            _attemptService.Create(attempt);
            attempt = _attemptService.GetByDateTime(submitTime);
            foreach (var question in returnedVM.examDTO.Questions)
            {
                if (question.GivenAnswerId == null)
                {
                    foreach (var answer in question.Answers)
                    {
                        if (answer.IsSelected == true)
                        {
                            GivenAnswer givenAnswer = new GivenAnswer()
                            {
                                AnswerId = answer.Id,
                                AttemptId = attempt.Id,
                                QuestionId = question.Id,
                            };
                            _givenAnswerService.Create(givenAnswer);
                        }
                    }
                }
                else
                {
                    GivenAnswer givenAnswer = new GivenAnswer()
                    {
                        AnswerId = question.GivenAnswerId,
                        AttemptId = attempt.Id,
                        QuestionId = question.Id,
                    };
                    _givenAnswerService.Create(givenAnswer);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
