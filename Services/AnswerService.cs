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
    }
}
