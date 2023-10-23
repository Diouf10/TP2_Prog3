// <copyright name="Mouhammad W. Diouf et Alexandre Lavoie" file="Visiteur.cs" company="TP2">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TP2_Prog3
{
    /*
    * Pour l'historique des visiteurs, nous avons choisi d'utiliser une StringBuilder
    *
    * 1 - La première raison pourquoi la StringBuilder serait l'ajout idéal est le fait que nous pouvons
    * pas vraiment le modifier... Les seules choses qu'on peut faire sont la convertion en string (à la fin!)
    * et l'ajout vers la fin. Donc ses méthodes font déjà pas mal toute la job.
    *
    * 2 - Modifier une string (avec concaténation à l'aide de variables) prendrait trop de temps puisqu'à chaque fois
    * que nous "modifions" la string, il est en fait en train d'en créer une tout nouvelle
    * comme avec un array de caractères...
    * La StringBuilder, elle, fonctionne plus comme une List<char>, cependant, elle double toujours sa capacité
    * afin d'éviter les manoeuvres de dupplication inutiles.
    *
    * 3 - En gros, quand on voudrait voir l'historique, on pourrait tout simplement recevoir la StringBuilder,
    * lui appliquer un ToString() et boum! Un seul Console.WriteLine(pour tout le texte!);
    * (- Alex : Par expérience, une succession de WriteLine() est beaucoup plus lente qu'un builder,
    *      voire la concaténation de strings)

    * Note : Puisque le message d'entrée d'entrée est normalement toujours le même,
    */

    using System.Text;

    /// <summary>
    /// La classe visiteurs permet de conserver les données des visiteurs.
    /// </summary>
    public class Visiteur
    {
        /// <summary>
        /// Le nom du visiteur.
        /// </summary>
        private string _nom;

        private StringBuilder _historique;

        /// <summary>
        /// Constructeur de la classe Visiteur.
        /// </summary>
        /// <param name="nom"> Le nom du visiteur. </param>
        public Visiteur(string nom)
        {
            _historique = new StringBuilder();
            _nom = nom;
        }

        /// <summary>
        /// Getter qui retourne le nom du visiteur.
        /// </summary>
        public string Nom => _nom;

        /// <summary>
        /// Getter qui retourne la string de l'historique convertie du StringBuilder.
        /// </summary>
        public string Historique => _historique.ToString();

        /// <summary>
        /// Permet d'ajouter une action dnas l'historique du visiteur.
        /// </summary>
        /// <param name="action">une action qui est fait pour un visiteur.</param>
        public void AjouterElementDansHistorique(string action)
        {
            _historique.Append(action);
        }

        /// <summary>
        /// Cette méthode est sûrement inutile, mais elle vide l'historique.
        /// </summary>
        public void ViderHistorique()
        {
            _historique = new StringBuilder();
        }
    }
}
