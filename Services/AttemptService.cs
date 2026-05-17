using maturigo.Data;
using maturigo.Models.DTOs;
using maturigo.Models.Entities;

namespace maturigo.Services
{
    public class AttemptService
    {
        private readonly MaturigoDbContext _context;
        public AttemptService(MaturigoDbContext context)
        {
            _context = context;
        }

        public ExamDTO GetExamDtoByExamId(string id)
        {
            ExamDTO resultDto = new ExamDTO();
            Exam exam = _context.Exams.FirstOrDefault(x => x.Id == id);
            if (exam == null)
            {
                return null;
            }
            resultDto.Title = exam.Title;
            resultDto.Id = exam.Id;
            List<QuestionDTO> questionDTOs = new List<QuestionDTO>();
            List<Question> questions = _context.Questions.Where(q => q.ExamId == resultDto.Id).ToList();
            foreach (Question question in questions) 
            {
                List<AnswerDTO> answerDTOs = new List<AnswerDTO>();
                List<Answer> answers = _context.Answers.Where(a => a.QuestionId == question.Id).ToList();
                foreach (Answer answer in answers)
                {
                    answerDTOs.Add(new AnswerDTO
                    {
                        QuestionId = answer.QuestionId,
                        Body = answer.Body,
                        IsCorrect = answer.IsCorrect
                    });
                }
                questionDTOs.Add(new QuestionDTO
                {
                    ExamId = question.ExamId,
                    Body = question.Body,
                    Answers = answerDTOs
                });
            }
            resultDto.Questions = questionDTOs;

            return resultDto;
        }
    }
}
