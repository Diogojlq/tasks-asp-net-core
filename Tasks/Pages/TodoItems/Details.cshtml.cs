using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tasks.Models;

namespace Tasks.Pages.TodoItems
{
    public class DetailsModel : PageModel
    {
        private readonly TodoContext _context;

        public DetailsModel(TodoContext context)
        {
            _context = context;
        }

      public TodoItem TodoItem { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.TodoItems == null)
            {
                return NotFound();
            }

            var todoitem = await _context.TodoItems.FirstOrDefaultAsync(m => m.Id == id);
            if (todoitem == null)
            {
                return NotFound();
            }
            else 
            {
                TodoItem = todoitem;
            }
            return Page();
        }
    }
}
