using AutoMapper;
using NextLevel_Bootcamp_FinalWork.Models.AppDbContext;
using NextLevel_Bootcamp_FinalWork.Models.Models;

namespace NextLevel_Bootcamp_FinalWork.Application.QuizOperations.Queries
{
    public class GetAllQuestionsQuery
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public GetAllQuestionsQuery(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Dictionary<int, string> Handle()
        {
            List<Question> questionList = _context.Questions.Where(x=>x.Status != false).ToList();
            var mappedQuestionList = new Dictionary<int, string>();

            foreach (var item in questionList)
            {
                mappedQuestionList.Add(item.ID, item.Content);
            }

            return mappedQuestionList;
        }
    }
}
