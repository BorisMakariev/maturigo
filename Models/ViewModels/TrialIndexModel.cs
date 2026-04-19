using maturigo.Models.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace maturigo.Models.ViewModels
{
    public class TrialIndexModel
    {
        public List<ExamDTO> Exams = new List<ExamDTO>();
    }
}
