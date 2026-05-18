using System.ComponentModel.DataAnnotations;

namespace maturigo.Models.Entities
{
    public class Attempt
    {
        [Key]
        public string Id { get; set; }
        public string UserId { get; set; }
        public string ExamId { get; set; }
        public int Score { get; set; }
        public DateTime SubmissionDate { get; set; }   
    }
}
