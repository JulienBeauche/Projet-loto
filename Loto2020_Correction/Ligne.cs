using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loto2020_Correction
{
    public class Ligne
    {
        // Les 9 colonnes de la lignes
        int[] lesNumeros;

        /// <summary>
        /// Constructeur par défaut, la ligne est vide et non marquée
        /// Il est privé, donc inaccessible de l'extérieur
        /// </summary>
        private Ligne()
        {
            lesNumeros = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        }

        /// <summary>
        /// Constructeur à paramètre : Un tableau de 5 valeur pour initialiser la ligne
        /// Les nombres peuvent être dans n'importe quel ordre
        /// Il n'y a pas de doublon
        /// </summary>
        /// <param name="initNumbers"></param>
        // Ici, on appelle le constructeur par défaut, avant d'executer le code
        public Ligne(int[] initNumbers) : this()
        {
            // Une ligne contient 5 nombres, si ce n'est pas bon ... -->> Exception !
            if ((initNumbers == null) || (initNumbers.Length != 5))
            {
                throw new Exception("L'initialisation de la ligne est incorrecte: La taille est incorrecte");
            }
            // On va remplir et vérifier
            foreach (int number in initNumbers)
            {
                if ((number <= 0) || (number > 90))
                {
                    throw new Exception("Chaque numéro doit être compris entre 1 et 90.");
                }
                // Quelle dizaine ?
                int dizaine = number / 10;
                // Cas particulier
                if (number == 90)
                    dizaine = 8;
                // La case déjà remplie !?
                if (lesNumeros[dizaine] != 0)
                {
                    throw new Exception("L'initialisation de la ligne est incorrecte: Deux nombres pour la même dizaine.");
                }
                else
                {
                    lesNumeros[dizaine] = number;
                }
            }
        }

        /// <summary>
        /// Accède à la ligne comme à un tableau
        /// </summary>
        /// <param name="index">La position à lire (entre 0 et 8)</param>
        /// <returns>Le nombre présent dans le carton</returns>
        public int this[int index]
        {
            get
            {
                // Est ce que l'index est correct ?
                if ((index >= 0) && (index < this.lesNumeros.Length))
                {
                    return this.lesNumeros[index];
                }
                // Non => Exception
                throw new IndexOutOfRangeException();
            }
        }

    }
}
