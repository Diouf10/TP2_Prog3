// <copyright name="Mouhammad W. Diouf et Alexandre Lavoie" file="Parc.cs" company="TP2">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TP2_Prog3
{
    /*
    * Pour la liste d'attractions, le dictionnary semble être un bon choix : Grâce à la clé, c'est à dire
    * l'ID de l'attraction, nous pouvons facilement liée la clé avec l'attraction associée, ce qui faciliterait
    * la recherche d'une attraction pusiqu'une attraction est unique est associée avec une clé unique (l'id de l'attraction).
    *
    * Pour l'import des attractions, (les lignes à écrire), nous avons décidé d'utiliser le string builder, car
    * car il se pourrait que des textes de la console qui change selon le contexte et dont on ne connait
    * pas le nombre de modifications qui sera fait à l'avance. Le string builder sera efficace en ce sens car
    * il conserve un tampon pour accueillir les ajouts.
    *
    * - Mouhammad Wagan Diouf et Alexandre Lavoie
    */
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    /// <summary>
    /// La classe du parc permet de conserver les données du parc.
    /// </summary>
    public class Parc
    {
        private readonly Dictionary<string, Attraction> _attractions = new Dictionary<string, Attraction>();

        /// <summary>
        /// Constructeur du Parc.
        /// </summary>
        public Parc()
        {
            string[] lines = File.ReadAllLines(@"../../../attractions.txt");

            foreach (string line in lines)
            {
                int i = 0;

                StringBuilder id = new (5); // le ID fait généralement 5 caractères.

                for (; i < line.Length && line[i] != ';'; i++)
                {
                    id.Append(line[i]);
                }

                i++;

                char type = line[i]; // C'est bon!!!

                i += 2;

                StringBuilder nom = new ();

                for (; i < line.Length && line[i] != ';'; i++)
                {
                    nom.Append(line[i]);
                }

                StringBuilder strCapacity = new ();

                for (; i < line.Length; i++)
                {
                    if (char.IsDigit(line[i]))
                    {
                        strCapacity.Append(line[i]);
                    }
                }

                Attraction attraction = new Attraction(
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
            if (_attractions.TryGetValue(id, out Attraction? attraction))
            {
                return attraction;
            }
            else
            {
                throw new KeyNotFoundException($"L'Attraction avec le ID {id}, n'a pas été trouvé!");
            }
        }

        /// <summary>
        /// Permet d'obtenir la capacité d'une attarction.
        /// </summary>
        /// <param name="id">le id de l'attraction.</param>
        /// <returns>Retourne la capacité de l'attraction.</returns>
        public int GetAttractionCapacity(string id)
        {
            Attraction attraction = GetAttraction(id);
            return attraction.Capacity;
        }
    }
}
