// <copyright name="Mouhammad W. Diouf et Alexandre Lavoie" file="Map.cs" company="TP2">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TP2_Prog3
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    /*
     * Pour la création de la map je pense que nous avons besoin d'un Array2D :
     *
     * 1- Car nous n'aurons pas besoin d'insérer des données au fur et à mesure, car nous aurons les dimensions
     * de la carte, puisque nous ne n'aurons pas besoin d'ajouter de données supplémentaires qui fera grossir
     * notre liste, après execution, nous aurons simplement besoin d'accéder à la liste pour ajouter et obtenir
     * les positions de certaines attractions et l'array permet de faire des accès rapidement et efficacement.
     *
     * 2- Car nous connaissons la taille de la carte à l'avance via le fichier map.txt, donc
     * Vu que nous allons crée notre array2D, celle-ci ne changera pas de capacité, celui-ci
     * ne prendra pas beaucoup de place en mémoire et sera donc efficace pour les besoins de la
     * map.
     *
     * - Mouhammad Wagan Diouf
     */

    /// <summary>
    /// Classe qui pemrmet de conservé et de générer une map.
    /// </summary>
    public class Map
    {
        private int _longueur;
        private int _largeur;

        private Attraction?[,] _attractions;

        /// <summary>
        /// Constructeur de la clase map.
        /// </summary>
        public Map()
        {
            string[] lines = File.ReadAllLines(@"../../../map.txt");

            string strLongueur = string.Empty;
            string strLargeur = string.Empty;

            int i = 0;

            for (; i < lines[0].Length; i++)
            {
                if (char.IsDigit(lines[0][i]))
                {
                    strLongueur += lines[0][i];
                }
                else
                {
                    break;
                }
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

            for (int j = 1; j <= _largeur; j++)
            {
                StringBuilder currentWord = new ();

                List<((int posX, int posY), string)> liste = new ();

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
                            {
                                estIDValide = true;
                            }
                        }

                        if (estIDValide)
                        {
                            liste.Add(((posX, j), idAttraction));
                        }
                    }
                    else if (lines[j][k] != ' ' && isSpace)
                    {
                        currentWord = new ();
                        currentWord.Append(lines[j][k]);

                        isSpace = false;

                        posX++;
                    }
                    else
                    {
                        currentWord.Append(lines[j][k]);
                    }
                }

                foreach (((int X, int Y) position, string id) attraction in liste)
                {
                    _attractions[attraction.position.Y - 1, attraction.position.X - 1] = new Attraction(attraction.id, "PlaceHolder", 4, 'T');
                }
            }
        }

        /// <summary>
        /// Permet d'obtenir la longueur de la map.
        /// </summary>
        public int Longueur => _longueur;

        /// <summary>
        /// Permet d'obtenir la largeur de la map.
        /// </summary>
        public int Largeur => _largeur;

        /// <summary>
        /// Permet d'obtenir la map d'attractions.
        /// </summary>
        public Attraction?[,] Attractions => _attractions;
    }
}
