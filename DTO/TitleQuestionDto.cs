using DTO.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TitleQuestionDto : Dto, IDto
    {
        public string Content { get; set; } = "";
        public int Weight { get; set; }
        public TitleDto Title { get; set; }
        public int TitleID { get; set; }
        public List<TitleQuestionDto> TitleQuestions { get; set; } = new List<TitleQuestionDto>();
        public List<TitleDto> Titles { get; set; } = new List<TitleDto>();
        public string ReturnUrl { get; set; } = "/";

    }
}
