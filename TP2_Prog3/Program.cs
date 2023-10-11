namespace TP2_Prog3
{
    public static class Program
    {
        private static readonly Parc Parc = new();
        private static readonly Map Map = new();
        private static readonly GestionVisiteurs GestionVisiteurs = new(Parc);
        private static void Afficher()
        {
            Thread.Sleep(1000);
            AffichageConsole.Afficher(Parc, Map, GestionVisiteurs);
        }
        private static void TestEntrerVisiteur(Visiteur visiteur)
        {
            GestionVisiteurs.EntrerVisiteurDansParc(visiteur);
            GestionVisiteurs.EntrerVisiteurDansFileAttente("M0002", visiteur);
            Afficher();
        }
        private static void TestSortirVisiteur(Visiteur visiteur)
        {
            GestionVisiteurs.SortirVisiteurDuParc(visiteur);
            Afficher();
        }
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
    }
}