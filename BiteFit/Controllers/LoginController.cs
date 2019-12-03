using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiteFit.Data;
using BiteFit.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BiteFit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public dynamic GetUsers([FromBody] User user)
        {
            var userDb = new UsersDb();
            return userDb.ExisteUsuario(user);
        }
    }
}