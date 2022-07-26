using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListApp.Infrastructure;
using ToDoListApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoListApp.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoContext _context;

        public ToDoController(ToDoContext context)
        {
            this._context = context;
        }

        // GET: /Todo/Index
        public async Task<ActionResult> Index()
        {
            var result = from i in _context.ToDoList select i;

            var todolist = await result.ToListAsync();

            return View(todolist);
        }

        //GET: /ToDo/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: /ToDo/Create
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> Create(ToDoList item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();

                TempData["Success"] = "New item has been added!";

                return RedirectToAction("Index");
            }

            return View(item);
        }

        //GET: /ToDo/Edit/0
        public async Task<ActionResult> Edit(int id)
        {
            var item = await _context.ToDoList.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        //PUT: /ToDo/Edit/0
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> Edit(ToDoList item)
        {
            if (ModelState.IsValid)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Item has been updated!";

                return RedirectToAction("Index");
            }

            return View("Index");
        }

        //DELETE: /ToDo/Delete/0
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _context.ToDoList.FindAsync(id);

            if (item == null)
            { 
                TempData["Error"] = "Item does not exist!";
            }
            else
            {
                _context.ToDoList.Remove(item);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Item has been deleted!";
            }

            
            return RedirectToAction("Index");
        }
    }
}
