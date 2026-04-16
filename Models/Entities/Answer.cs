using System.ComponentModel.DataAnnotations;

namespace maturigo.Models.Entities
{
    public class Answer
    {
        public Answer(string questionId, string body, bool isCorrect) 
        {
            QuestionId = questionId;
            Body = body;
            IsCorrect = isCorrect;
        }

        [Key]
        public required string Id { get; set; }
        public required string QuestionId { get; set; }
        public required string Body { get; set; }
        public required bool IsCorrect { get; set; }
    }
}
