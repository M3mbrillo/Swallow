using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swallow.Models;

namespace Swallow.Areas.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Login")]
    public class LoginController : Controller
    {
        [HttpPost]
        public StatusCodeResult Index(LoginModel model)
        {
            if (this.ModelState.IsValid)
            {
                return new StatusCodeResult(StatusCodes.Status200OK);
            }
            else
            {
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }
    }
}