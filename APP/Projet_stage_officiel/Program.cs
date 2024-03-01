using System;
using System.Net;
using System.IO;

namespace projet_stage
{
    class projet
    {
        static void Main(string[] args)
        {
            // Nombre d'offres par défaut
            int nombreOffres = 20;
            // Chemin du fichier par défaut (dossier courant)
            string cheminFichier = "/Users/akshaiyganesh/Desktop/stage_boamp/BOAMP_favoris/APP/json_api_boamp.json";

            // Vérifier s'il y a des arguments
            if (args.Length > 0)
            {
                // Premier argument : nombre d'offres
                if (int.TryParse(args[0], out int result))
                {
                    nombreOffres = result;
                }
                else
                {
                    Console.WriteLine("Le premier argument n'est pas un nombre valide. Utilisation de la valeur par défaut.");
                }

                // Deuxième argument : chemin du fichier
                if (args.Length > 1)
                {
                    cheminFichier = args[1];
                }
            }

            // Construire l'URL avec le nombre d'offres
            string url_site_moap = $"https://www.boamp.fr/api/explore/v2.1/catalog/datasets/boamp/records?limit={nombreOffres}";

            // Télécharger les données et écrire dans le fichier spécifié
            using (var webClient = new WebClient())
            {
                try
                {
                    string contenu_url_json = webClient.DownloadString(url_site_moap);
                    File.WriteAllText(cheminFichier, contenu_url_json);
                    Console.WriteLine($"Les données ont été sauvegardées dans : {cheminFichier}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Une erreur est survenue :");
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
