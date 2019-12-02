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
    public class RegisterUserController : ControllerBase
    {
        [HttpGet("{idGet}")]
        public dynamic GetCRegisterUser([FromRoute]string idGet)
        {
            switch (idGet)
            {
                case "Pais":
                    var paisDb = new PaisDb();
                    return paisDb.GetPaises();
                case "Estado":
                    var estadoDb = new EstadoDb();
                    return estadoDb.GetEstados();
                default: return null;
            }

        } 
        [HttpPost]
        public void PostRegisterUser([FromBody]User user)
        {
            var registerUser = new RegisterUser();
            registerUser.RegisterUsers(user);
        }
    }
}