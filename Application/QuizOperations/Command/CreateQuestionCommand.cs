using AutoMapper;
using NextLevel_Bootcamp_FinalWork.Models.AppDbContext;
using NextLevel_Bootcamp_FinalWork.Models.Models;
using NextLevel_Bootcamp_FinalWork.Models.ViewModels;

namespace NextLevel_Bootcamp_FinalWork.Application.QuizOperations.Command
{
    public class CreateQuestionCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CreateQuestionViewModel _model { get; set; }
        public CreateQuestionCommand(AppDbContext context, IMapper mapper, CreateQuestionViewModel model)
        {
            _context = context;
            _mapper = mapper;
            _model = model;
        }

        public void Handle()
        {
            var question = _mapper.Map<Question>(_model);
            question.Status = false;
            _context.Questions.Add(question);
            _context.SaveChanges();
        }
    }
}
