using AutoMapper;
using NextLevel_Bootcamp_FinalWork.Models.AppDbContext;
using NextLevel_Bootcamp_FinalWork.Models.ViewModels;

namespace NextLevel_Bootcamp_FinalWork.Application.QuizOperations.Command
{
    public class DeleteQuestionCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private int id { get; set; }
        public DeleteQuestionCommand(AppDbContext context, IMapper mapper, int _id)
        {
            _context = context;
            _mapper = mapper;
            id = _id;
        }

        public int Handle()
        {
            var quiz_questionList = _context.Quiz_Questions.ToList();
            _context.Quiz_Questions.RemoveRange(quiz_questionList.Where(x => x.QuestionID == id).ToList());
            _context.Answers.RemoveRange(_context.Answers.Where(x => x.QuestionID == id).ToList());
            _context.SaveChanges();

            var quizID = quiz_questionList.FirstOrDefault(x => x.QuestionID == id).QuizID;

            if (quizID.ToString() != null)
            {
                return quizID;
            }
            else
            {
                _context.Quizzes.Remove(_context.Quizzes.FirstOrDefault(x => x.ID == quizID));
                return -1;
            }

        }
    }
}
