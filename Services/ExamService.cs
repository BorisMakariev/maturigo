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

        public List<Exam> GetExamsByUserId(string userId)
        {
            return _context.Exams.Where(e => e.OwnerId == userId).ToList();
        }

        public List<Exam> GetAllExams()
        {
            return _context.Exams.ToList();
        }

        public void DeleteById(string id)
        {
            _context.Exams.Remove(_context.Exams.First(e => e.Id == id));
            _context.SaveChanges();
        }

        public void Update(Exam exam)
        {
            Exam examFromDb = _context.Exams.FirstOrDefault(e => e.Id == exam.Id);
            if (examFromDb != null)
            {
                _context.Update(examFromDb);
                examFromDb.Copy(exam);
                _context.SaveChanges();
            }
        }
    }
}
