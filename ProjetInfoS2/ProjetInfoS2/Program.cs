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

            //CREATION DE LA CUISINE
            Cuisine C = new Cuisine();


            int choix = 0;
            bool menu=true;
            do
            {
                switch (choix)
                {

                    case 0:
                        Console.Clear();
                        Console.WriteLine(@"Bonjour et bienvenue !
Que souhaitez-vous réaliser?

1- Ajouter un cuisinier
2- Faire une réservation
3- Consulter les réservations");
                        //Console.WriteLine(maintenant);
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
                    } 
                    while (format==false);
                    int noCuisto = int.Parse(chaine);
                    C.ajoutCuisto(noCuisto);
                    

                    choix = 0;
                    break;


                case 2:
                    Console.Clear();
                    Console.WriteLine("Vous souhaitez entrer une réservation. Entrez la date ()");
                    Console.ReadLine();
                    choix = 0;
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("Vous souhaitez consulter une réservation. Entrez une date (FORMAT)");
                    //afficheResaDate();
                    Console.ReadLine();
                    choix = 0;
                    break;


                default: //Verifier ce que ca fait
                    Console.Clear();
                    Console.WriteLine("Erreur");
                    Console.ReadLine();
                    choix = 0;
                    break;

                    }//fin switch

                } while (menu==true);
                    Console.ReadLine();
            
        }// fin main
    }
}
