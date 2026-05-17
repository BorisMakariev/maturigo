namespace maturigo.Models.DTOs
{
    public class ExamDTO
    {
        public string Title { get; set; }
        public string Id {  get; set; }

        public List<QuestionDTO> Questions { get; set; } = new List<QuestionDTO>();
    }
}
