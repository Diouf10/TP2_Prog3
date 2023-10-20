using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Prog3
{
    public static class AffichageConsole
    {
        public static void Afficher(Parc parc, Map map, GestionVisiteurs gestionVisiteurs)
        {
            StringBuilder sb = new StringBuilder();

            for(int y = 1; y <= map.Largeur; y++ )
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

                        ConsoleColor couleur;

                        if (gestionVisiteurs.getFile(id) != null &&
                            (gestionVisiteurs.getFile(id).Count > parc.Attractions.GetValueOrDefault(id).Capacity / 2 &&
                            gestionVisiteurs.getFile(id).Count < parc.Attractions.GetValueOrDefault(id).Capacity))
                        {
                            couleur = ConsoleColor.DarkYellow;
                        }
                        else if (gestionVisiteurs.getFile(id) != null &&
                            gestionVisiteurs.getFile(id).Count >= parc.Attractions.GetValueOrDefault(id).Capacity)
                        {
                            couleur = ConsoleColor.Red;
                        }
                        else
                        {
                            couleur = ConsoleColor.Green;
                        }


                        Console.ForegroundColor = couleur;
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

            Console.WriteLine("\n");

            // ceci est clairement wrong... il faudra créer la GestionVisiteur...
            foreach (Attraction attraction in map.Attractions)
            {
                //parc.Attractions.GetValueOrDefault(attraction.ID);

                Console.Write("");

            }
        }

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
