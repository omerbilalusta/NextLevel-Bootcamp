using AutoMapper;
using NextLevel_Bootcamp_FinalWork.Models.AppDbContext;
using NextLevel_Bootcamp_FinalWork.Models.Models;
using NextLevel_Bootcamp_FinalWork.Models.ViewModels;

namespace NextLevel_Bootcamp_FinalWork.Application.QuizOperations.Queries
{
    public class GetQuestionFilterByStatus
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public GetQuestionFilterByStatus(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<QuestionsViewModel> Handle()
        {
            var questionList = _context.Questions.Where(x=> x.Status == false).Where(x=> x.Approved != false).ToList();
            var mappedQuestionList = _mapper.Map<List<QuestionsViewModel>>(questionList);

            return mappedQuestionList;
        }
    }
}
