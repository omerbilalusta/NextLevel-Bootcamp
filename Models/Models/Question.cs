namespace NextLevel_Bootcamp_FinalWork.Models.Models
{
    public class Question
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
        public bool? Approved { get; set; }
        public List<Answer> Answers { get; set; }
        public List<Quiz_Question>? Quiz_Questions { get; set; }
    }
}
