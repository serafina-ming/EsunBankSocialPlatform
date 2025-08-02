using EsunBankSocialPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text;

namespace EsunBankSocialPlatform.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //string hashedPwd = HashPassword(model.Password);

            try
            {
                /*
                using (var conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                using (var cmd = new SqlCommand("AddUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    cmd.Parameters.AddWithValue("@PasswordHash", hashedPwd);
                    cmd.Parameters.AddWithValue("@UserName", model.UserName);
                    cmd.Parameters.AddWithValue("@Email", model.Email);
                    cmd.Parameters.AddWithValue("@Biography", model.Biography);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                */
                return RedirectToAction("Login");
            }
            catch (/*SqlException ex*/ Exception ex)
            {
                /*
                if (ex.Number == 2627) // UNIQUE constraint
                    ModelState.AddModelError(string.Empty, "此手機號碼已註冊。");
                else
                    ModelState.AddModelError(string.Empty, "註冊失敗。");
                */
            }

            return View(model);
        }

        /*
        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
        */

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            /*
            var hashedPassword = HashPassword(model.Password);
            var connStr = _config.GetConnectionString("DefaultConnection");

            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("GetUserByPhone", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);

            conn.Open();
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string dbHash = reader["PasswordHash"].ToString();

                if (dbHash == hashedPassword)
                {
                    // 登入成功，設定 Session
                    HttpContext.Session.SetString("UserPhone", model.PhoneNumber);
                    HttpContext.Session.SetInt32("UserId", Convert.ToInt32(reader["UserId"]));

                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "手機號碼或密碼錯誤");
            */
            
            return View(model);
        }
    }
}
