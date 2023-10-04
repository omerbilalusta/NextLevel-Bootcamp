using AutoMapper;
using NextLevel_Bootcamp_FinalWork.Models.AppDbContext;
using NextLevel_Bootcamp_FinalWork.Models.ViewModels;

namespace NextLevel_Bootcamp_FinalWork.Application.QuizOperations.Command
{
    public class ConfirmQuestionCommand
    {
        private readonly AppDbContext _context;
        public int _questionId { get; set; }
        public ConfirmQuestionCommand(AppDbContext context, int questionId)
        {
            _context = context;
            _questionId = questionId;
        }

        public void Handle()
        {
            var question = _context.Questions.Find(_questionId);
            question.Approved = true;
            question.Status = true;
            _context.SaveChanges();
        }
    }
}
