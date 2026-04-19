using maturigo.Data;
using maturigo.Models.Entities;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.CRUD;
namespace maturigo.Services
{
    public class QuestionService
    {
        private readonly MaturigoDbContext _context;
        public QuestionService(MaturigoDbContext context)
        {
            _context = context;
        }

        public void Create(Question question)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();
        }

        public List<Question> GetQuestionsByExamId(string examId)
        {
            return _context.Questions.Where(q => q.ExamId == examId).ToList();
        }

        public void DeleteById(string id)
        {
            _context.Questions.Remove(_context.Questions.First(q => q.Id == id));
            _context.SaveChanges();
        }

        public void Update(Question question)
        {
            Question questionFromDb = _context.Questions.FirstOrDefault(q => q.Id == question.Id);
            if (questionFromDb != null)
            {
                _context.Update(questionFromDb);
                questionFromDb.Copy(question);
                _context.SaveChanges();
            }
        }
    }
}
