using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Prog3
{
    public class Visiteur
    {
        /*
         * À mon avis, l'historique devrait être conservé dans une List<string>
         * 
         */

        /// <summary>
        /// Le nom du visiteur
        /// </summary>
        private string _nom;

        private List<string> _historique;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        public void AjouterElementDansHistorique(string action)
        {
            _historique.Add(action);
        }

        
        /// <summary>
        /// Cette méthode est sûrement inutile, mais elle vide l'historique
        /// </summary>        
        public void ViderHistorique()
        {
            _historique.Clear();
        }
    }
}
