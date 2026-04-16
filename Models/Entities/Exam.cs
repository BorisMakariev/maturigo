using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace maturigo.Models.Entities
{
    public class Exam
    {
        public Exam(string ownerId, string title) 
        {
            OwnerId = ownerId;
            Title = title;
        }
        [Key]
        public  string Id { get; set; }
        public  string OwnerId { get; set; }
        public  string Title { get; set; }
    }
}
