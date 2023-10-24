// <copyright name="Mouhammad W. Diouf et Alexandre Lavoie" file="Attraction.cs" company="TP2">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

/*
   * Pour les types d'attractions, le dictionnary semble être un bon choix : Grâce à la clé, c'est à dire
   * l'ID de l'attraction, nous pouvons facilement liée la clé avec l'attraction associée, ce qui faciliterait
   * la recherche d'une attraction pusiqu'une attraction est unique est associée avec une clé unique (l'id de l'attraction).
   *
   * Et puis si jamais nous étions amené à présenté le titre de l'attraction elle serait déjà disponible dans
   * le dictionnaire d'attractions.
   *
   * - Mouhammad Wagan Diouf
   */

namespace TP2_Prog3
{
    /// <summary>
    /// Classe Attraction permet de conserver les données d'une attraction.
    /// </summary>
    public class Attraction
    {
        private static Dictionary<char, string> dictionnaireAttractions = new Dictionary<char, string>()
        {
            { 'S', "Sensation Forte" },
            { 'I', "Intermédiaire" },
            { 'F', "Famille" },
            { 'T', "Toilette" },
            { 'M', "Magasin" },
            { 'R', "Restaurant" },
        };

        private string id;
        private string nom;

        private int capacity;

        private char typeAttraction;

        // Mouhammad : oui  Je pense que c'est un dictionnary !!!!
        // ex: <char symbole, string typeAttraction>

        /// <summary>
        /// Constructeur de la classe Attraction.
        /// </summary>
        /// <param name="id">Le ID unique de chaque attraction.</param>
        /// <param name="nom">Le nom de l'attraction.</param>
        /// <param name="capacity">Le nombre maximal de personne pouvant utiliser l'attraction.</param>
        /// <param name="typeAttraction">Les différents établissements du Parc.</param>
        /// <exception cref="InvalidOperationException">Exception qui survient lorsque le type choisi n'existe pas.</exception>
        public Attraction(string id, string nom, int capacity, char typeAttraction)
        {
            this.id = id;
            this.nom = nom;
            this.capacity = capacity;

            if (dictionnaireAttractions.ContainsKey(typeAttraction))
            {
                this.typeAttraction = typeAttraction;
            }
            else
            {
                throw new InvalidOperationException($" {typeAttraction} : Ce type d'attraction n'existe pas !");
            }
        }

        /// <summary>
        /// Getter qui retourne l'ID de la présente attraction.
        /// </summary>
        public string ID => id;

        /// <summary>
        /// Getter qui retourne le nom de la présente attraction.
        /// </summary>
        public string Nom => nom;

        /// <summary>
        /// Getter qui retourne la capacité de la présente attraction.
        /// </summary>
        public int Capacity => capacity;

        /// <summary>
        /// Getter qui retourne le type d'attraction de la présente attraction.
        /// </summary>
        public char TypeAttraction => typeAttraction;
    }
}
