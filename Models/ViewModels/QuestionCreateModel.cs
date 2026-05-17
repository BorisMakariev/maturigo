using maturigo.Models.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace maturigo.Models.ViewModels
{
    public class QuestionCreateModel
    {
        public QuestionCreateModel() 
        {

        }

        public List<SelectListItem> Exams = new List<SelectListItem>();

        public QuestionDTO dto {get; set;}

        public string linkToImage = "https://i.ytimg.com/vi/kwbnCDeejbc/maxresdefault.jpg";

        //public string 
    }
}
