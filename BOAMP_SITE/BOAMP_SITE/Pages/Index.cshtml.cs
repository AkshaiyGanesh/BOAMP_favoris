﻿
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;
using BOAMP_SITE.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BOAMP_SITE.Pages
{


    public class Annonce
    {

        public Annonce(string Idweb, string Objet, string Dateparution)
        {
            this.Idweb = Idweb;
            this.Objet = Objet;
            this.Dateparution = Dateparution;

        }

        public string Idweb { get; set; }
        public string Objet { get; set; }
        public string Dateparution { get; set; }
        // Si vous utilisez une version de C# antérieure à 8.0, vous ne pourrez pas utiliser la syntaxe nullable pour les types de référence.
    }

    public class IndexModel2 : PageModel
    {
        private readonly ILogger<IndexModel2> _logger; // Assurez-vous que le type générique correspond au nom de la classe actuelle
        private readonly FavorisDbContext _context;

        public List<Annonce> Annonces { get; set; }

        public IndexModel2(ILogger<IndexModel2> logger, FavorisDbContext context) // Modifier le type générique pour correspondre à la classe actuelle
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context;
            Annonces = new List<Annonce>();
        }


        public void OnGet()
        {

            //var Annonce1 = new Annonce( "12", "dzjehziegiue", "12/01/2023" );
            //Annonces.Add(Annonce1);

            var jsonFilePath = "/Users/akshaiyganesh/Desktop/stage_boamp/BOAMP_favoris/APP/json_api_boamp.json";
            var jsonData = System.IO.File.ReadAllText(jsonFilePath);
            var jsonObject = JsonConvert.DeserializeObject<JObject>(jsonData);

            JArray results = (JArray)jsonObject["results"];
            Annonces = new List<Annonce>();

            foreach (var item in results)
            {
                // Créez un nouvel objet Annonce pour chaque élément dans le tableau JSON
                Annonce annonce = new Annonce(
                    item["idweb"].ToString(),
                    item["objet"].ToString(),
                    (DateTime.Parse(item["dateparution"].ToString())).ToString("dd/MM/yyyy") // Assurez-vous que le format de date correspond à votre besoin
                );
                Annonces.Add(annonce);
            }

            // Supposons que les annonces se trouvent sous la clé "annonces"
            //var annoncesJson = jsonObject["results"];


        }

        public async Task<IActionResult> OnPostAddToFavoritesAsync(string idAvis, string objet, DateTime dateFinDiffusion)
        {
            var newFavori = new Favori
            {
                IdAvis = idAvis,
                Objet = objet,
                DateFinDiffusion = dateFinDiffusion,
                DateAjout = DateTime.UtcNow // Utilisez DateTime.Now si vous voulez l'heure locale
            };

            _context.Favoris.Add(newFavori); // Ajoutez le nouvel objet à votre DbSet de Favoris
            await _context.SaveChangesAsync(); // Sauvegardez les changements dans la base de données

            return RedirectToPage(); // Redirigez l'utilisateur vers la même page
        }

    }

}
