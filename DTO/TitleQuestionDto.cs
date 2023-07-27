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
        public Title Title { get; set; }
        public int TitleID { get; set; }
        public List<TitleQuestion> TitleQuestions { get; set; } = new List<TitleQuestion>();
        public List<Title> Titles { get; set; } = new List<Title>();
        public string ReturnUrl { get; set; } = "/";

    }
}
