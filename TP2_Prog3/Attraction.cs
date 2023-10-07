using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Prog3
{
    public class Attraction
    {
        private int _ID;
        private string _nom;

        private int _capacity;

        // Type d'attraction -> Dictionnary? TODO!!!!!

        

        public Attraction(int ID, string Nom, int Capacity)
        {
            _ID = ID;
            _nom = Nom;
            _capacity = Capacity;
        }
    }    
}
