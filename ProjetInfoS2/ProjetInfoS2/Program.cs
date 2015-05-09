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

            //CREATION DES FORMULES
            //FormuleRapide
            TimeSpan dureePreparationRapide = new TimeSpan(0, 10, 0);
            TimeSpan dureePresenceClientRapide = new TimeSpan(0, 20, 0);
            Formule formuleRapide = new Formule("Formule Rapide", dureePreparationRapide, dureePresenceClientRapide, true);
            //FormuleNormale
            TimeSpan dureePreparationNormal = new TimeSpan(0, 20, 0);
            TimeSpan dureePresenceClientNormal = new TimeSpan(0, 50, 0);
            Formule formuleNormale = new Formule("Formule Normale", dureePreparationNormal, dureePresenceClientNormal, true);
            //FormuleGastronomique
            TimeSpan dureePreparationGastro = new TimeSpan(0, 30, 0);
            TimeSpan dureePresenceClientGastro = new TimeSpan(1, 30, 0);
            Formule formuleGastro = new Formule("Formule Gastronomique", dureePreparationGastro, dureePresenceClientGastro, true);
            //FormuleSimpleConso
            TimeSpan dureePreparationConso = new TimeSpan(0, 5, 0);
            TimeSpan dureePresenceClientConso = new TimeSpan(0, 20, 0);
            Formule formuleConso = new Formule("Formule simple consomation", dureePreparationConso, dureePresenceClientConso, true);

            //Désérialisation:
            XmlDocument doc = new XmlDocument();
            doc.Load("test-doc.xml");
            foreach (XmlNode xmlNode in doc.DocumentElement.ChildNodes[0].ChildNodes)
                Console.WriteLine(doc.DocumentElement.InnerText);
            Console.ReadKey();
            //doc.DocumentElement.InnerText: affiche le texte entre> <
            //xmlDoc.DocumentElement.Name: affiche le nom de la balise
            //xmlDoc.DocumentElement.Attributes["name"].Value: affiche l'attribut

            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.Load("restaurant.xml");
            //XmlNode rootNode = xmlDoc.CreateElement("formules");
            //xmlDoc.AppendChild(rootNode);

            //XmlNode userNode = xmlDoc.CreateElement("formule");
            //XmlAttribute attribute = xmlDoc.CreateAttribute("age");
            //attribute.Value = "42";
            //userNode.Attributes.Append(attribute);
            //userNode.InnerText = "John Doe";
            //rootNode.AppendChild(userNode);

            //userNode = xmlDoc.CreateElement("user");
            //attribute = xmlDoc.CreateAttribute("age");
            //attribute.Value = "39";
            //userNode.Attributes.Append(attribute);
            //userNode.InnerText = "Jane Doe";
            //rootNode.AppendChild(userNode);

            //xmlDoc.Save("restaurant.xml");

            //XmlNodeList userNodes = xmlDoc.SelectNodes("//users/user");
            //foreach (XmlNode userNode in userNodes)
            //{
            //    int age = int.Parse(userNode.Attributes["age"].Value);
            //    userNode.Attributes["age"].Value = (age + 1).ToString();
            //}
            //xmlDoc.Save("test-doc.xml"); 

            //On crée une instance de XmlSerializer
            XmlSerializer serializer = new XmlSerializer(typeof(Formule));

            //Création d'un Stream Writer qui permet d'écrire dans un fichier. On lui spécifie le chemin
            //et si le flux devrait mettre le contenu à la suite de notre document (true) ou s'il devrait
            //l'écraser (false).
            StreamWriter writer = new StreamWriter("Test.xml", true);

            //On sérialise en spécifiant le flux d'écriture et l'objet à sérialiser.
            serializer.Serialize(writer, formuleConso);

            //IMPORTANT : On ferme le flux en tous temps !!!
            writer.Close();

            //CREATION DE LA CUISINE
            Cuisine C = new Cuisine();

            //CREATION DE LA SALLE
            Salle restau = new Salle();

            //CREATION DUNE TABLE
            TableCarree table1 = new TableCarree();


            //CREATION DUNE RESERVATION
            DateTime dateBezard = new DateTime(2015, 5, 12, 19, 30, 0);

            //serialisation réservation
            Reservation resa1 = new Reservation(table1, "Bezard", 1, dateBezard, 4, formuleGastro);
            //{
            //table = table1,
            //nomClient = "Bezard",
            //numClient = 1,
            //dateReservation = dateBezard,
            //nbConvives = 4,
            //formuleRetenue=formuleGastro
            //};

            ////On crée une instance de XmlSerializer
            //XmlSerializer serializer = new XmlSerializer(typeof(Reservation));


            //using (TextWriter writer = new StreamWriter("test.xml"))
            //{
            //    serializer.Serialize(writer, resa1);
            //}


            restau.tables.Add(table1);
            restau.formules.Add(formuleConso);
            restau.formules.Add(formuleRapide);
            restau.formules.Add(formuleNormale);
            restau.formules.Add(formuleGastro);
            restau.reservations.Add(resa1);

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
                        Console.WriteLine(dateBezard);
                        restau.SerialisationListFormules(restau.formules);
                        C.SerialisationListCuisiniers(C.brigade);
                        restau.SerialisationListReservations(restau.reservations);
                        restau.SerialisationListTables(restau.tables);
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
                        Console.WriteLine("Entrez l'heure de la reservation");
                        
                        Console.WriteLine("Entrez le nombre de personne souhaitant manger dans le restaurant.");
                        nbConvive = int.Parse(Console.ReadLine());
                        Console.WriteLine("Entrez le numéro de la formule retenue: /nVoici la liste de celles ci.");
                        restau.afficheFormule();
                        formuleChoisie=int.Parse(Console.ReadLine());
                        //il faut rechercher la formule par son numéro pour pouvoir appeller verifierResa
                        //restau.verifierResa(dateResa, nbConvive, formuleChoisie);
                        choix = 0;
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Vous souhaitez consulter une réservation. Entrez une date (FORMAT)");
                        Console.WriteLine(resa1);
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
