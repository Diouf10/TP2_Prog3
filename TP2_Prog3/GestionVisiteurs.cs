

namespace TP2_Prog3
{
    /*
     * Pour les files d'attente propres à chaque Attractions
     * je crois qu'il nous faudrait un dictionnary OU une hashtable
     *
     * 1 - À l'aide du ID de l'attraction, on pourrait accéder à la file. (Queue)
     *
     * Les files d'attentes, elles, devraient être
     * conservés dans une Queue (premier arrivé, premier sorti.)
     *
     * Pour Gérer que chaque attraction puisse avoir ses visiteurs je crois qu'il
     * faut utiliser un Dictionnary<ID,files d'attentes> on sera en mesure de gérer
     * la files d'attente pour chaque attraction de manière distinctes.
     */

    public class GestionVisiteurs
    {
        //Commentaires à faire, dis moi si les tructure de données choisi sint bonnes ???
        private Queue<Visiteur> _visiteursFilesDAttentes;
        private Dictionary<string, Queue<Visiteur>> _filesAttente;
        private List<Visiteur> _visteursParc;
        private Parc _parc;

        public GestionVisiteurs(Parc Parc)
        {
            _parc = Parc;
            _visiteursFilesDAttentes = new Queue<Visiteur>();
            _filesAttente = new Dictionary<string, Queue<Visiteur>>();
        }

        public void EntrerVisiteurDansFileAttente(string attractionId, Visiteur visiteur)
        {
            if (_parc.Attractions.ContainsKey(attractionId))
            {
                _filesAttente.Add(attractionId, _visiteursFilesDAttentes);
                _filesAttente[attractionId].Enqueue(visiteur);
            }
        }

        public void EntrerVisiteurDansAttraction(string attractionId)
        {
            if (_filesAttente.ContainsKey(attractionId))
            {
                _visiteursFilesDAttentes.Dequeue();
            }
        }

        public void EntrerVisiteurDansParc(Visiteur visiteur)
        {
            _visteursParc.Add(visiteur);
        }

        public void SortirVisiteurDuParc(Visiteur visiteur)
        {
            _visteursParc.Remove(visiteur);
        }
        
    }
}  
            