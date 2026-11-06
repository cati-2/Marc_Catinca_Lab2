using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Marc_Catinca_Lab2.Models;
using Marc_Catinca_Lab2.Data;

namespace Marc_Catinca_Lab2.Pages.MemberPages;

public class IndexModel : PageModel
{
    private readonly Marc_Catinca_Lab2Context _context;

    public IndexModel(Marc_Catinca_Lab2Context context)
    {
        _context = context;
    }

    public IList<Member> Member { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Member = await _context.Member.ToListAsync();
    }
}
