using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NextLevel_Bootcamp_FinalWork.Models.AppDbContext;
using NextLevel_Bootcamp_FinalWork.Models.Models;
using NextLevel_Bootcamp_FinalWork.Models.ViewModels;

namespace NextLevel_Bootcamp_FinalWork.Application.QuizOperations.Queries
{
    public class GetQuestionsByFilterId
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public int id { get; set; }
        public GetQuestionsByFilterId(AppDbContext context, IMapper mapper, int ID)
        {
            _context = context;
            _mapper = mapper;
            id = ID;
        }

        public List<QuestionsViewModel> Handle()
        {
            var quiz_questionList = _context.Quiz_Questions.Include(x => x.Question).Where(x => x.QuizID == id).Where(x => x.Question.Approved != false).ToList();
            var mappedQuestionList = new List<QuestionsViewModel>();
            foreach (var item in quiz_questionList)
            {
                mappedQuestionList.Add(new QuestionsViewModel
                {
                    ID = item.Question.ID,
                    Content = item.Question.Content
                });
            }

            return mappedQuestionList;
        }
    }
}
