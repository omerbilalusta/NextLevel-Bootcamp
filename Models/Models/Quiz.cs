namespace NextLevel_Bootcamp_FinalWork.Models.Models
{
    public class Quiz
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string quizType { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public List<Quiz_Question>? Quiz_Questions { get; set; }
        public List<Scoreboard>? Scoreboards { get; set; }
    }
}
