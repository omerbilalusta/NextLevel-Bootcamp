using AutoMapper;
using NextLevel_Bootcamp_FinalWork.Models.Models;
using NextLevel_Bootcamp_FinalWork.Models.ViewModels;

namespace NextLevel_Bootcamp_FinalWork.Common
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SignUpViewModel, User>();
            CreateMap<AnswerViewModel, Answer>();
            CreateMap<QuizCreateViewModel, Quiz>();
            CreateMap<Quiz, QuizViewModel>();
            CreateMap<Question, QuestionsViewModel>();
            CreateMap<Answer, AnswerContentViewModel>();
            CreateMap<CreateQuestionViewModel, Question>();
        }
    }
}
