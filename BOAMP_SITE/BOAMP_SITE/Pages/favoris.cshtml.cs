using System.Net.NetworkInformation;
using BOAMP_SITE.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



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

        // Supposons que vous ayez une méthode pour obtenir les e-mails à partir du JSON, similaire à ce que vous avez fait dans Index
        var emailMapping = GetEmailsFromJson();

        // Associer les e-mails aux favoris correspondants
        foreach (var favori in Favoris)
        {
            if (emailMapping.TryGetValue(favori.IdAvis, out var email))
            {
                favori.Email = email;
            }
        }

    }

    private Dictionary<string, string> GetEmailsFromJson()
    {
        var emailMapping = new Dictionary<string, string>();

        var jsonFilePath = "/Users/akshaiyganesh/Desktop/stage_boamp/BOAMP_favoris/APP/json_api_boamp.json";
        var jsonData = System.IO.File.ReadAllText(jsonFilePath);
        var jsonObject = JsonConvert.DeserializeObject<JObject>(jsonData);
        JArray results = (JArray)jsonObject["results"];

        foreach (var item in results)
        {
            var idAvis = item["idweb"]?.ToString();
            var donneesJson = item["donnees"]?.ToString() ?? "{}";
            var donnees = JsonConvert.DeserializeObject<JObject>(donneesJson);
            var email = donnees["IDENT"]?["MEL"]?.ToString() ?? "Cette annonce ne contient pas de Mail";

            if (idAvis != null)
            {
                emailMapping.Add(idAvis, email);
            }
        }

        return emailMapping;
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



    public async Task<IActionResult> OnPostAddToFavoritesAsync(string idAvis, string objet, DateTime dateFinDiffusion, string email)
    {
        // Tu ajoutes l'email ici
        var newFavori = new Favori
        {
            IdAvis = idAvis,
            Objet = objet,
            DateFinDiffusion = dateFinDiffusion,
            Email = email,
        };

        _context.Favoris.Add(newFavori);
        await _context.SaveChangesAsync();

        return RedirectToPage(); // Ou redirige vers une autre page si nécessaire
    }
}