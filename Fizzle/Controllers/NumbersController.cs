using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fizzle.Data;
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
        /// Being able to dump a number in the url and see if it's been Fizzle'd is more interesting
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Transform(int id)
        {
            var number = await _context.Numbers
                .FirstOrDefaultAsync(n => n.Initial == id);

            ViewData["Title"] = "Transform";
            // Reuse the details view
            return View("Details", number);
        }
    }
}
