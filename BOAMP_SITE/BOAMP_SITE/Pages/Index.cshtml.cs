using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System;

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

        private readonly ILogger<IndexModel>? _logger;

        public List<Annonce> Annonces { get; set; }


        public IndexModel2(ILogger<IndexModel> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            Annonces = new List<Annonce>();
        }
        public IndexModel2()
        {
            Annonces = new List<Annonce>();
        }


        public void OnGet()
        {
            var jsonFilePath = "/Users/akshaiyagnesh/Desktop/stage_boamp/BOAMP_favoris/APP/json_api_boamp.json";
            var jsonData = System.IO.File.ReadAllText(jsonFilePath);

            var annoncesTemp = JsonConvert.DeserializeObject<List<Annonce>>(jsonData);
            Annonces = annoncesTemp ?? new List<Annonce>();

            // Assurez-vous que 'Newtonsoft.Json' est inclus et que le chemin du fichier est correct.
        }
    }
}
