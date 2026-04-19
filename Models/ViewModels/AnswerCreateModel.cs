using maturigo.Models.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace maturigo.Models.ViewModels
{
    public class AnswerCreateModel
    {
        public AnswerCreateModel() { }
        public AnswerDTO dto { get; set; }

        public string SelectedExamId {  get; set; }

        public List<SelectListItem> Exams = new List<SelectListItem>();
        public List<SelectListItem> Questions = new List<SelectListItem>();
    }
}
