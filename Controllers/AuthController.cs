using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NextLevel_Bootcamp_FinalWork.Application.AuthOperations.Commands;
using NextLevel_Bootcamp_FinalWork.Application.AuthOperations.Queries;
using NextLevel_Bootcamp_FinalWork.Models.AppDbContext;
using NextLevel_Bootcamp_FinalWork.Models.ViewModels;
using System.Security.Claims;

namespace NextLevel_Bootcamp_FinalWork.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AuthController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LogIn([FromForm] LogInViewModel model)
        {
            LogInQuery query = new LogInQuery(_context);
            query.model = model;
            var result = query.Handle();

            //var asd = HttpContext.User.Identity.IsAuthenticated;
            //var asddasd = User?.Identity?.Name;

            if (result.IsSuccess == true)
                return RedirectToAction("Index", "Home");
            else
            {
                TempData["LogInMessage"] = "Hatalı kullanıcı adı veya şifre";
                return RedirectToAction("Index", "Auth");
            }
        }
        
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult SignUp([FromForm] SignUpViewModel model)
        {
            if(ModelState.IsValid)
            {
                SignUpCommand command = new SignUpCommand(_context, _mapper);
                command.model = model;
                var result = command.Handle();

                if (result == "1")
                {
                    TempData["SignUpMessage"] = "Bu mail zaten kayıtlı. Giriş yapmayı deneyin.";
                    return RedirectToAction("Register", "Auth");
                }
                else if (result == "2")
                {
                    TempData["SignUpMessage"] = "Şifre koşulları karşılamıyor.\nEn az bir büyük, bir küçük, birde rakam içermeli ve 8 karakterden az olmamalıdır.";
                    return RedirectToAction("Register", "Auth");
                }
                return RedirectToAction("Index", "Auth");
            }
            return RedirectToAction("Register", "Auth");
        }
    }
}
