using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiAuthentication.Model;

namespace WebApiAuthentication.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MyAppController : ControllerBase
    {
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;

        public MyAppController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }
        // GET: api/MyApp
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/MyApp/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        //POST: api/myapp
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authentication([FromBody] User user)
        {
            var token = jwtAuthenticationManager.Authentication(user.UserName, user.PassWord);
            if (token == null)
                return Unauthorized(new { Messgage = "Tài khoản hoặc mật khẩu không chính xác!" });
            return Ok(token);
        }
    }
}
