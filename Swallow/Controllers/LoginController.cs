using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Swallow.Controllers
{
    public class LoginController : Controller
    {
        public PartialViewResult Index()
        {
            return PartialView();
        }
    }
}