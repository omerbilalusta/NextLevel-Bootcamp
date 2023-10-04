using NextLevel_Bootcamp_FinalWork.Models.Models;

namespace NextLevel_Bootcamp_FinalWork.Models.ViewModels
{
    public class QuizCreateViewModel
    {
        public string Name { get; set; }        //Quiz name
        public string Content1 { get; set; }
        public bool Type1 { get; set; }
        public string Content2 { get; set; }
        public bool Type2 { get; set; }
        public string Content3 { get; set; }
        public bool Type3 { get; set; }
        public string Content4 { get; set; }
        public bool Type4 { get; set; }
        public string Content5 { get; set; }
        public bool Type5 { get; set; }
        public int QuestionID { get; set; }
    }
}
