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
           DateTime dateresa=new DateTime(2015, 05, 15, 21, 00, 00);
           restau.validerResa(restau.tables[0], dateresa, 2, restau.formules[0]);
           //Console.WriteLine(C);
           //Console.ReadLine();
           //Console.WriteLine(restau);


            

            //doc.DocumentElement.InnerText: affiche le texte entre> <
            //doc.DocumentElement.Name: affiche le nom de la balise
            //doc.DocumentElement.InnerXml: écrit tout, avec les balises, sauf la première englobante
            //doc.DocumentElement.OuterXml: écrit tout avec les balises, même la première englobante
            //doc.DocumentElement.Attributes["name"].Value: affiche l'attribut

            

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

1- Ajouter un cuisinier
2- Faire une réservation
3- Consulter les réservations");

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
                            if (format == false)
                            {
                                Console.WriteLine("Veuillez saisir uniquement des chiffres, svp.");
                            }
                        }
                        while (format == false);
                        int noCuisto = int.Parse(chaine);
                        C.ajoutCuisto(noCuisto);


                        choix = 0;
                        break;


                    case 2:
                        Console.Clear();
                        DateTime dateResa;
                        int nbConvive;
                        int formuleChoisie;
                        TimeSpan heureResa;
                        

                         //pour la date et l'heure il faudrait tout rentrer dans la même variable --> je sais pas comment faire
                        Console.WriteLine("Vous souhaitez entrer une réservation. Entrez la date  et l'heure sous le format AAAA/MM/JJ");
                        dateResa = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Entrez l'heure sous le format hh:mm");
                        heureResa = TimeSpan.Parse(Console.ReadLine());
                        dateResa = dateResa + heureResa;
                        //Console.WriteLine(dateResa);
                        //Console.WriteLine("Entrez le nombre de personne souhaitant manger dans le restaurant");
                        //nbConvive = int.Parse(Console.ReadLine());
                        //Console.WriteLine("Entrez le numéro de la formule retenue: \nVoici la liste de celles ci.");
                        //restau.afficheFormule();
                        //formuleChoisie=int.Parse(Console.ReadLine());
                        Formule formuleResa = new Formule();
                        formuleResa = restau.retourneFormule(1); //--> permet de retouver la formule par rapport au numéro rentré
                        if (formuleResa.dureePreparation != null)
                        {
                            restau.verifierResa(dateResa, 4, formuleResa, C);
                        }
                        else
                        {
                            Console.WriteLine("La formule n'a pas été trouvée");
                        }
                       // restau.verifierResa(dateResa, nbConvive, formuleResa, C);
                        choix = 0;
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Vous souhaitez consulter une réservation. Entrez une date (FORMAT)");
                        restau.afficheResaDate();
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

            } while (menu == true);
            Console.ReadLine();

        }// fin main
    }
}
