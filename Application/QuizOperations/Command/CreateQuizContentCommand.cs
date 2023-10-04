using AutoMapper;
using NextLevel_Bootcamp_FinalWork.Models.AppDbContext;
using NextLevel_Bootcamp_FinalWork.Models.Models;
using NextLevel_Bootcamp_FinalWork.Models.ViewModels;

namespace NextLevel_Bootcamp_FinalWork.Application.QuizOperations.Command
{
    public class CreateQuizContentCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private QuizCreateViewModel _model;
        public int ID { get; set; }
        public CreateQuizContentCommand(AppDbContext context, IMapper mapper, QuizCreateViewModel model)
        {
            _context = context;
            _mapper = mapper;
            _model = model;
        }

        public void Handle()
        {
            //var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id").Value;

            var userId = _context.Users.FirstOrDefault(c => c.ID == 5).ID;
            Quiz quiz = new Quiz();
            quiz.Name = _model.Name;
            quiz.quizType = "1";
            quiz.UserID = userId;            //Değiştirilecek !!!!!!!!!!!!!

            _context.Quizzes.Add(quiz);
            _context.SaveChanges();  //Bütün eklenenleri method sonunda kaydetmeye çalışıtığımızda Quiz_Question tablosu Quiz'i göremediği patlıyor

            List<Answer> answers = new List<Answer>();

            var answer = new Answer();
            var answer2 = new Answer();
            var answer3 = new Answer();
            var answer4 = new Answer();
            var answer5 = new Answer();
            var Quiz_Question = new Quiz_Question();

            answer.QuestionID = _model.QuestionID;
            answer.Content = _model.Content1;
            answer.Type = _model.Type1;
            answers.Add(answer);

            answer2.QuestionID = _model.QuestionID;
            answer2.Content = _model.Content2;
            answer2.Type = _model.Type2;
            answers.Add(answer2);

            answer3.QuestionID = _model.QuestionID;
            answer3.Content = _model.Content3;
            answer3.Type = _model.Type3;
            answers.Add(answer3);

            answer4.QuestionID = _model.QuestionID;
            answer4.Content = _model.Content4;
            answer4.Type = _model.Type4;
            answers.Add(answer4);

            answer5.QuestionID = _model.QuestionID;
            answer5.Content = _model.Content5;
            answer5.Type = _model.Type5;
            answers.Add(answer5);

            Quiz_Question.QuestionID = _model.QuestionID;
            Quiz_Question.QuizID = quiz.ID;
            _context.Quiz_Questions.Add(Quiz_Question);

            _context.Answers.AddRange(answers);
            _context.SaveChanges();

        }
    }
}
