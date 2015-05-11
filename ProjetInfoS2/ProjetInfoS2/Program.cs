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

            //CHARGEMENT DES FORMULES A PARTIR DU FICHIER XML
            restau.creationFormulesXml();
          

            ////Serialisation Reservation
            //XmlNode resaNodes = doc.SelectSingleNode("//Restaurant/Reservations");
            //XmlNode noeudBase = doc.CreateElement("Reservation");
            //XmlNode tableNode = doc.CreateElement("tableResa");
            //tableNode.InnerText = "23";
            //noeudBase.AppendChild(tableNode);

            //resaNodes.AppendChild(noeudBase);
            
            //XmlNode nomClientNode = doc.CreateElement("nomClient");
            //nomClientNode.InnerText = "John Doe";
            //noeudBase.AppendChild(nomClientNode);
            //XmlNode numClientNode = doc.CreateElement("numClient");
            //numClientNode.InnerText = "1";
            //noeudBase.AppendChild(numClientNode);
            //XmlNode dateNode = doc.CreateElement("dateResa");
            //dateNode.InnerText = "11/06/2015 20:00:00";
            //noeudBase.AppendChild(dateNode);
            //XmlNode nbConviveNode = doc.CreateElement("nbConvive");
            //nbConviveNode.InnerText = "4";
            //noeudBase.AppendChild(nbConviveNode);
            //XmlNode formuleNode = doc.CreateElement("formuleResa");
            //formuleNode.InnerText = "Formule Gastronomique";
            //noeudBase.AppendChild(formuleNode);

            //doc.Save("restaurant.xml");

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

                        // pour la date et l'heure il faudrait tout rentrer dans la même variable --> je sais pas comment faire
                        Console.WriteLine("Vous souhaitez entrer une réservation. Entrez la date (FORMAT)");
                        dateResa = DateTime.Parse(Console.ReadLine());
                        
                        Console.WriteLine("Entrez le nombre de personne souhaitant manger dans le restaurant.");
                        nbConvive = int.Parse(Console.ReadLine());
                        Console.WriteLine("Entrez le numéro de la formule retenue: \nVoici la liste de celles ci.");
                        restau.afficheFormule();
                        formuleChoisie=int.Parse(Console.ReadLine());
                        //rechercheFormule(formuleChoisie) --> permet de retouver la formule par rapport au numéro rentré
                        //restau.verifierResa(dateResa, nbConvive, formuleChoisie);
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
