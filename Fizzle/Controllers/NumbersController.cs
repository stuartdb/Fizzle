using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fizzle.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fizzle.Controllers
{
    public class NumbersController : Controller
    {
        private readonly NumberContext _context;

        public NumbersController(NumberContext context)
        {
            _context = context;
        }

        // GET: NumbersController
        public ActionResult Index()
        {
            return View();
        }

        // GET: NumbersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
