using AutoMapper;
using NextLevel_Bootcamp_FinalWork.Models.AppDbContext;
using NextLevel_Bootcamp_FinalWork.Models.Models;
using NextLevel_Bootcamp_FinalWork.Models.ViewModels;

namespace NextLevel_Bootcamp_FinalWork.Application.QuizOperations.Command
{
    public class AddQuestionCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public int id { get; set; }
        public AddQuestionViewModel model { get; set; }
        public AddQuestionCommand(AppDbContext context, IMapper mapper, int ID, AddQuestionViewModel _model)
        {
            _context = context;
            _mapper = mapper;
            id = ID;
            model = _model;
        }

        public void Handle()
        {
            List<Answer> answers = new List<Answer>();

            var answer = new Answer();
            var answer2 = new Answer();
            var answer3 = new Answer();
            var answer4 = new Answer();
            var answer5 = new Answer();
            var Quiz_Question = new Quiz_Question();

            answer.QuestionID = model.QuestionID;
            answer.Content = model.Content1;
            answer.Type = model.Type1;
            answers.Add(answer);

            answer2.QuestionID = model.QuestionID;
            answer2.Content = model.Content2;
            answer2.Type = model.Type2;
            answers.Add(answer2);

            answer3.QuestionID = model.QuestionID;
            answer3.Content = model.Content3;
            answer3.Type = model.Type3;
            answers.Add(answer3);

            answer4.QuestionID = model.QuestionID;
            answer4.Content = model.Content4;
            answer4.Type = model.Type4;
            answers.Add(answer4);

            answer5.QuestionID = model.QuestionID;
            answer5.Content = model.Content5;
            answer5.Type = model.Type5;
            answers.Add(answer5);

            Quiz_Question.QuestionID = model.QuestionID;
            Quiz_Question.QuizID = model.QuizID;
            _context.Quiz_Questions.Add(Quiz_Question);

            _context.Answers.AddRange(answers);
            _context.SaveChanges();
        }
    }
}
