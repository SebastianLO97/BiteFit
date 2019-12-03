using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BiteFit.Data;
using BiteFit.Models;

namespace BiteFit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietaController : ControllerBase
    {
        [HttpGet("{idTipo}/{idPost}")]
        public dynamic GetDieta([FromRoute]string idTipo,[FromRoute]int idPost)
        {
            var dietaDb = new DietaDb();
            switch (idTipo)
            {
                case "GetDieta":
                    return dietaDb.GetDieta();
                case "PostNumeroDieta":
                    dietaDb.PostNumeroDieta(idPost);
                    return null;
                default: return null;
            }
            
        }
    }
}