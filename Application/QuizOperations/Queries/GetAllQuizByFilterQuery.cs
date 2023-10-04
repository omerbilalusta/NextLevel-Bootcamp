using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NextLevel_Bootcamp_FinalWork.Models.AppDbContext;
using NextLevel_Bootcamp_FinalWork.Models.ViewModels;

namespace NextLevel_Bootcamp_FinalWork.Application.QuizOperations.Queries
{
    public class GetAllQuizByFilterQuery
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public int ID { get; set; }
        public GetAllQuizByFilterQuery(AppDbContext context, IMapper mapper, int id)
        {
            _context = context;
            _mapper = mapper;
            ID = id;
        }
        public List<QuizViewModel> Handle()
        {
            //var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
            var userId = _context.Users.FirstOrDefault(c => c.ID == 5);
            var quizs = _context.Quizzes.Where(x => x.UserID == ID).ToList();
            List<QuizViewModel> quizListViewModel = new List<QuizViewModel>();

            foreach (var item in quizs)
            {
                quizListViewModel.Add(_mapper.Map<QuizViewModel>(item));
            }
            return quizListViewModel;
        }
    }
}


