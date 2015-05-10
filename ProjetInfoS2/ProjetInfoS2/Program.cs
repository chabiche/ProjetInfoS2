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
            
            //Désérialisation:
            //le logiciel lit le fichier xml correspondant au restaurant
            XmlDocument doc = new XmlDocument();
            doc.Load("restaurant.xml");
            //partie 1
            XmlNodeList itemNodes = doc.SelectNodes("//Formules/Formule");
            List<string> _nomFormule = new List<string>();
            List<bool> _tableRequise = new List<bool>();
            foreach (XmlNode itemNode in itemNodes)
            {
                XmlNode nomFormule = itemNode.SelectSingleNode("nomFormule");
                XmlNode tableRequise = itemNode.SelectSingleNode("tableRequise");
                if ((nomFormule != null) && (tableRequise != null))
                {
                    _nomFormule.Add(nomFormule.InnerText);
                    bool tablereq = bool.Parse(tableRequise.InnerText);
                    _tableRequise.Add(tablereq);
                }
            }
            //partie 2
            XmlNodeList dureePrepaNodes = doc.SelectNodes("//Formules/Formule/dureePreparation");
            List<int> _hDureePrepa = new List<int>();
            List<int> _minDureePrepa = new List<int>();
            List<int> _secDureePrepa = new List<int>();
            foreach (XmlNode dureeNode in dureePrepaNodes)
            {
                XmlNode hDureePrepa = dureeNode.SelectSingleNode("heure1");
                XmlNode minDureePrepa = dureeNode.SelectSingleNode("min1");
                XmlNode secDureePrepa = dureeNode.SelectSingleNode("sec1");
                if ((hDureePrepa != null) && (minDureePrepa != null) && (secDureePrepa != null))
                {
                    int hdp = int.Parse(hDureePrepa.InnerText);
                    _hDureePrepa.Add(hdp);
                    int mdp = int.Parse(minDureePrepa.InnerText);
                    _hDureePrepa.Add(mdp);
                    int sdp = int.Parse(secDureePrepa.InnerText);
                    _hDureePrepa.Add(sdp);
                }
            }
            XmlNodeList dureePresenceNodes = doc.SelectNodes("//Formules/Formule/dureePresenceClient");
            List<int> _hDureePresence = new List<int>();
            List<int> _minDureePresence = new List<int>();
            List<int> _secDureePresence = new List<int>();
            foreach (XmlNode dureePNode in dureePresenceNodes)
            {
                XmlNode hDureePresence = dureePNode.SelectSingleNode("heure2");
                XmlNode minDureePresence = dureePNode.SelectSingleNode("min2");
                XmlNode secDureePresence = dureePNode.SelectSingleNode("sec2");
                if ((hDureePresence != null) && (minDureePresence != null) && (secDureePresence != null))
                {
                    int hdpc = int.Parse(hDureePresence.InnerText);
                    _hDureePrepa.Add(hdpc);
                    int mdpc = int.Parse(minDureePresence.InnerText);
                    _hDureePrepa.Add(mdpc);
                    int sdpc = int.Parse(secDureePresence.InnerText);
                    _hDureePrepa.Add(sdpc);
                }
            }    
            //Console.ReadKey();

            //CREATION DES FORMULES
            //elles se créent à partir de la lecture du fichier xml, comme ça le logiciel s'adapte à chaque restaurant
            for (int i = 0; i < _nomFormule.Count(); i++)
            {
                TimeSpan dureePreparation = new TimeSpan(_hDureePrepa[i], _minDureePrepa[i], _secDureePrepa[i]);
                TimeSpan dureePresenceClient = new TimeSpan(_hDureePresence[i], _minDureePresence[i], _secDureePresence[i]);
                Formule formule = new Formule(_nomFormule[i], dureePreparation, dureePresenceClient, _tableRequise[i]);
                Console.WriteLine(formule);
                restau.formules.Add(formule);
            }

            //Serialisation Reservation
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("restaurant.xml");
            XmlNodeList resaNodes = xmlDoc.SelectNodes("//Reservations");
            XmlNode rootNode = xmlDoc.CreateElement("Reservation");
            xmlDoc.AppendChild(rootNode);

            XmlNode tableNode = xmlDoc.CreateElement("tableResa");
            tableNode.InnerText = "";
            rootNode.AppendChild(tableNode);
            XmlNode nomClientNode = xmlDoc.CreateElement("nomClient");
            nomClientNode.InnerText = "John Doe";
            rootNode.AppendChild(nomClientNode);
            XmlNode numClientNode = xmlDoc.CreateElement("numClient");
            numClientNode.InnerText = "1";
            rootNode.AppendChild(numClientNode);
            XmlNode dateNode = xmlDoc.CreateElement("dateResa");
            dateNode.InnerText = "11/06/2015 20:00:00";
            rootNode.AppendChild(dateNode);
            XmlNode nbConviveNode = xmlDoc.CreateElement("nbConvive");
            nbConviveNode.InnerText = "4";
            rootNode.AppendChild(nbConviveNode);
            XmlNode formuleNode = xmlDoc.CreateElement("formuleResa");
            formuleNode.InnerText = "Formule Gastronomique";
            rootNode.AppendChild(formuleNode);
            xmlDoc.Save("restaurant.xml");

            //doc.DocumentElement.InnerText: affiche le texte entre> <
            //doc.DocumentElement.Name: affiche le nom de la balise
            //doc.DocumentElement.InnerXml: écrit tout, avec les balises, sauf la première englobante
            //doc.DocumentElement.OuterXml: écrit tout avec les balises, même la première englobante
            //doc.DocumentElement.Attributes["name"].Value: affiche l'attribut
           
            ////FormuleRapide
            //TimeSpan dureePreparationRapide = new TimeSpan(0, 10, 0);
            //TimeSpan dureePresenceClientRapide = new TimeSpan(0, 20, 0);
            //Formule formuleRapide = new Formule("Formule Rapide", dureePreparationRapide, dureePresenceClientRapide, true);
            ////FormuleNormale
            //TimeSpan dureePreparationNormal = new TimeSpan(0, 20, 0);
            //TimeSpan dureePresenceClientNormal = new TimeSpan(0, 50, 0);
            //Formule formuleNormale = new Formule("Formule Normale", dureePreparationNormal, dureePresenceClientNormal, true);
            ////FormuleGastronomique
            //TimeSpan dureePreparationGastro = new TimeSpan(0, 30, 0);
            //TimeSpan dureePresenceClientGastro = new TimeSpan(1, 30, 0);
            //Formule formuleGastro = new Formule("Formule Gastronomique", dureePreparationGastro, dureePresenceClientGastro, true);
            ////FormuleSimpleConso
            //TimeSpan dureePreparationConso = new TimeSpan(0, 5, 0);
            //TimeSpan dureePresenceClientConso = new TimeSpan(0, 20, 0);
            //Formule formuleConso = new Formule("Formule simple consomation", dureePreparationConso, dureePresenceClientConso, true);
            
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
            //serializer.Serialize(writer, formuleConso);

            //IMPORTANT : On ferme le flux en tous temps !!!
            writer.Close();

            

            //CREATION DUNE TABLE
            TableCarree table1 = new TableCarree();


            //CREATION DUNE RESERVATION
            DateTime dateBezard = new DateTime(2015, 5, 12, 19, 30, 0);

            //serialisation réservation
            Reservation resa1 = new Reservation(table1, "Bezard", 1, dateBezard, 4, restau.formules[3]);
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


            //restau.tables.Add(table1);
            //restau.formules.Add(formuleConso);
            //restau.formules.Add(formuleRapide);
            //restau.formules.Add(formuleNormale);
            //restau.formules.Add(formuleGastro);
            //restau.reservations.Add(resa1);

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
