using System.ComponentModel.DataAnnotations;

namespace maturigo.Models.Entities
{
    public class GivenAnswer
    {
        [Key]
        public string Id { get; set; }
        public string AttemptId { get; set; }
        public string AnswerId { get; set; }
        public string QuestionId { get; set; }
    }
}
