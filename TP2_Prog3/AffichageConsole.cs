// <copyright name="Mouhammad W. Diouf et Alexandre Lavoie" file="AffichageConsole.cs" company="TP2">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>


namespace TP2_Prog3
{
    using System.Text;
    public static class AffichageConsole
    {
        /// <summary>
        /// Cette méthode imprime la carte sur la console.
        /// </summary>
        /// <param name="parc"> Le parc dans lequel les attractions sont situées </param>
        /// <param name="map"> La carte (avec les ID aux cases) qui sera imprimée </param>
        /// <param name="gestionVisiteurs"> La gestionVisiteurs qui contient les files d'attente. </param>
        public static void Afficher(Parc parc, Map map, GestionVisiteurs gestionVisiteurs)
        {
            if (parc is null)
            {
                throw new ArgumentNullException(nameof(parc));
            }

            if (map is null)
            {
                throw new ArgumentNullException(nameof(map));
            }

            if (gestionVisiteurs is null)
            {
                throw new ArgumentNullException(nameof(gestionVisiteurs));
            }

            Console.WriteLine("\n");

            StringBuilder sb = new StringBuilder();
            Console.OutputEncoding = Encoding.UTF8;
            for (int y = 1; y <= map.Largeur; y++)
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

                        string id = map.Attractions[y - 1, x - 1] !.ID; // can't be null. Cince already checked above

                        // TODO améliorer ce code.
                        Attraction attraction = parc.Attractions.GetValueOrDefault(id) !;
                        int nbVisiteursDansFile = gestionVisiteurs.GetQueueCount(id);

                        Console.ForegroundColor = GetCouleurFile(
                            nbVisiteursDansFile, attraction, parc);

                        Console.Write(attraction.ID);
                        Console.ForegroundColor = ConsoleColor.White;

                        sb = new StringBuilder();
                    }

                    if (x == map.Longueur)
                    {
                        sb.Append('\n');
                        Console.Write(sb.ToString());
                        sb = new StringBuilder();
                    }
                }
            }

            Console.WriteLine(string.Empty);
            Console.WriteLine(gestionVisiteurs.Visiteurs.Length + " visiteur(s) présent(s) dans le parc.");
            Console.WriteLine(string.Empty);

            // TODO REFAIRE LA FOREACH!!!! https://stackoverflow.com/questions/41495278/how-to-enumerate-a-hashtable-for-foreach-in-c-sharp!!!
            foreach (KeyValuePair<string, Attraction> kvp in parc.Attractions)
            {
                Attraction attraction = kvp.Value;

                if (attraction is not null)
                {
                    int nbVisiteursDansFile = gestionVisiteurs.GetQueueCount(kvp.Key);

                    Console.ForegroundColor = GetCouleurFile(nbVisiteursDansFile, attraction, parc);
                    Console.Write("  ●  ");
                    Console.ForegroundColor = ConsoleColor.White;
                    // MAP LIGNE 127 EST LA RAISON PK LES ATTRACTIONS SE NOMMENT PLACEHOLDER POUR LE MOMENT...
                    Console.WriteLine(string.Format(
                        "{0,5} {1,15} ({2}) \t\t {3,2} / {4,-2}",
                        attraction.ID,
                        attraction.Nom,
                        attraction.TypeAttraction,
                        nbVisiteursDansFile,
                        attraction.Capacity));
                }
            }

            Console.WriteLine("\n");
        }

        /// <summary>
        /// Cette méthode écrit l'historique d'un visiteur sur la console.
        /// </summary>
        /// <param name="visiteur"> Le visiteur en question. </param>
        public static void AfficherHistoriqueVisiteur(Visiteur visiteur)
        {
            string historique = visiteur.Historique;

            // Une seule addition de string variable ne devrait pas être la fin du monde,
            //      un nouvel array créé qu'une seule fois.
            Console.WriteLine($"### {visiteur.Nom} ###" + historique);
        }

        /// <summary>
        /// Cette méthode retourne la "couleur d'activité".
        /// </summary>
        /// <param name="nbVisiteursDansFile">Le nombre de visiteurs dans la file.</param>
        /// <param name="attraction">L'attraction concernée</param>
        /// <param name="parc">Le parc</param>
        /// <returns>La couleur d'affichage de l'attraction</returns>
        private static ConsoleColor GetCouleurFile(int nbVisiteursDansFile, Attraction attraction, Parc parc)
        {
            if (parc is null)
            {
                throw new ArgumentNullException(nameof(parc));
            }

            if (attraction is null)
            {
                throw new ArgumentNullException(nameof(attraction));
            }



            ConsoleColor couleur;
            if (nbVisiteursDansFile > parc.GetAttractionCapacity(attraction.ID) / 2 &&
                    nbVisiteursDansFile < parc.GetAttractionCapacity(attraction.ID))
            {
                couleur = ConsoleColor.DarkYellow;
            }
            else if (nbVisiteursDansFile >= parc.GetAttractionCapacity(attraction.ID))
            {
                couleur = ConsoleColor.Red;
            }
            else
            {
                couleur = ConsoleColor.Green;
            }

            return couleur;
        }
    }
}
