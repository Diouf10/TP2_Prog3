// <copyright name="Mouhammad W. Diouf et Alexandre Lavoie" file="Program.cs" company="TP2">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TP2_Prog3
{
    using System.Threading;

    /// <summary>
    /// Le programme qui roule...
    /// </summary>
    public static class Program
    {
        private static readonly Parc Parc = new ();
        private static readonly Map Map = new ();
        private static readonly GestionVisiteurs GestionVisiteurs = new (Parc);

        /// <summary>
        /// Le main du programme offert par le professeur.
        /// </summary>
        public static void Main()
        {
            AffichageConsole.Afficher(Parc, Map, GestionVisiteurs);
            var visiteur1 = new Visiteur("Nom 1");
            TestEntrerVisiteur(visiteur1);
            var visiteur2 = new Visiteur("Nom 2");
            TestEntrerVisiteur(visiteur2);
            var visiteur3 = new Visiteur("Nom 3");
            TestEntrerVisiteur(visiteur3);
            var visiteur4 = new Visiteur("Nom 4");
            TestEntrerVisiteur(visiteur4);
            for (var i = 1; i <= 4; i++)
            {
                GestionVisiteurs.EntrerVisiteurDansAttraction("M0002");
                Afficher();
            }

            TestSortirVisiteur(visiteur3);
            TestSortirVisiteur(visiteur4);
            TestSortirVisiteur(visiteur2);
            TestSortirVisiteur(visiteur1);

            AffichageConsole.AfficherHistoriqueVisiteur(visiteur1);
        }

        /// <summary>
        /// Méthode statique qui permet d'afficher la map. Utilisée dans les tests.
        /// </summary>
        private static void Afficher()
        {
            Thread.Sleep(1000);
            AffichageConsole.Afficher(Parc, Map, GestionVisiteurs);
        }

        /// <summary>
        /// Test qui permet de faire entrer le visiteur dans le Parc.
        /// </summary>
        /// <param name="visiteur">Visiteur qui veut entrer dans le parc.</param>
        private static void TestEntrerVisiteur(Visiteur visiteur)
        {
            GestionVisiteurs.EntrerVisiteurDansParc(visiteur);
            GestionVisiteurs.EntrerVisiteurDansFileAttente("M0002", visiteur);
            Afficher();
        }

        /// <summary>
        /// Test qui permet de faire sortir un visiteur du parc.
        /// </summary>
        /// <param name="visiteur">visiteur qui veut sortir du parc.</param>
        private static void TestSortirVisiteur(Visiteur visiteur)
        {
            GestionVisiteurs.SortirVisiteurDuParc(visiteur);
            Afficher();
        }
    }
}
