using System.Net.NetworkInformation;
using BOAMP_SITE.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace BOAMP_SITE.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        Favoris = new List<Favori>();
    }

    public List<Favori> Favoris { get; set; }




}