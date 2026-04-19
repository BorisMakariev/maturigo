using maturigo.Data;
using maturigo.Models.Entities;
namespace maturigo.Services
{
    public class AnswerService
    {
        private readonly MaturigoDbContext _context;
        public AnswerService(MaturigoDbContext context)
        {
            _context = context;
        }
        public void Create(Answer answer)
        {
            _context.Answers.Add(answer);
            _context.SaveChanges();
        }

        public List<Answer> GetAnswersByQuestionId(string questionId)
        {
            return _context.Answers.Where(a => a.QuestionId == questionId).ToList();
        }

        public void DeleteById(string id)
        {
            _context.Answers.Remove(_context.Answers.First(a => a.Id == id));
            _context.SaveChanges();
        }

        public void Update(Answer answer)
        {
            Answer answerFromDb = _context.Answers.FirstOrDefault(a => a.Id == answer.Id);
            if (answerFromDb != null)
            {
                _context.Update(answerFromDb);
                answerFromDb.Copy(answer);
                _context.SaveChanges();
            }
        }
    }
}
