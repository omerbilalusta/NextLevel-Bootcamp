namespace NextLevel_Bootcamp_FinalWork.Models.Models
{
    public class Quiz_Question
    {
        public int Id { get; set; }
        public int QuizID { get; set; }
        public Quiz Quiz { get; set; }
        public int QuestionID { get; set; }
        public Question Question { get; set; }
    }
}
