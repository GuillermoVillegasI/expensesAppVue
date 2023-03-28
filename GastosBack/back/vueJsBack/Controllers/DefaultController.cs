using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vueJsBack.Controllers
{
    public class DefaultController : Controller
    {
        // GET: api/<Default>
        [HttpGet]
        public string Get()
        {
            return "Aplicación Corriendo";
        }

    }
}
