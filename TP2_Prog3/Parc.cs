// <copyright name="Mouhammad W. Diouf et Alexandre Lavoie" file="Parc.cs" company="TP2">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

<<<<<<< HEAD

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
=======
namespace TP2_Prog3
{
    /*
    *
    * - T
    * Pour la "liste" d'attractions, la Hash Table semblerait être un bon choix :
    *
    * Bonus - La générécité faciliterait beaucoup le codage de la classe.
    *
    * - T
>>>>>>> stylecop fait a 97% !!
    */

    using System;
    using System.Collections.Generic;
    using System.Text;

<<<<<<< HEAD
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
=======
    /// <summary>
    /// La classe du parc permet de conserver les données du parc.
    /// </summary>
    public class Parc
    {
        private Dictionary<string, Attraction> _attractions = new Dictionary<string, Attraction>();

        /// <summary>
        /// Constructeur du Parc.
        /// </summary>
        public Parc()
        {
            string[] lines = File.ReadAllLines(@"../../../attractions.txt");

            foreach (string line in lines)
            {
                int i = 0;

                StringBuilder id = new ();

                for (; i < line.Length && line[i] != ';'; i++)
                {
                    id.Append(line[i]);
>>>>>>> stylecop fait a 97% !!
                }

                i++;

                char type = line[i]; // C'est bon!!!

                i += 2;

<<<<<<< HEAD
                StringBuilder nom = new();

                for (; i < line.Length && line[i] != ';'; i++) // Nom Attraction
=======
                StringBuilder nom = new ();

                for (; i < line.Length && line[i] != ';'; i++)
>>>>>>> stylecop fait a 97% !!
                {
                    nom.Append(line[i]);
                }

<<<<<<< HEAD
                StringBuilder strCapacity = new();

                for (; i < line.Length; i++) // Capacité Attraction
=======
                StringBuilder strCapacity = new ();

                for (; i < line.Length; i++)
>>>>>>> stylecop fait a 97% !!
                {
                    if (char.IsDigit(line[i]))
                    {
                        strCapacity.Append(line[i]);
                    }
                }

                Attraction attraction = new Attraction(
<<<<<<< HEAD
                    ID.ToString(), nom.ToString(), Convert.ToInt32(strCapacity.ToString()), type) ;

                _attractions.Add(ID.ToString() ,attraction);  

            }

        }

        public Dictionary<string, Attraction> Attractions => _attractions;

        public Attraction GetAttraction(string id)
        {
            return _attractions.GetValueOrDefault(id);

        }

=======
                    id.ToString(), nom.ToString(), Convert.ToInt32(strCapacity.ToString()), type);

                _attractions.Add(id.ToString(), attraction);
            }
        }

        /// <summary>
        /// Permet d'obtenir une attraction.
        /// </summary>
        public Dictionary<string, Attraction> Attractions => _attractions;

        /// <summary>
        /// Permet bd'obtenir une attraction selon son id.
        /// </summary>
        /// <param name="id">l'id de l'attarction.</param>
        /// <returns>Retourne l'attraction selon son id.</returns>
        public Attraction GetAttraction(string id)
        {
            return _attractions.GetValueOrDefault(id) ?? throw new InvalidOperationException();
        }

        /// <summary>
        /// Permet d'obtenir la capacité d'une attarction.
        /// </summary>
        /// <param name="id">le id de l'attraction.</param>
        /// <returns>Retourne la capacité de l'attraction.</returns>
>>>>>>> stylecop fait a 97% !!
        public int GetAttractionCapacity(string id)
        {
            Attraction attraction = GetAttraction(id);
            if (attraction is null)
            {
                return -1;
            }
<<<<<<< HEAD
            return attraction.Capacity;
        }

        [Obsolete] // Obsolète?
        public string GetRepresentationAttraction(string ID)
        {
            Attraction attraction = _attractions.GetValueOrDefault(ID);
=======

            return attraction.Capacity;
        }

        /// <summary>
        /// Permet la représentation D'une attraction.
        /// </summary>
        /// <param name="id">l'id d'une attraction.</param>
        /// <returns>Retourne la représentation en string.</returns>
        [Obsolete] // Obsolète?
        public string GetRepresentationAttraction(string id)
        {
            Attraction attraction = _attractions.GetValueOrDefault(id) ?? throw new InvalidOperationException();
>>>>>>> stylecop fait a 97% !!

            return $"{attraction.ID};{attraction.TypeAttraction};{attraction.Nom};{attraction.Capacity}";
        }
    }
}
