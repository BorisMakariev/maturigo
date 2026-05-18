using maturigo.Data;
using maturigo.Models.Entities;

namespace maturigo.Services
{
    public class GivenAnswerService
    {
        private readonly MaturigoDbContext _context;

        public GivenAnswerService(MaturigoDbContext context)
        {
            _context = context;
        }

        public void Create(GivenAnswer givenAnswer)
        {
            _context.GivenAnswers.Add(givenAnswer);
            _context.SaveChanges();
        }
    }
}
