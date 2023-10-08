using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
     */

    public class GestionVisiteurs
    {
        private Queue<Visiteur> _visiteursFilesDAttentes;
        public void EntrerVisiteurDansFileAttente(string attractionId, Visiteur visiteur)
        {
            
        }
        public void EntrerVisiteurDansAttraction(string attractionId)
        {
            
        }
        public void EntrerVisiteurDansParc(Visiteur visiteur)
        {

        }
        public void SortirVisiteurDuParc(Visiteur visiteur)
        {

        }

    }
}
