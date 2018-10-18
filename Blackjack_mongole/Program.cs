using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum Sorte
    {
        None=0,
        Coeur=1,
        Carreau=2,
        Trèfle=3,
        Pique=4,
    }


namespace Blackjack_mongole
{
    class Program
    {
        static void Main(string[] args)
        {

            int jetonsJoueur = 100;
            int jetonsJoueurMisés = 0;
            int jetonsIA = 100;
            int jetonsIAMisés = 50;

            Random generateur = new Random();
            Sorte carte1Joueur = (Sorte)generateur.Next(1, 5);
            Sorte carte2Joueur = (Sorte)generateur.Next(1, 5);
            Sorte carte3Joueur = (Sorte)generateur.Next(1, 5);

            int valeur1Joueur = 0;
            int valeur2Joueur = 0;
            int valeur3Joueur = 0;

            Sorte carte1IA = (Sorte)generateur.Next(1, 5);
            Sorte carte2IA = (Sorte)generateur.Next(1, 5);
            Sorte carte3IA = (Sorte)generateur.Next(1, 5);

            int valeur1IA = 0;
            int valeur2IA = 0;
            int valeur3IA = 0;

            int valeurPointsJoueur = 100;
            int valeurPointsIA = 100;

            Sorte genererSorte()
            {
                int sorteCarte = generateur.Next(1, 5);
                return (Sorte)sorteCarte;
            }

            void jetons()
            {
                Console.WriteLine("On donne 100 jetons a vous et a votre adversaire!");
                Console.WriteLine();
                Console.WriteLine("Votre adversaire décide de miser " + jetonsIAMisés + " jetons!");
                Console.WriteLine();
                Console.WriteLine("Combien de jetons voulez vous miser?");

                jetonsJoueurMisés = Convert.ToInt32(Console.ReadLine());

                if (jetonsJoueurMisés > 100)
                {
                    Console.Clear();
                    Console.WriteLine("Vous ne pouvez pas miser plus de jeton de ce que vous avez.");
                    Console.WriteLine();
                    Console.ReadKey();
                    Console.WriteLine("Nous ne jouons pas avec des traitres.");
                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("Vous avez misé " + jetonsJoueurMisés + " jetons.");
                }
            }

            void genererCarteJoueur()
            {
                carte1Joueur = genererSorte();
                carte2Joueur = genererSorte();

                valeur1Joueur = generateur.Next(1, 14);
                valeur2Joueur = generateur.Next(1, 14);

            }

            void genererCarteIA()
            {
                carte1IA = genererSorte();
                carte2IA = genererSorte();

                valeur1IA = generateur.Next(1, 14);
                valeur2IA = generateur.Next(1, 14);

            }

            void afficherCartes()
            {
                Console.WriteLine("Voici vos cartes:");
                Console.WriteLine();
                Console.WriteLine("Carte 1 :" + valeur1Joueur + carte1Joueur);
                Console.WriteLine("Carte 2: " + valeur2Joueur + carte2Joueur);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Voici une des carte de l'adversaire:");
                Console.WriteLine();
                Console.WriteLine("Carte: " + valeur2IA + carte2IA);
                Console.WriteLine();
            }

            void choixJeuJoueur()
            {
                valeurPointsJoueur = valeur1Joueur + valeur2Joueur;
                int choix = 0;
                Console.WriteLine("Voici la valeur de votre jeu: " + valeurPointsJoueur);
                Console.WriteLine();
                Console.WriteLine("Que voulez vous faire?");
                Console.WriteLine("1- Ajouter une carte a votre jeu");
                Console.WriteLine("2- Ne rien faire et rester avec le jeu que vous avez");

                choix = Convert.ToInt32(Console.ReadLine());
                if (choix == 1)
                {
                    carte3Joueur = genererSorte();
                    valeur3Joueur = generateur.Next(1, 14);
                    valeurPointsJoueur = valeurPointsJoueur + valeur3Joueur;

                    Console.WriteLine("Voici votre nouvelle carte:");
                    Console.WriteLine();
                    Console.WriteLine("Carte 3: " + valeur3Joueur + carte3Joueur);
                    Console.WriteLine();
                    Console.WriteLine("Voici la valeur de votre nouveau jeu: " + valeurPointsJoueur);
                    Console.WriteLine();

                }

                else if (choix == 2)
                {
                    Console.WriteLine("Vous avez décidé de rester avec votre jeu, qui vaut: " + valeurPointsJoueur);
                    Console.WriteLine();
                }
            }


            void choixJeuIA()
            {
                valeurPointsIA = valeur1IA + valeur2IA;

                if (valeurPointsIA < valeurPointsJoueur && valeurPointsJoueur <= 21)
                {
                    carte3IA = genererSorte();
                    valeur3IA = generateur.Next(1, 14);
                    Console.WriteLine("Votre adversaire a décidé de piger une autre carte.");
                    Console.WriteLine();
                    Console.WriteLine("Il a pigé cette carte: " + valeur3IA + carte3IA);
                }
                else if (valeurPointsIA > valeurPointsJoueur && valeurPointsIA <= 21)
                {
                    Console.WriteLine("Votre adversaire n'a pas pigé de carte.");
                }
                
            }
            void comparaisonResultat()
            {
                valeurPointsIA = valeurPointsIA + valeur3IA;
                if (valeurPointsJoueur >= 22)
                {
                    Console.WriteLine();
                    Console.WriteLine("Votre jeu vaut " + valeurPointsJoueur + ", ce qui est plus que 21, alors vous perdez!");
                    Console.WriteLine();
                }

                else if (valeurPointsIA >= 22)
                {
                    Console.WriteLine();
                    Console.WriteLine("Le jeu de votre adversaire vaut " + valeurPointsIA + ", ce qui est plus que 21, alors vous gagnez!");
                }

                else if (valeurPointsJoueur <= 21 && valeurPointsJoueur > valeurPointsIA)
                {
                    Console.WriteLine();
                    Console.WriteLine("Votre jeu vaut " + valeurPointsJoueur + ", alors que celui de votre adversaire vaut " + valeurPointsIA + ", ce qui fait que vous gagnez!");
                }

                else if (valeurPointsIA <= 21 && valeurPointsIA > valeurPointsJoueur)
                {
                    Console.WriteLine();
                    Console.WriteLine("Votre jeu vaut " + valeurPointsJoueur + ", alors que celui de votre adversaire vaut " + valeurPointsIA + ", ce qui fait que vous perdez!");
                }

                else if (valeurPointsIA == valeurPointsJoueur)
                {
                    Console.WriteLine("Les deux vous avez des jeux de la même valeur! Qui est de: " + valeurPointsJoueur);
                    Console.WriteLine();
                    Console.WriteLine("Alors, le suzerain du village réquisitionne vos jetons pour payer la dîme du village.");
                }
            }

            void calculJetons()
            {
                if (valeurPointsIA >= 22 || valeurPointsJoueur <= 21 && valeurPointsJoueur > valeurPointsIA )
                {
                    jetonsJoueur = jetonsJoueur + jetonsIAMisés;
                    jetonsIA = jetonsIA - jetonsIAMisés;
                }

                else if (valeurPointsJoueur >= 22 || valeurPointsIA <= 21 && valeurPointsIA > valeurPointsJoueur)
                {
                    jetonsIA = jetonsIA + jetonsJoueurMisés;
                    jetonsJoueur = jetonsJoueur - jetonsJoueurMisés;
                }

                else if (valeurPointsIA == valeurPointsJoueur)
                {
                    jetonsIA = jetonsIA - jetonsIAMisés;
                    jetonsJoueur = jetonsJoueur - jetonsJoueurMisés;
                }
        
            }

            //Le jeu commence ici
            jetonsIAMisés = generateur.Next(1, 101); 

            Console.WriteLine("Bienvenue au blackjack mongole!");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            jetons();

            Console.ReadKey();
            Console.Clear();


            if (jetonsJoueurMisés > 100)
            { }

            else
            {
                genererCarteJoueur();
                genererCarteIA();
                afficherCartes();
                choixJeuJoueur();
                choixJeuIA();
                comparaisonResultat();
                Console.ReadKey();
                calculJetons();

                Console.Clear();
                Console.WriteLine("Vous avez " + jetonsJoueur + " jetons");
                Console.WriteLine();
                Console.WriteLine("Votre adversaire possède " + jetonsIA + " jetons");
                Console.ReadKey();
                Console.Clear();

                Console.WriteLine("La je suis trop pauvre pour faire une boucle, alord le jeu ce fini ici, même si vous voulez encore jouer...");
                Console.WriteLine();
                Console.WriteLine("Quand c'est gratuit, on ne se plaint pas, non?");
                Console.ReadKey();
            }
            //Le jeu fini ici

        }
    }
}
