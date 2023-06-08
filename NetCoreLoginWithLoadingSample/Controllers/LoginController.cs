using Microsoft.AspNetCore.Mvc;

namespace NetCoreLoginWithLoadingSample.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string username, string password)
        {
            Result result = new Result();
            Thread.Sleep(2000);
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                result.Error = "BadRequest";
                result.Message = "Kullanıcı Adı ve Şifre boş geçilemez!";
                result.Success = false;
                return Ok(new { result });
            }

            if (username == "test" && password == "1234")
            {
                result.Error = "";
                result.Message = "Success";
                result.Success = true;
                result.Data = Guid.NewGuid().ToString();
                return Ok(new { result });
            }

            result.Error = "Unauthorized";
            result.Message = "Kullanıcı adı veya şifre yanlış!";
            result.Success = false;
            return Ok(new { result });
        }
    }

    public class Result
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
