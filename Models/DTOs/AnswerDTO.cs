namespace maturigo.Models.DTOs
{
    public class AnswerDTO
    {
        public string QuestionId { get; set; }
        public string Body { get; set; }
        public bool IsCorrect { get; set; }
    }
}
