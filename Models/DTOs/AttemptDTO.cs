namespace maturigo.Models.DTOs
{
    public class AttemptDTO
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string ExamId { get; set; }
        public int Score { get; set; }
        public DateTime SubmissionDate { get; set; }
        public List<GivenAnswerDTO> GivenAnswerDTOs { get; set; }
    }
}
