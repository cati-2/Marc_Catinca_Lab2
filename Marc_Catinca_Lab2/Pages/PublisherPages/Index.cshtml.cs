using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Marc_Catinca_Lab2.Models;

namespace Marc_Catinca_Lab2.Pages.PublisherPages;

public class IndexModel : PageModel
{
    private readonly Marc_Catinca_Lab2Context _context;

    public IndexModel(Marc_Catinca_Lab2Context context)
    {
        _context = context;
    }

    public IList<Publisher> Publisher { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Publisher = await _context.Publisher.ToListAsync();
    }
}
