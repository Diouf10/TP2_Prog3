using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Prog3
{
    public static class AffichageConsole
    {
        /// <summary>
        /// Cette méthode imprime la carte sur la console.
        /// </summary>
        /// <param name="parc"> Le parc dans lequel les attractions sont situées </param>
        /// <param name="map"> La carte (avec les ID aux cases) qui sera imprimée </param>
        /// <param name="gestionVisiteurs"> </param>
        public static void Afficher(Parc parc, Map map, GestionVisiteurs gestionVisiteurs)
        {
            StringBuilder sb = new StringBuilder();
            Console.OutputEncoding = Encoding.UTF8;
            for (int y = 1; y <= map.Largeur; y++ )
            {
                for (int x = 1; x <= map.Longueur; x++)
                {

                    if (map.Attractions[y - 1, x - 1] == null)
                    {
                        sb.Append("-----");
                    }
                    else
                    {
                        Console.Write(sb.ToString());

                        string id = map.Attractions[y - 1, x - 1].ID;

                        Console.ForegroundColor = GetCouleurFile(gestionVisiteurs, 
                            parc.Attractions.GetValueOrDefault(id), parc);
                        Console.Write(map.Attractions[y - 1, x - 1].ID);
                        Console.ForegroundColor = ConsoleColor.White;

                        sb = new StringBuilder();
                    }

                    if (x == map.Longueur)
                    {
                        sb.Append("\n");
                        Console.Write(sb.ToString());
                        sb = new StringBuilder();

                    }
                }
            }

            Console.WriteLine("");
            Console.WriteLine(gestionVisiteurs.Visiteurs.Count + " visiteur(s) présent(s) dans le parc.");
            Console.WriteLine("");
            // TODO REFAIRE LA FOREACH!!!! https://stackoverflow.com/questions/41495278/how-to-enumerate-a-hashtable-for-foreach-in-c-sharp!!!

            foreach (KeyValuePair<string, Attraction> kvp in parc.Attractions)
            {
                Attraction attraction = kvp.Value;

                if (attraction is not null)
                {
                    
                    Console.ForegroundColor = GetCouleurFile(gestionVisiteurs, attraction, parc);
                    Console.Write("  ●  ");
                    Console.ForegroundColor = ConsoleColor.White;
                    // MAP LIGNE 127 EST LA RAISON PK LES ATTRACTIONS SE NOMMENT PLACEHOLDER POUR LE MOMENT...
                    Console.WriteLine(String.Format("{0,5} {1,15} ({2}) \t\t {3,2}/{4,2}", attraction.ID, attraction.Nom,
                        attraction.TypeAttraction, gestionVisiteurs.getQueueLength(attraction.ID), attraction.Capacity));

                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Cette méthode retourne la "couleur d'activité".
        /// </summary>
        /// <param name="gestionVisiteurs">La GestionVisiteur qui contient la queue.</param>
        /// <param name="attraction">L'attraction concernée</param>
        /// <param name="parc">Le parc</param>
        /// <returns>La couleur d'affichage de l'attraction</returns>
        private static ConsoleColor GetCouleurFile(GestionVisiteurs gestionVisiteurs, Attraction attraction, Parc parc)
        {
            ConsoleColor couleur;
            if (gestionVisiteurs.getFile(attraction.ID) != null &&
                    (gestionVisiteurs.getQueueLength(attraction.ID) > parc.GetAttractionCapacity(attraction.ID) / 2 &&
                    gestionVisiteurs.getQueueLength(attraction.ID) < parc.GetAttractionCapacity(attraction.ID)))
            {
                couleur = ConsoleColor.DarkYellow;
            }
            else if (gestionVisiteurs.getFile(attraction.ID) != null &&
                gestionVisiteurs.getQueueLength(attraction.ID) >= parc.GetAttractionCapacity(attraction.ID))
            {
                couleur = ConsoleColor.Red;
            }
            else
            {
                couleur = ConsoleColor.Green;
            }
            return couleur;
        }

        /// <summary>
        /// Cette méthode écrit l'historique d'un visiteur sur la console.
        /// </summary>
        /// <param name="visiteur"> Le visiteur en question. </param>
        public static void AfficherHistoriqueVisiteur(Visiteur visiteur)
        {
            string[] historique = visiteur.Historique;

            StringBuilder sb = new();

            sb.AppendLine($"### {visiteur.Nom} ###");

            for (int i = 0; i < historique.Length; i++)
            {
                sb.AppendLine(historique[i]);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
