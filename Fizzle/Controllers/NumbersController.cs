using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fizzle.Data;
using Fizzle.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Index()
        {
            var all = await _context.Numbers
                .OrderBy(n => n.Initial)
                .ToListAsync();

            return View(all);
        }

        // GET: NumbersController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var number = await _context.Numbers
                .FirstOrDefaultAsync(n => n.Id == id);

            ViewData["Title"] = "Details";
            return View(number);
        }

        // GET: NumbersController/Transform/10
        /// <summary>
        /// Details isn't a very interesting action since it uses the id.        
        /// Being able to dump a number in the url and see it be Fizzled is more fun
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Transform(int id)
        {
            var number = new Number { Initial = id };
            number.Fizzle();

            ViewData["Title"] = "Transform";
            
            // Reuse the details view
            return View(number);
        }
    }
}
