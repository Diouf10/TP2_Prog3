using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Prog3
{
    public class Parc
    {
        Dictionary<int, Attraction> _attractions = new Dictionary<int, Attraction>();
        /* 
         * Pour la "liste" d'attractions, la Hash Table semblerait être un bon choix :
         * 1 - Nous ne connaîtrons pas la quantité d'attractions à l'avance, et un système de
         *      style bibliothèque conviendrait à ce critère.
         * 2 - On pourrait facilement accéder à l'attraction via un ID, car le Dictionnary<> utilise
         *      un système de clé.
         *      
         * Bonus - La générécité faciliterait beaucoup le codage de la classe.
         * 
         * - Alexandre Lavoie
         */
        
        public Parc() 
        {
        
        }

        public string GetRepresentationAttraction(int ID)
        {
            Attraction attraction = _attractions.GetValueOrDefault(ID);

            return $"{ID};{"type"};{"nom"};{"capacité"}";
        }
    }
}
