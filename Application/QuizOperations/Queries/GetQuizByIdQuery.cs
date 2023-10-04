using AutoMapper;
using NextLevel_Bootcamp_FinalWork.Models.AppDbContext;
using NextLevel_Bootcamp_FinalWork.Models.ViewModels;

namespace NextLevel_Bootcamp_FinalWork.Application.QuizOperations.Queries
{
    public class GetQuizByIdQuery
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public int id { get; set; }
        public GetQuizByIdQuery(AppDbContext context, IMapper mapper, int ID)
        {
            _context = context;
            _mapper = mapper;
            id = ID;
        }
        public QuizViewModel Handle()
        {
            var query =  _context.Quizzes.Find(id);
            var result = _mapper.Map<QuizViewModel>(query);

            return result;
        }
    }
}
