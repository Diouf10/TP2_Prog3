

using System.Net.Http.Headers;

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
        private Dictionary<string, Queue<Visiteur>> _filesAttente;
        private Parc _parc;

        public GestionVisiteurs(Parc Parc)
        {
            _parc = Parc;

            _filesAttente = new Dictionary<string, Queue<Visiteur>>();
        }

        public Queue<Visiteur> getFile(string id)
        {
            Queue<Visiteur> file = _filesAttente.GetValueOrDefault(id);
            return file;
        }

        public void EntrerVisiteurDansFileAttente(string attractionId, Visiteur visiteur)
        {

            if (_parc.Attractions.ContainsKey(attractionId) && _filesAttente.GetValueOrDefault(attractionId) != null)
            {
                _filesAttente.GetValueOrDefault(attractionId).Enqueue(visiteur);

            }
            else
            {
                _filesAttente.Add(attractionId, new Queue<Visiteur>());

                _filesAttente.GetValueOrDefault(attractionId).Enqueue(visiteur);

            }
            visiteur.AjouterElementDansHistorique($"Entrer dans la file d'attente de l'attraction {attractionId}.");

        }

        public void EntrerVisiteurDansAttraction(string attractionId)
        {
            if (_filesAttente.ContainsKey(attractionId))
            {
                Queue<Visiteur> fileAttente = _filesAttente.GetValueOrDefault(attractionId)!;

                for (; fileAttente.Count > 0;)
                {
                    fileAttente.Dequeue().AjouterElementDansHistorique($"Entrer dans l'attraction {attractionId}");
                }
            
            }
            
        }

        public void EntrerVisiteurDansParc(Visiteur visiteur)
        {
            visiteur.AjouterElementDansHistorique("Entrer dans le parc.");
        }

        public void SortirVisiteurDuParc(Visiteur visiteur)
        {
            visiteur.AjouterElementDansHistorique("Sortie du parc.");
        }

    }
}  
            