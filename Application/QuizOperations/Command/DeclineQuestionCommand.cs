using NextLevel_Bootcamp_FinalWork.Models.AppDbContext;

namespace NextLevel_Bootcamp_FinalWork.Application.QuizOperations.Command
{
    public class DeclineQuestionCommand
    {
        private readonly AppDbContext _context;
        public int _questionId { get; set; }
        public DeclineQuestionCommand(AppDbContext context, int questionId)
        {
            _context = context;
            _questionId = questionId;
        }

        public void Handle()
        {
            var question = _context.Questions.Find(_questionId);
            question.Approved = false;
            _context.SaveChanges();
        }
    }
}
