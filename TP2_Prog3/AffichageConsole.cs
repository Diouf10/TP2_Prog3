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

                    Console.ForegroundColor = ConsoleColor.Green;
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
            
        }


    }
}
