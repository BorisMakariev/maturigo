using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace maturigo.Models.Entities
{
    public class Question
    {

        public Question(string examId, string body)
        {
            ExamId = examId;
            Body = body;
        }

        [Key]
        public string Id { get; set; }
        public string ExamId { get; set; }
        public string Body { get; set; }

        public void Copy(Question other)
        {
            this.Id = other.Id;
            this.ExamId = other.ExamId;
            this.Body = other.Body;
        }
    }
}
