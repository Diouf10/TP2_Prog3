using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Prog3
{
    public class Attraction
    {
        private string _ID;
        private string _nom;

        private int _capacity;

        private char _typeAttraction;

        private Dictionary<char, string> DictionnaireAttractions = new Dictionary<char, string>()
        {
            {'S', "Sensation Forte"},
            {'I', "Intermédiaire"},
            {'F', "Famille"},
            {'T', "Toilette"},
            {'M', "Magasin"},
            {'R', "Restaurant"}
        };

        // Type d'attraction -> Dictionnary? TODO!!!!!
        // Mouhammad : oui  Je pense que c'est un dictionnary !!!!
        // ex: <char symbole, string typeAttraction>
        
        
        /// <summary>
        /// Constructeur de la classe Attraction
        /// </summary>
        /// <param name="ID">Le ID unique de chaque attraction</param>
        /// <param name="Nom">Le nom de l'attraction</param>
        /// <param name="Capacity">Le nombre maximal de personne pouvant utiliser l'attraction</param>
        /// <param name="TypeAttraction">Les différents établissements du Parc</param>
        /// <exception cref="InvalidOperationException">Exception qui survient lorsque le type choisi n'existe pas.</exception>
        public Attraction(string ID, string Nom, int Capacity, char TypeAttraction)
        {
            _ID = ID;
            _nom = Nom;
            _capacity = Capacity;

            if (DictionnaireAttractions.ContainsKey(TypeAttraction)) 
            {
                _typeAttraction = TypeAttraction;
            }
            else
            {
                throw new InvalidOperationException("Ce type d'attraction n'existe pas !");
            }
        }

        public string ID => _ID;
        public string Nom => _nom;
        public int Capacity => _capacity;

        public char TypeAttraction => _typeAttraction;

    }
}
