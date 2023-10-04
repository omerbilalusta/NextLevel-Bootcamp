using Microsoft.AspNetCore.Mvc;
using NextLevel_Bootcamp_FinalWork.Models.AppDbContext;
using NextLevel_Bootcamp_FinalWork.Models.ViewModels;
using System.Text;
using System.Security.Cryptography;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using NextLevel_Bootcamp_FinalWork.Models.Models;
using NextLevel_Bootcamp_FinalWork.Models;
using Microsoft.EntityFrameworkCore;

namespace NextLevel_Bootcamp_FinalWork.Application.AuthOperations.Queries
{
    public class LogInQuery : Controller
    {
        private readonly AppDbContext _context;
        public LogInViewModel model { get; set; }
        //private readonly JwtConfig _jwtConfig;

        public LogInQuery(AppDbContext context)
        {
            _context = context;
        }

        public DataResponse<string> Handle()
        {
            var user = _context.Users.Include(b=> b.UserType).FirstOrDefault(b=> b.Email == model.Email);
            DataResponse<string> result = new DataResponse<string>("");

            if (user == null)
            {
                result.IsSuccess = false;
                return result; //Hatalı Mail
            }
            else if (user.Password != Encrypt(model.Password)) //Sistemde SHA256 ile şifrelenmiş olan şifreyi tekrar SHA256 ile şifreleyip karşılaştırıyoruz, aynı sonucu elde ediyorsak şifreler eşleşiyor demektir.
            {
                result.IsSuccess = false;
                return result; // Hatalı şifre

            }
            result = GetToken(user);

            //var asddasd = User?.Identity?.Name;

            result.IsSuccess = true;
            return result;
        }

        public string Encrypt(string passwordText)
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

        public DataResponse<string> GetToken(User user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("Id", user.ID.ToString()));
            claims.Add(new Claim("Name", (user.FirstName + " " + user.LastName)));
            claims.Add(new Claim("Email", user.Email));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Email));
            claims.Add(new Claim(ClaimTypes.Role, user.UserType.Type));

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                claims: claims,
                expires: DateTime.Now.AddDays(5),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("heisenbergheisenbergheisenberghe")), SecurityAlgorithms.HmacSha256)
            );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            DataResponse<string> response = new DataResponse<string>(tokenHandler.WriteToken(token));
            response.IsSuccess = true;

            return response;
        }

        public class TokenResponse
        {
            public DateTime ExpireDate { get; set; }
            public string Token { get; set; }
            public string Email { get; set; }
            public int CustomerNumber { get; set; }
        }

        //private string Token(User user)
        //{
        //    Claim[] claims = GetClaims(user);
        //    var secret = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

        //    var jwtToken = new JwtSecurityToken(
        //        _jwtConfig.Issuer,
        //        _jwtConfig.Audience,
        //        claims,
        //        expires: DateTime.Now.AddMinutes(_jwtConfig.AccessTokenExpiration),
        //        signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
        //    );

        //    string accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        //    return accessToken;
        //}

        //private Claim[] GetClaims(User user)
        //{
        //    var claims = new[]
        //    {
        //    new Claim("Id", user.ID.ToString()),
        //    new Claim("Role", "admin"),
        //    new Claim("Email", user.Email),
        //    new Claim(ClaimTypes.Role, "admin"),
        //    new Claim("FullName", $"{user.FirstName} {user.LastName}")
        //};

        //    return claims;
        //}

        
    }
}
