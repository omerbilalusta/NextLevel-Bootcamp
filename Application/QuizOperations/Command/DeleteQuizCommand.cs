using AutoMapper;
using NextLevel_Bootcamp_FinalWork.Models.AppDbContext;

namespace NextLevel_Bootcamp_FinalWork.Application.QuizOperations.Command
{
    public class DeleteQuizCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public int id { get; set; }
        public DeleteQuizCommand(AppDbContext context, IMapper mapper, int ID)
        {
            _context = context;
            _mapper = mapper;
            id = ID;
        }

        public void Handle()
        {
            var quiz = _context.Quizzes.Find(id);
            var quiz_questionsList = _context.Quiz_Questions.Where(x => x.QuizID == id).ToList();
            var scoreboardList = _context.Scoreboards.Where(x => x.Quiz.ID == id).ToList();

            foreach (var item in quiz_questionsList)
            {
                _context.Answers.RemoveRange(_context.Answers.Where(x => x.QuestionID == item.QuestionID).ToList());// Answer'lar silindi.
                _context.Questions.Remove(_context.Questions.Find(item.QuestionID)); //Question'da silindi.
            }
            _context.Quiz_Questions.RemoveRange(quiz_questionsList);//Quiz_Questions'dakiler silindi.
            _context.Quizzes.Remove(quiz);//Quiz'in kendisi silindi.
            _context.Scoreboards.RemoveRange(scoreboardList);

            _context.SaveChanges();

        }
    }
}
