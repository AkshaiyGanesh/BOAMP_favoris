using System;
using System.Net;
using System.IO; 

namespace projet_stage
{
    class projet
    {
        static void Main(string[] args)
        {


            // Je crée l'url

            string url_site_moap = "https://www.boamp.fr/api/explore/v2.1/catalog/datasets/boamp/records?limit=20";

            var webClient = new WebClient();

            Console.WriteLine("Installation en cours ...");

            try
            {
                var contenue_url_json = webClient.DownloadString(url_site_moap);

                Console.WriteLine($"Contenu de l'url : \n\n{contenue_url_json}");

                // je crée le nom fichier.txt
                string file_name = "json_api_boamp.json";

                // J'écris le contenu du boamp (JSON)
                File.WriteAllText(file_name, contenue_url_json);

                //je déplace le fichier vers ou je veux 
                string sourceFileName = @"/Users/akshaiyganesh/Desktop/stage_boamp/BOAMP_favoris/APP/Projet_stage_officiel/bin/Debug/net7.0/json_api_boamp.json";
                string destFileName = @"/Users/akshaiyganesh/Desktop/stage_boamp/BOAMP_favoris/APP/json_api_boamp.json"; // Assurez-vous que le chemin du fichier de destination est correct et inclut le nom du fichier

                // Vérifie si le fichier existe déjà et le supprime dans ce cas
                if (File.Exists(destFileName))
                {
                    File.Delete(destFileName);
                }

                Console.WriteLine($"Le contenu JSON a été écrit dans le fichier {file_name}");

                File.Move(sourceFileName, destFileName);
            }
            catch (WebException ex)
            {
                Console.WriteLine("Une exception WebException a été capturée !");
                Console.WriteLine(ex.Message);
                if (ex.Response != null)
                {
                    Console.WriteLine("Réponse du serveur :");
                    Console.WriteLine(new StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
                }
            }

        }
    }
}


