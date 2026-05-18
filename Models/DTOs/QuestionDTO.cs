namespace maturigo.Models.DTOs
{
    public class QuestionDTO
    {
        public string Id { get; set; }
        public string Body { get; set; }
        public string ExamId { get; set; }

        public List<AnswerDTO> Answers { get; set; } = new List<AnswerDTO>();

        public string GivenAnswerId { get; set; }
    }
}
