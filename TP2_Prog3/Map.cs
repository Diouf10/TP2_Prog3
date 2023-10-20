
using System.Collections;
using System.Runtime.CompilerServices;
using System.Text;

namespace TP2_Prog3
{
    /*
     * Pour la création de la map je pense que nous avons besoin d'un Array :
     *
     * 1- Car nous n'aurons pas besoin d'insérer des données, puisque nous ne voulons pas
     * modifier notre liste après execution, nous aurons simplement besoin d'accéder à la liste
     * pour obtenir les positions de certaines attractions et l'array permet de faire des accès
     * rapidement et efficacement.
     *
     * 2- Car nous connaissons la taille de la carte à l'avance via le fichier map.txt, donc
     * Vu que nous créons notre array une fois et celle-ci ne changera pas de capacité, celui-ci
     * ne prendra pas beaucoup de place en mémoire et sera donc efficace pour les besoins de la
     * map.
     * 
     * - Mouhammad Wagan Diouf
     */

    /*
     * Pour l'import de la map il nous faudra aussi un stringbuilder, car celui-ci fonctionne de la même façon,
     * ça nous éviterait de trop resizer l'array grâce à l'espace disponible d'avance.
     */
    public class Map
    {
        private int _longueur;
        private int _largeur;

        private Attraction?[,] _attractions;

        public Map()
        {

            string[] lines = File.ReadAllLines(@"../../../map.txt");

            //Console.WriteLine(lines[0]);

            string strLongueur = "";
            string strLargeur = "";

            int i = 0;

            string strTemp = string.Empty;

            for (; i < lines[0].Length; i++)
            {
                if (char.IsDigit(lines[0][i]))
                {
                    strLongueur += lines[0][i];

                }
                else
                    break;
            }

            for (; i < lines[0].Length; i++)
            {
                if (char.IsDigit(lines[0][i]))
                {
                    strLargeur += lines[0][i];

                }
            }


            _longueur = Convert.ToInt32(strLongueur);
            _largeur = Convert.ToInt32(strLargeur);

            _attractions = new Attraction?[_longueur, _largeur]; // NULLABLE!!! (À changer maybe?)

            Console.WriteLine($"{_longueur} PAR {_largeur}");

            for (int j = 1; j <= _largeur; j++)
            {
                StringBuilder currentWord = new();

                List<((int posX, int posY), string)> liste = new();

                int posX = 1;

                bool isSpace = false;

                for (int k = 0; k < lines[j].Length; k++)
                {
                    if (lines[j][k] == ' ' && !isSpace)
                    {
                        isSpace = true;

                        string idAttraction = currentWord.ToString();

                        bool estIDValide = false;

                        foreach (char c in idAttraction)
                        {
                            if (char.IsLetterOrDigit(c))
                                estIDValide = true;
                        }

                        if (estIDValide)
                        {
                            liste.Add(((posX, j), idAttraction));
                        }
                    }
                    else if (lines[j][k] != ' ' && isSpace)
                    {
                        currentWord = new();
                        currentWord.Append(lines[j][k]);

                        isSpace = false;

                        posX++; 

                    }
                    else
                    {
                        currentWord.Append(lines[j][k]);
                    }

                }

                foreach(((int X, int Y) position, string id) attraction in liste )
                {
                    _attractions[attraction.position.Y - 1, attraction.position.X - 1] = new Attraction(attraction.id, "PlaceHolder", 4, 'T');
                }
            }
        }

        public int Longueur => _longueur;
        public int Largeur => _largeur;

        public Attraction?[,] Attractions => _attractions;

        // OLD 
        public void ImporterMapDeFichier(string chemin, out Attraction[,] attractions)
        {
            string[] lines = File.ReadAllLines(@"../../../map.txt");

            Console.WriteLine(lines[0]);

            string strLongueur = "";
            string strLargeur = "";

            int i = 0;

            string strTemp = string.Empty;

            for (; i < lines[0].Length; i++)
            {
                if (char.IsDigit(lines[0][i]))
                {
                    strLongueur += lines[0][i];

                }
                else
                    break;
            }

            for (; i < lines[0].Length; i++)
            {
                if (char.IsDigit(lines[0][i]))
                {
                    strLargeur += lines[0][i];

                }
            }


            _longueur = Convert.ToInt32(strLongueur);
            _largeur = Convert.ToInt32(strLargeur);

            Console.WriteLine($"{_longueur} .. {_largeur}");


            attractions = new Attraction[_longueur, _largeur];

        }
    }
}
