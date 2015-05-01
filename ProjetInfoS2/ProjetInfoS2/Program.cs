using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetInfoS2
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime maintenant = DateTime.Now;

            //CREATION DES FORMULES

            //FormuleRapide
            TimeSpan dureePreparationRapide = new TimeSpan(0, 10, 0);
            TimeSpan dureePresenceClientRapide = new TimeSpan(0, 20, 0);
            Formule formuleRapide = new Formule(dureePreparationRapide, dureePresenceClientRapide, true);
            //FormuleNormale
            TimeSpan dureePreparationNormal = new TimeSpan(0, 20, 0);
            TimeSpan dureePresenceClientNormal = new TimeSpan(0, 50, 0);
            Formule formuleNormale = new Formule(dureePreparationNormal, dureePresenceClientNormal, true);
            //FormuleGastronomique
            TimeSpan dureePreparationGastro = new TimeSpan(0, 30, 0);
            TimeSpan dureePresenceClientGastro = new TimeSpan(1, 30, 0);
            Formule formuleGastro = new Formule(dureePreparationGastro, dureePresenceClientGastro, true);
            //FormuleSimpleConso
            TimeSpan dureePreparationConso = new TimeSpan(0, 5, 0);
            TimeSpan dureePresenceClientConso = new TimeSpan(0, 20, 0);
            Formule formuleConso = new Formule(dureePreparationConso, dureePresenceClientConso, true);

            int choix = 0;
            bool menu=true;
            do
            {
                
            
            switch (choix)
            {

                case 0:
                    Console.Clear();
                    Console.WriteLine(@"Bonjour et bienvenu !
Que souhaitez-vous réaliser?

1- Ajouter un cuisinier");
                    Console.WriteLine(maintenant);
                    choix = int.Parse(Console.ReadLine());
                    break;

                    //AJOUTER UN CUISINIER
                case 1:
                    Console.Clear();
                    bool format = false;
                    string chaine;
                    do
                    {
                        Console.WriteLine("Vous souhaitez ajouter un cuisinier. Quel est le numéro de ce cuisinier?");
                        chaine = Console.ReadLine();
                        format = chaine.All(Char.IsDigit);
                        // Renvoie true si la saisie de l'utilisateur est bien un entier, false dans les autres cas
                        if (format==false)
                        {
                            Console.WriteLine("Veuillez saisir uniquement des chiffres, svp.");
                        }
                    } while (format==false);
                    int noCuisto = int.Parse(chaine);
                    //ajoutCuisto(noCuisto);
                    choix = 0;
                    break;


                case 2:
                    Console.Clear();
                    Console.WriteLine("Case 2");
                    break;


                default:
                    Console.Clear();
                    Console.WriteLine("Coucou");
                    break;

                    }//fin switch

                } while (menu==true);
                    Console.ReadLine();
            
        }// fin main
    }
}
