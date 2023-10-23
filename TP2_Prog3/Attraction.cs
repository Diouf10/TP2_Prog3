// <copyright name="Mouhammad W. Diouf et Alexandre Lavoie" file="Attraction.cs" company="TP2">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TP2_Prog3
{
    /// <summary>
    /// Classe Attraction permet de conserver les données d'una attraction.
    /// </summary>
    public class Attraction
    {
        private string id;
        private string nom;

        private int capacity;

        private char typeAttraction;

        private static Dictionary<char, string> dictionnaireAttractions = new Dictionary<char, string>()
        {
            { 'S', "Sensation Forte" },
            { 'I', "Intermédiaire" },
            { 'F', "Famille" },
            { 'T', "Toilette" },
            { 'M', "Magasin" },
            { 'R', "Restaurant" },
        };

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
                throw new InvalidOperationException("Ce type d'attraction n'existe pas !");
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

        /// <summary>
        /// Permet d'obtenir le titre de l'attraction selon son type d'attarction.
        /// </summary>
        /// <param name="typesAttraction">le type d'attraction d'une attarction.</param>
        /// <returns>Retourne le titre de l'attraction.</returns>
        [Obsolete] // PAS ENCORE FAIT... SERA POTENTIELLEMENT INUTILE!.
        public string TypeAttractionTitre(char typesAttraction)
        {
            switch (typesAttraction)
            {
                case 'S':

                    break;
                case 'I':

                    break;
                case 'F':

                    break;
                case 'T':

                    break;
                case 'M':

                    break;
                case 'R':

                    break;
                default:
                    // code block
                    break;
            }

            return string.Empty;
        }
    }
}
