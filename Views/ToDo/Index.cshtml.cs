using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoListApp.Infrastructure;
using ToDoListApp.Models;

namespace ToDoListApp.Views.ToDo
{
    public class IndexModel : PageModel
    {
        private readonly ToDoListApp.Infrastructure.ToDoContext _context;

        public IndexModel(ToDoListApp.Infrastructure.ToDoContext context)
        {
            _context = context;
        }

        public IList<ToDoList> ToDoList { get;set; }

        public async Task OnGetAsync()
        {
            ToDoList = await _context.ToDoList.ToListAsync();
        }
    }
}
