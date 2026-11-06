using Marc_Catinca_Lab2.Data;
using Marc_Catinca_Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Marc_Catinca_Lab2.Pages.BorrowingPages;

public class CreateModel : PageModel
{
    private readonly Marc_Catinca_Lab2Context _context;

    public CreateModel(Marc_Catinca_Lab2Context context)
    {
        _context = context;
    }

    [BindProperty]
    public Borrowing Borrowing { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync()
    {
        await PopulateDropDownsAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await PopulateDropDownsAsync();
            return Page();
        }

        _context.Borrowing.Add(Borrowing);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }

    private async Task PopulateDropDownsAsync()
    {
        var members = await _context.Member
            .Select(m => new
            {
                m.ID,
                Display = m.FirstName + " " + m.LastName
            })
            .ToListAsync();

        ViewData["MemberID"] = new SelectList(members, "ID", "Display");

        var books = await _context.Book
            .Include(b => b.Author)
            .Select(b => new
            {
                b.ID,
                Display = b.Title + " - " +
                    (b.Author != null ? b.Author.FullName : "Unknown author")
            })
            .ToListAsync();

        ViewData["BookID"] = new SelectList(books, "ID", "Display");
    }
}