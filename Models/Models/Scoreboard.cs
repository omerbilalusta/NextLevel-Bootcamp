namespace NextLevel_Bootcamp_FinalWork.Models.Models
{
    public class Scoreboard
    {
        public int ID { get; set; }
        public int? CorrectAnswerCount { get; set; }
        public int? FalseAnswerCount { get; set; }
        public User? User { get; set; }
        public Quiz? Quiz { get; set; }
    }
}
