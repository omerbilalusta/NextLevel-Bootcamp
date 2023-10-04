namespace NextLevel_Bootcamp_FinalWork.Models.Models
{
    public class Answer
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public bool Type { get; set; }
        public int QuestionID { get; set; }
        public Question Question { get; set; }
    }
}
