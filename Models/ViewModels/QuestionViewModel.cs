using NextLevel_Bootcamp_FinalWork.Models.Models;

namespace NextLevel_Bootcamp_FinalWork.Models.ViewModels
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
