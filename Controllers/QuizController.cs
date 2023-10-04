using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NextLevel_Bootcamp_FinalWork.Application.QuizOperations.Command;
using NextLevel_Bootcamp_FinalWork.Application.QuizOperations.Queries;
using NextLevel_Bootcamp_FinalWork.Models.AppDbContext;
using NextLevel_Bootcamp_FinalWork.Models.ViewModels;

namespace NextLevel_Bootcamp_FinalWork.Controllers
{
    public class QuizController : Controller                            //JWT ile sisteme üye olduktan sonra giriş yapan kullanıcılar için Token oluşturabiliyorum ancak 
    {                                                                   //bu token'ı MVC projesinde Authorization işlemleri için kullanmayı başaramadım. Oysaki Request'ın header'ına yerleştirerek
        private readonly AppDbContext _context;                         //rol bazlı Authorization'ı gerçekleştirmem gerekirdi.
        private readonly IMapper _mapper;                               //Dolayısıyla JWT implementasyonunu %100 başarıyla tamamlayamadığım için rol bazlı yönlendirme ve 
        public QuizController(AppDbContext context, IMapper mapper)     //sisteme eklenen nesneleri kullanıcılarla eşleştiremedim. Quzilerin paylaşımlarını sınırlandırmak, Quizleri yanıtlamak gibi
        {                                                               //kritik özellikleri inşa edememe neden oldu.
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        //[Authorize]
        public IActionResult Index()
        {
            GetAllQuizByFilterQuery query = new GetAllQuizByFilterQuery(_context, _mapper, 1);
            var result = query.Handle();
            return View(result);
        }

        [HttpGet]
        public IActionResult AdminHomePage()
        {
            GetQuestionFilterByStatus query = new GetQuestionFilterByStatus(_context, _mapper);
            var result = query.Handle();
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            GetAllQuestionsQuery query = new GetAllQuestionsQuery(_context, _mapper);
            var result = query.Handle();

            ViewBag.QuestionList = new SelectList(result, "Key", "Value");

            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm]QuizCreateViewModel quizModel)
        {
            CreateQuizContentCommand command = new CreateQuizContentCommand(_context,_mapper, quizModel);
            command.Handle();

            return RedirectToAction("Index", "Quiz");
        }


        [HttpGet]
        public IActionResult DeleteQuiz(int id)
        {
            DeleteQuizCommand command = new DeleteQuizCommand(_context,_mapper, id);
            command.Handle();

            return RedirectToAction("Index", "Quiz");
        }



        [HttpGet]
        public IActionResult Details(int id)
        {
            GetQuizByIdQuery query1 = new GetQuizByIdQuery(_context, _mapper, id);
            var query = query1.Handle();
            ViewBag.quizName = query.Name;
            ViewBag.QuizID = query.Id;

            GetQuestionsByFilterId query2 = new GetQuestionsByFilterId(_context,_mapper, id);
            var result = query2.Handle();

            return View(result);
        }


        [HttpGet]
        public IActionResult DeleteQuestion(int id)
        {
            DeleteQuestionCommand command = new DeleteQuestionCommand(_context,_mapper, id);
            var result = command.Handle();

            if(result >= 0)
                //return RedirectToAction("Details", "Quiz", result);  //quizID model içerisinden buraya doğru şekilde geliyor ancak Details metodu çalışırken bu int ifadeyi görmüyor. Dolayısıyla Details metodu çalışırken QuizID ile işlem yapamıyoruz.
                return RedirectToAction("Index", "Quiz");
            else
                return View("Index", "Quiz");

        }

        [HttpGet]
        public IActionResult AddQuestion(int id)
        {
            GetQuizByIdQuery query1 = new GetQuizByIdQuery(_context, _mapper, id);
            var quiz = query1.Handle();
            ViewBag.quizName = quiz.Name;
            ViewBag.QuizID = quiz.Id;

            GetAllQuestionsQuery query2 = new GetAllQuestionsQuery(_context, _mapper);
            var questionsList = query2.Handle();
            ViewBag.QuestionList = new SelectList(questionsList, "Key", "Value");

            return View();
        }

        [HttpPost]
        public IActionResult AddQuestion(int id, [FromForm] AddQuestionViewModel model)
        {
            AddQuestionCommand command = new AddQuestionCommand(_context, _mapper, id, model);
            command.Handle();

            //return RedirectToAction("Details", "Quiz", model.QuizID); //quizID model içerisinden buraya doğru şekilde geliyor ancak DEtails metodu çalışırken bu int ifadeyi görmüyor. Dolayısıyla Details metodu çalışırken QuizID ile işlem yapamıyoruz.
            return RedirectToAction("Index", "Quiz");
        }

        [HttpGet]
        public IActionResult CreateQuestion()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateQuestion([FromForm] CreateQuestionViewModel model)
        {
            CreateQuestionCommand command = new CreateQuestionCommand(_context, _mapper, model);
            command.Handle();

            TempData["Status"] = "The question has been sent to admin for approval.";

            return RedirectToAction("Index", "Quiz");
        }

        [HttpGet]
        public IActionResult ConfirmQuestion(int questionId)
        {
            ConfirmQuestionCommand command = new ConfirmQuestionCommand(_context, questionId);
            command.Handle();
            TempData["QuestionStatus"] = "The question has been approved by you, just now!";

            return RedirectToAction("AdminHomePage", "Quiz");
        }
        [HttpGet]
        public IActionResult DeclineQuestion(int questionId)
        {
            DeclineQuestionCommand command = new DeclineQuestionCommand(_context, questionId);
            command.Handle();
            TempData["QuestionStatus"] = "The question has been decline by you, just now!";

            return RedirectToAction("AdminHomePage", "Quiz");
        }


        //[HttpGet]
        //public IActionResult Play(int id)
        //{
        //    GetQuizByIdQuery getQuizByIdQuery = new GetQuizByIdQuery(_context, _mapper, id);
        //    var quiz = getQuizByIdQuery.Handle();
        //    ViewBag.quizName = quiz.Name;
        //    ViewBag.QuizID = quiz.Id;


        //    GetQuestionsByFilter getQuestionsByFilter = new GetQuestionsByFilter(_context, _mapper, id);
        //    var questionList = getQuestionsByFilter.Handle();

        //    GetAnswersByFilter getAnswersByFilter = new GetAnswersByFilter(_context, _mapper, questionList);
        //    var answerList = getQuestionsByFilter.Handle();

        //    List<QuestionAnswerViewModel> questionAnswerList = new List<QuestionAnswerViewModel>();

        //    foreach (var item in answerList)
        //    {

        //    }
        //}
    }
}
