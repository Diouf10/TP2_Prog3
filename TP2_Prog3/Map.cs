
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



        public Map()
        {
            ImporterMapDeFichier(@"../../../map.txt", out Attraction[,] attractions);
        }

        public void ImporterMapDeFichier(string chemin, out Attraction[,] attractions)
        {
            int longueur = 1;
            int largeur = 1;

            string[] lines = File.ReadAllLines(chemin);

            Console.WriteLine(lines[0]);

            string strLongueur = "";
            string strLargeur = "";

            int i = 0;
            
            string strTemp = string.Empty;

            for(; i < lines[0].Length; i++)
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


            longueur = Convert.ToInt32(strLongueur);
            largeur = Convert.ToInt32(strLargeur);

            Console.WriteLine($"{longueur} .. {largeur}");


            attractions =  new Attraction[longueur, largeur];


            
            
            
            
            /*
            var fichier = File.OpenRead(chemin); // FileStream?

            BinaryReader br = new BinaryReader(fichier);

            br.BaseStream.Position = 0;
            string mesures = br.ReadString();
            
            Console.WriteLine(mesures + "\n");

            int i = 0;

            string strLongueur = "";
            string strLargeur = "";

            for (; mesures[i] != ';'; i++) 
            {
                strLongueur += mesures[i];
            }

            i++;
            longueur = Convert.ToInt32(strLongueur);

            for (; mesures[i] != '\n'; i++)
            {
                strLargeur += mesures[i];
            }

            largeur = Convert.ToInt32(strLargeur);


            for (; i < longueur * largeur; i++)
            {
                string information = br.ReadString();
                Console.Write(information);
            }
            */


        }
    }
}
