using Microsoft.AspNetCore.Mvc.RazorPages;
using PassOrderKPro.Entities;

namespace PassOrderKPro.Pages;

public class Index : PageModel
{
    private MainDbContext dbContext;

    public Index()
    {
        dbContext = new MainDbContext();
    }
    public string Test()
    {
        Staff staff = dbContext.Staff.ToList().Last();
        return staff.Fio;
    }
    public void OnGet()
    {
        
    }
}