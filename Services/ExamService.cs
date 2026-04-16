using Humanizer;
using maturigo.Data;
using maturigo.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
namespace maturigo.Services
{
    public class ExamService
    {
        private readonly MaturigoDbContext _context;
        public ExamService(MaturigoDbContext context)
        {
            _context = context;
        }

        public void Create(Exam exam)
        {
            _context.Exams.Add(exam);
            _context.SaveChanges();
        }
    }
}
