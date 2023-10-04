using AutoMapper;
using NextLevel_Bootcamp_FinalWork.Models.AppDbContext;
using NextLevel_Bootcamp_FinalWork.Models.Models;
using NextLevel_Bootcamp_FinalWork.Models.ViewModels;

namespace NextLevel_Bootcamp_FinalWork.Application.QuizOperations.Queries
{
    public class GetAnswersByFilter
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public List<QuestionsViewModel> _questionList { get; set; }
        public GetAnswersByFilter(AppDbContext context, IMapper mapper, List<QuestionsViewModel> questionList)
        {
            _context = context;
            _mapper = mapper;
            _questionList = questionList;
        }

        public List<AnswerContentViewModel> Handle()
        {
            List<Answer> answerList = new List<Answer>();
            List<AnswerContentViewModel> answerMappedList = new List<AnswerContentViewModel>();
            foreach (var item in _questionList)
            {
                answerList = _context.Answers.Where(x => x.QuestionID == item.ID).ToList();
                
                foreach (var answer in answerList)
                {
                    answerMappedList.Add(_mapper.Map<AnswerContentViewModel>(answer));
                }
            }
            
            return answerMappedList;
        }
    }
}
