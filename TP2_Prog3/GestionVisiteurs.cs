// <copyright name="Mouhammad W. Diouf et Alexandre Lavoie" file="GestionVisiteurs.cs" company="TP2">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TP2_Prog3;
/*
 * 1 - La file d'attente devrait utiliser la structure de donnée (Queue<Visiteur>).
 * Les files d'attentes, elles, devraient être conservés dans des Queues (premier arrivé, premier sorti.)
 * puisqu'on ne veux qu'accéder/retirer à la tête et ajouter à la queue,
 * l'accès sera donc très efficace pour ce que nous voulons.
 * De plus, le "array resizing" est aussi rare que dans la liste puisque la capacité double, en plus
 * que l'organisation se refait à chaque fois qu'un resize est déclanché afin d'économiser de l'espace mémoire.

 * 2 - Pour gérer que chaque attraction puisse avoir ses visiteurs, les meilleures options seraient
 * le Dictionnary et la HashTable, puisqu'ils nous permettemt d'accéder rapidement à un élément à l'aide dune clé.
 * Le dictionnary serait le plus facile à utiliser puisqu'il est fortement typé, facilitant beaucoup le codage et la gestion
 * des types face à la HashTable, qui peut contenir pratiquement n'importe quoi. De plus, nous n'avons pas d'informations
 * personnelles ou importantes à propos de quiconque, donc la sécurité n'est pas le plus important. Aussi, grâce au système de clé,
 * l'acquisition d'une file en particulier est beaucoup plus rapide que si nous avions essayé avec un Array de Queue<Visiteur>...
 *
 * Initialement, pour chaque "clé" potentielles, il n'y aura pas de file, mais lorsqu'on essaie d'ajouter des personnes à une
 * file qui n'a pas encore été ajoutée au dictionnaire, une nouvelle instance de Queue<Visiteur> sera imémédiatement créée
 * et sera inséré dans le dictionnaire avec le ID de l'attraction comme clé.

 * 3 - Pour la gestion des visiteurs, nous avons choisi la LinkedList<>. Alors que, face à un Array, la LinkedList est
 * la moins efficace des structures de données dans le domaine de l'accès, celle-ci n'aura pas besoin d'accès direct par
 * index, donc son point négatif majeur est annulé. Aussi, la LinkedList est très puissante en matière
 * d'ajout et de retrait d'éléments, ce qui arrivera souvent car il y aura souvent des visiteurs qui
 * entrent et sortent du parc. Alors que l'Array ou la List auraient dû faire plusieurs (surtout l'Array) resize...
 * ralentissant massivement l'application...
 */

/// <summary>
/// La classe de gestion visiteru permet de gérer les visteurs du parc.
/// </summary>
public class GestionVisiteurs
{
    // Quelle structure de donnée serait adéquate pour avoir la liste des visiteurs?
    private List<Visiteur> _visiteurs;

    // Commentaires à faire, dis moi si les tructure de données choisi sint bonnes ???
    private Dictionary<string, Queue<Visiteur>> _filesAttente;
    private Parc _parc;

    /// <summary>
    /// Constructeur de la classe GestionVisiteurs.
    /// </summary>
    /// <param name="parc">Le parc où on gère les visiteurs.</param>
    /// <exception cref="ArgumentNullException">Vérifier que le parc n'est pas null.</exception>
    public GestionVisiteurs(Parc parc)
    {
        if (parc is null)
        {
            throw new ArgumentNullException(nameof(parc));
        }

        _parc = parc;

        _visiteurs = new List<Visiteur>();

        _filesAttente = new Dictionary<string, Queue<Visiteur>>();
    }

    /// <summary>
    /// Getter qui obtient la liste des visiteurs, mais une version clonée en array.
    /// </summary>
    public Visiteur[] Visiteurs => _visiteurs.ToArray();

    /// <summary>
    /// Permet d'obtenir le nombre de visiteurs dans la files d'attentes.
    /// </summary>
    /// <param name="id">le id de l'attraction.</param>
    /// <returns>Retourne le le nombre de visteurs dans la files d'attentes.</returns>
    public int GetQueueCount(string id)
    {
        Queue<Visiteur>? file = _filesAttente.GetValueOrDefault(id);

        if (file is not null)
        {
            return file.Count;
        }
        else
        {
            return -1; // laisse à -1 pour le moment, ça aide à mieux comprendre comment le code fonctionne.

            // j'ai volontairement mis le code pas beau pour que styleCop force l'un de nous à réviser ce code et change le -1 pour un 0..
            // à retirer lorsque terminé
        }
    }

    /// <summary>
    /// Permet de faire entrer le visiteur dans la file d'attente.
    /// </summary>
    /// <param name="attractionId">le id d'une attraction.</param>
    /// <param name="visiteur">le visiteur qui veut entrer dans la file d'attente.</param>
    public void EntrerVisiteurDansFileAttente(string attractionId, Visiteur visiteur)
    {
        if (attractionId is null)
        {
            throw new ArgumentNullException(nameof(attractionId));
        }

        if (visiteur is null)
        {
            throw new ArgumentNullException(nameof(visiteur));
        }

        if (_parc.Attractions.ContainsKey(attractionId) && _filesAttente.GetValueOrDefault(attractionId) != null) // n
        {
            _filesAttente.GetValueOrDefault(attractionId) !.Enqueue(visiteur); // 1 ou n
        }
        else
        {
            Queue<Visiteur> file = new Queue<Visiteur>();

            file.Enqueue(visiteur);

            _filesAttente.Add(attractionId, file); // 1
        }

        visiteur.AjouterElementDansHistorique($"Entrée dans la file d'attente de l'attraction {attractionId}.");
    }

    /// <summary>
    /// Cette méthode permet d'ajouter un visiteur dans l'attraction, ce qui le retire de la file d'attente de celle-ci.
    /// </summary>
    /// <param name="attractionId"> L'ID de l'attraction en question. </param>
    public void EntrerVisiteurDansAttraction(string attractionId)
    {
        if (attractionId is null)
        {
            throw new ArgumentNullException(nameof(attractionId));
        }

        if (_filesAttente.ContainsKey(attractionId))
        {
            Queue<Visiteur> fileAttente = _filesAttente.GetValueOrDefault(attractionId) !;

            if (fileAttente.Count == 0)
            {
                throw new InvalidOperationException();
            }

            fileAttente.Dequeue().AjouterElementDansHistorique($"Entrée dans l'attraction {attractionId}");
        }
    }

    /// <summary>
    /// Permet de faire entrer un visiteur dans le parc.
    /// </summary>
    /// <param name="visiteur">un visiteur qui veut entrer dans le parc.</param>
    /// <exception cref="ArgumentNullException">vérifier que le visiteur n'est pas null.</exception>
    public void EntrerVisiteurDansParc(Visiteur visiteur)
    {
        if (visiteur is null)
        {
            throw new ArgumentNullException(nameof(visiteur));
        }

        _visiteurs.Add(visiteur); // O(1) !
        visiteur.AjouterElementDansHistorique("Entrée dans le parc.");
    }

    /// <summary>
    /// Permet de faire sortir un visiteur du parc.
    /// </summary>
    /// <param name="visiteur">le visiteur qui veut sortir du parc.</param>
    public void SortirVisiteurDuParc(Visiteur visiteur)
    {
        _visiteurs.Remove(visiteur); // O(n) !!!

        visiteur.AjouterElementDansHistorique("Sortie du parc.");
    }
}
