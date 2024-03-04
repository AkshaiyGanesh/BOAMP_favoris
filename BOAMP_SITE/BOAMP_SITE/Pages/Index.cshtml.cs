using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BOAMP_SITE.Pages;

public class IndexModel2 : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel2(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}

