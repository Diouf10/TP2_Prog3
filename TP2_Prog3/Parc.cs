// <copyright name="Mouhammad W. Diouf et Alexandre Lavoie" file="Parc.cs" company="TP2">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>


namespace TP2_Prog3
{
    /* 
    * 
    * - TODO!!!
    * Pour la "liste" d'attractions, la Hash Table semblerait être un bon choix :
         
    *      
    * Bonus - La générécité faciliterait beaucoup le codage de la classe.
    * 
    * - TODO!!!
    */

    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Parc
    {
        private Dictionary<string, Attraction> _attractions = new Dictionary<string, Attraction>();
        
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
