using EsunBankSocialPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EsunBankSocialPlatform.Controllers
{
    public class SocialController : Controller
    {
        public IActionResult Display()
        {
            var posts = new List<DisplayViewModel>();
            /*
            var connStr = _config.GetConnectionString("DefaultConnection");

            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("GetAllPosts", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                posts.Add(new DisplayViewModel
                {
                    PostId = (int)reader["PostId"],
                    UserId = reader["UserId"].ToString(),
                    UserName = reader["UserName"].ToString(),
                    Title = reader["Title"].ToString(),
                    Content = reader["Content"].ToString(),
                    CreateTime = (DateTime)reader["CreateTime"]
                });
            }
            */

            return View(posts);
        }

        [HttpPost]
        public IActionResult Post(int PostId)
        {
            DisplayViewModel post = null;
            /*
            var connStr = _config.GetConnectionString("DefaultConnection");

            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("GetPostById", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@PostId", PostId);

            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                post = new DisplayViewModel
                {
                    PostId = (int)reader["PostId"],
                    UserId = reader["UserId"].ToString(),
                    UserName = reader["UserName"].ToString(),
                    Title = reader["Title"].ToString(),
                    Content = reader["Content"].ToString(),
                    CreateTime = (DateTime)reader["CreateTime"]
                };
            }
            */
            if (post == null)
            {
                return NotFound(); // 查無資料
            }

            return View(post);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "User");

            /*
            var connStr = _config.GetConnectionString("DefaultConnection");

            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("CreatePost", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@UserId", userId.Value);
            cmd.Parameters.AddWithValue("@Title", model.Title);
            cmd.Parameters.AddWithValue("@Content", model.Content);

            conn.Open();
            cmd.ExecuteNonQuery();
            */

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Modify(int PostId)
        {
            DisplayViewModel post = null;
            /*
            var connStr = _config.GetConnectionString("DefaultConnection");

            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("GetPostById", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@PostId", PostId);

            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                post = new DisplayViewModel
                {
                    PostId = (int)reader["PostId"],
                    UserId = reader["UserId"].ToString(),
                    UserName = reader["UserName"].ToString(),
                    Title = reader["Title"].ToString(),
                    Content = reader["Content"].ToString(),
                    CreateTime = (DateTime)reader["CreateTime"]
                };
            }
            */
            if (post == null)
            {
                return NotFound(); // 查無資料
            }

            return View(post);
        }
    }
}
