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

        public void Create(Attempt attempt)
        {
            _context.Attempts.Add(attempt);
            _context.SaveChanges();
        }

        public Attempt GetByDateTime(DateTime datetime)
        {
            return _context.Attempts.FirstOrDefault(a => a.SubmissionDate == datetime);
        }
    }
}
