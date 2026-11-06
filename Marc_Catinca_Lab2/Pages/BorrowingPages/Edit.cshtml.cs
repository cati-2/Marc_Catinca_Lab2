using Marc_Catinca_Lab2.Data;
using Marc_Catinca_Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Marc_Catinca_Lab2.Pages.BorrowingPages;

public class EditModel : PageModel
{
    private readonly Marc_Catinca_Lab2Context _context;

    public EditModel(Marc_Catinca_Lab2Context context)
    {
        _context = context;
    }

    [BindProperty]
    public Borrowing Borrowing { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var borrowing = await _context.Borrowing
            .FirstOrDefaultAsync(m => m.ID == id);

        if (borrowing is null)
        {
            return NotFound();
        }

        Borrowing = borrowing;
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

        var borrowingToUpdate = await _context.Borrowing
            .FindAsync(Borrowing.ID);

        if (borrowingToUpdate is null)
        {
            return NotFound();
        }

        borrowingToUpdate.MemberID = Borrowing.MemberID;
        borrowingToUpdate.BookID = Borrowing.BookID;
        borrowingToUpdate.ReturnDate = Borrowing.ReturnDate;

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

        ViewData["MemberID"] = new SelectList(
            members, "ID", "Display");

        var books = await _context.Book
            .Include(b => b.Author)
            .Select(b => new
            {
                b.ID,
                Display = b.Title + " - " +
                  (b.Author != null ? b.Author.FullName : "Unknown author")
            })
            .ToListAsync();

        ViewData["BookID"] = new SelectList(
            books, "ID", "Display");
    }


    private bool BorrowingExists(int id)
    {
        return _context.Borrowing.Any(e => e.ID == id);
    }
}
