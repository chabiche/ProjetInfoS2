using System;
using System.IO; // A rajouter obligatoirement
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization; // A rajouter obligatoirement

namespace ProjetInfoS2
{
    public class Program
    {
        static void Main(string[] args)
        {
            DateTime maintenant = DateTime.Now;

            //CREATION DE LA CUISINE
            Cuisine C = new Cuisine();

            //CREATION DE LA SALLE
            Salle restau = new Salle();

            //LECTURE DU FICHIER XML
           restau.creationFormulesXml();
           restau.creationTablesXml();
           C.lecureXMLCuisto();
           restau.creationReservationXml();
           //test sérialisation
           //DateTime dateresa=new DateTime(2015, 05, 15, 21, 00, 00);
           //restau.validerResa(restau.tables[0], dateresa, 2, restau.formules[0]);
           //Console.WriteLine(C);
           //Console.ReadLine();

            int choix = 0;
            bool menu = true;
            do
            {
                switch (choix)
                {
                        case 0:
                        Console.Clear();
                        Console.WriteLine(@"Bonjour et bienvenue !
Que souhaitez-vous réaliser?

1- Consulter tout le planning de réservations
2- Ajouter une réservation
3- Consulter les réservations correspondant à une date donnée
4- Consulter les réservations correspondant à une date et une heure données

* Pour quitter le programme: 99 *

Entrez le chiffre correspondant à l'action que vous souhaitez réaliser");

                        bool ok = false;
                        while (ok == false)
                        {
                            try
                            {
                                choix = int.Parse(Console.ReadLine());
                                ok = true;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Veuillez entrer un chiffre s'il vous plait.");
                                ok = false;
                            }
                        }
                        
                        break;

                    //AJOUTER UN CUISINIER
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Voici le planning des réservations: \n\n");
                        restau.affichePlanningResa();

                        //bool format = false;
                        //string chaine;
                        //do
                        //{
                        //    Console.WriteLine("Vous souhaitez ajouter un cuisinier. Quel est le numéro de ce cuisinier?");
                        //    chaine = Console.ReadLine();
                        //    format = chaine.All(Char.IsDigit);
                        //    // Renvoie true si la saisie de l'utilisateur est bien un entier, false dans les autres cas
                        //    if (format == false)
                        //    {
                        //        Console.WriteLine("Veuillez saisir uniquement des chiffres, svp.");
                        //    }
                        //}
                        //while (format == false);
                        //int noCuisto = int.Parse(chaine);
                        //C.ajoutCuisto(noCuisto);

                        Console.WriteLine("Appuyez sur une touche afin de retourner au menu");
                        Console.ReadLine();
                        choix = 0;
                        break;


                    case 2:
                        Console.Clear();
                        DateTime dateResa = new DateTime();;
                        int nbConvive=new int();
                        int formuleChoisie=new int();
                        TimeSpan heureResa= new TimeSpan();
                        ok = false;

                        Console.WriteLine("Vous souhaitez entrer une réservation. \nEntrez la date sous le format AAAA/MM/JJ:");
                        while (ok==false)
                        {
                            try
                            {
                                dateResa = DateTime.Parse(Console.ReadLine());
                                ok = true;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Le format n'est pas bon veuillez recommencer la saisie.");
                                ok = false;
                            }
                        }
                        ok = false;
                        Console.WriteLine("Entrez l'heure sous le format hhmm:");
                        while (ok == false)
                        {   
                            
                            try
                            {
                                heureResa = TimeSpan.Parse(Console.ReadLine());
                                ok = true;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Le format n'est pas bon veuillez recommencer la saisie.");
                                ok = false;
                            }
                            TimeSpan max = new TimeSpan(23, 59, 00);
                            do
                            {
                                Console.WriteLine("L'heure de réservation n'est pas correcte. Veuillez recommencer.");
                                try
                                {
                                    heureResa = TimeSpan.Parse(Console.ReadLine());
                                    ok = true;
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Le format n'est pas bon veuillez recommencer la saisie.");
                                    ok = false;
                                }
                             } while (heureResa>max || ok==false);
                        }
                        
                        dateResa = dateResa + heureResa;

                        Console.WriteLine("Entrez le nombre de personne souhaitant manger dans le restaurant");
                        ok = false;
                        while (ok == false)
                        {
                            try
                            {
                                nbConvive = int.Parse(Console.ReadLine());
                                ok = true;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Le format n'est pas bon veuillez recommencer la saisie.");
                                ok = false;
                            }
                        }
                        

                        Formule formuleResa = new Formule();
                        bool pb = false;
                        do
                        {
                            if (pb==true)
                            {
                                Console.WriteLine("La formule n'a pas été trouvée");
                            }

                            Console.WriteLine("Entrez le numéro de la formule retenue: \nVoici la liste de celles ci.");
                            restau.afficheFormule();
                            ok = false;
                            while (ok == false)
                            {
                                try
                                {
                                    formuleChoisie = int.Parse(Console.ReadLine());
                                    ok = true;
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Entrez un numéro s'il vous plait.");
                                    ok = false;
                                }
                            }
                            

                            formuleResa = restau.retourneFormule(formuleChoisie); //--> permet de retouver la formule par rapport au numéro rentré
                            Console.WriteLine(formuleResa);
                            pb = true;
                        } while (formuleResa.dureePreparation == null);
                        if (formuleResa.dureePreparation != null)
                        {
                            restau.verifierResa(dateResa, nbConvive, formuleResa, C);
                        }

                        Console.WriteLine("Appuyez sur une touche afin de retourner au menu");
                        Console.ReadLine();
                        choix = 0;// permet de retourner au menu
                        break;


                    case 3:
                        Console.Clear();
                        
                        restau.afficheResaDate();

                        Console.WriteLine("Appuyez sur une touche afin de retourner au menu");
                        Console.ReadLine();
                        choix = 0;// permet de retourner au menu
                        break;

                    case 4:
                        Console.Clear();
                        
                        restau.afficheResaDateHeure();

                        Console.WriteLine("Appuyez sur une touche afin de retourner au menu");
                        Console.ReadLine();
                        choix = 0;// permet de retourner au menu
                        break;

                    case 99:
                        menu = false;
                        break;

                    default: 
                        Console.Clear();
                        Console.WriteLine("Le chiffre saisi n'est pas présent dans le menu. \nAppuyez sur une touche pour recommencer");
                        Console.ReadLine();
                        choix = 0;
                        break;

                }//fin switch

            } while (menu == true);

        }// fin main
    }
}
