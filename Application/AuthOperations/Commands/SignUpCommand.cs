using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NextLevel_Bootcamp_FinalWork.Models.AppDbContext;
using NextLevel_Bootcamp_FinalWork.Models.Models;
using NextLevel_Bootcamp_FinalWork.Models.ViewModels;
using System.Security.Cryptography;
using System.Text;

namespace NextLevel_Bootcamp_FinalWork.Application.AuthOperations.Commands
{
    public class SignUpCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public SignUpViewModel model { get; set; }

        public SignUpCommand(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public string Handle()
        {
            var userCheck = _context.Users.FirstOrDefault(x => x.Email == model.Email);
            if (userCheck != null)
                return "1"; //Email hali hazırda kullanılıyor.
            var user = _mapper.Map<User>(model);
            user.UserType = _context.UserTypes.FirstOrDefault(x => x.ID == 2);

            if (!PasswordCheck(model.Password))
                return "2";

            user.Password = Encrypt(user.Password);

            _context.Users.Add(user);
            _context.SaveChanges();

            return "3";
        }

        public bool PasswordCheck(string password)
        {
            bool hasNum = false, hasUpper = false, hasLower = false;

            if (string.IsNullOrEmpty(password))
                return false;
            else if (password.Length < 8)
                return false;

            else
            {
                foreach (var item in password)
                {
                    if (char.IsDigit(item))
                        hasNum = true;
                    else if (char.IsLower(item))
                        hasLower = true;
                    else if (char.IsUpper(item))
                        hasUpper = true;
                    if (hasNum && hasLower && hasUpper)
                        return true;
                }
                return false;
            }
        }

        public  string Encrypt(string passwordText)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(passwordText));

                // Convert the byte array to a string and return it.
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
