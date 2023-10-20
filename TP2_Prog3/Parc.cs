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
        private Dictionary<string, Attraction> _attractions = new Dictionary<string, Attraction>();
        /* 
         * Pour la "liste" d'attractions, la Hash Table semblerait être un bon choix :
         * 1 - Nous ne connaîtrons pas la quantité d'attractions à l'avance, et un système de
         *      style bibliothèque conviendrait à ce critère.
         * 2 - On pourrait facilement accéder à l'attraction via un ID, car la Hash Table utilise
         *      un système de clé qui pourrait servir pour l'ID.
         *      
         * Bonus - La générécité faciliterait beaucoup le codage de la classe.
         * 
         * - Alexandre Lavoie
         */
        
        public Parc() 
        {
            
            string[] lines = File.ReadAllLines(@"../../../attractions.txt");

            foreach(string line in lines)
            {
                int i = 0;

                StringBuilder ID = new();
                 
                for (; i < line.Length && line[i] != ';'; i++) // ID Attraction
                {
                    ID.Append(line[i]);
                }

                i++;

                char type = line[i]; // C'est bon!!!

                i += 2;

                StringBuilder nom = new();

                for (; i < line.Length && line[i] != ';'; i++) // Nom Attraction
                {
                    nom.Append(line[i]);
                }

                StringBuilder strCapacity = new();

                for (; i < line.Length; i++) // Capacité Attraction
                {
                    if (char.IsDigit(line[i]))
                    {
                        strCapacity.Append(line[i]);
                    }
                }

                Attraction attraction = new Attraction(
                    ID.ToString(), nom.ToString(), Convert.ToInt32(strCapacity.ToString()), type) ;

                _attractions.Add(ID.ToString() ,attraction);  

            }

        }

        public Dictionary<string, Attraction> Attractions => _attractions;

        public Attraction GetAttraction(string id)
        {
            return _attractions.GetValueOrDefault(id);

        }

        public int GetAttractionCapacity(string id)
        {
            Attraction attraction = GetAttraction(id);
            if (attraction is null)
            {
                return -1;
            }
            return attraction.Capacity;
        }

        [Obsolete] // Obsolète?
        public string GetRepresentationAttraction(string ID)
        {
            Attraction attraction = _attractions.GetValueOrDefault(ID);

            return $"{attraction.ID};{attraction.TypeAttraction};{attraction.Nom};{attraction.Capacity}";
        }
    }
}
