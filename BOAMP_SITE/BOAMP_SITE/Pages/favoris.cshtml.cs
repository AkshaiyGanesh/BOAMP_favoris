using System.Net.NetworkInformation;
using BOAMP_SITE.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


namespace BOAMP_SITE.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly FavorisDbContext _context; // Ajoute cette ligne

    // Ajoute FavorisDbContext dans le constructeur
    public IndexModel(ILogger<IndexModel> logger, FavorisDbContext context)
    {
        _logger = logger;
        _context = context; // Initialise le contexte ici
        Favoris = new List<Favori>();
    }

    public List<Favori> Favoris { get; set; }

    public void OnGet()
    {
        Favoris = _context.Favoris.ToList();
    }

    public async Task<IActionResult> OnPostRemoveFromFavoritesAsync(int id)
    {
        var favori = await _context.Favoris.FindAsync(id);
        if (favori != null)
        {
            _context.Favoris.Remove(favori);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage();
    }

}