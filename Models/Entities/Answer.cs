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
        public string Id { get; set; }
        public string QuestionId { get; set; }
        public string Body { get; set; }
        public bool IsCorrect { get; set; }

        public void Copy(Answer other)
        {
            this.Id = other.Id;
            this.QuestionId = other.QuestionId;
            this.Body = other.Body;
            this.IsCorrect = other.IsCorrect;
        }
    }
}
