using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization; 

namespace ProjetInfoS2
{
    public class Salle
    {
        public List<Table> tables{ get; set; }

        public List<Formule> formules { get; set; }

        public List<Reservation> reservations { get; set; }

        private List<Occupation> planning;

        public List<Occupation> Planning
        {
            get { return planning; }
            set { planning = value; }
        }
        
        Cuisine C = new Cuisine();


        //Constructeur
        public Salle()
        {
            tables = new List<Table>();
            formules = new List<Formule>();
            reservations = new List<Reservation>();
            
        }


        //Méthodes
        public override string ToString()
        {
            string chaine = "";
            return chaine;
        }

        public void afficheFormule() //il faudrait rajouter nom de la formule dans les attributs
        {
            for (int i = 0; i < formules.Count; i++)
            {
                Console.WriteLine("n°"+(i+1) + " "+ formules[i].nomFormule);
            }
        
        }

        public Formule retourneFormule(int noFormule)
        {
            Formule form=new Formule();
            int i = 0;
            while ((i + 1)!= noFormule)
            {
               form=formules[i+1];

                i++;
            }
            return form;
        
        }


         public void afficheResaDate()
         {
             Console.WriteLine("Veuillez saisir la date pour laquelle vous souhaitez consulter les réservations");
             Console.WriteLine("Le jour:");
             int day = int.Parse(Console.ReadLine());
             Console.WriteLine("Le mois:");
             int month = int.Parse(Console.ReadLine());
             Console.WriteLine("L'année:");
             int year = int.Parse(Console.ReadLine());
             Console.WriteLine("L'heure:");
             int hour = int.Parse(Console.ReadLine());
             Console.WriteLine("Les minutes:");
             int min = int.Parse(Console.ReadLine());
             DateTime date = new DateTime(year, month, day, hour, min, 0);
             Console.WriteLine(date);
             int i = 0;
             while (i<reservations.Count())
             {
                 if (reservations[i].dateReservation==date)
                 {
                     Console.WriteLine("Réservation n° {0}:",i+1);
                     Console.WriteLine(reservations[i]);
                 }
                 i++;
             }
         }//fin afficheResaDate


        //voir si la reservation est possible
        public bool verifierResa(DateTime dateDeDebut, int nbconvive, Formule formuleChoisie)
        {
            DateTime dateDeFin = dateDeDebut + formuleChoisie.dureePreparation;
            //pour l'instant on regarde si il y a une table dispo pour cette horraire
            int i = 0;
            while (i<tables.Count)
            {
                    if (tables[i].nbPlaceMax > nbconvive)
                    {
                        int k = 0;
                        while (k < planning.Count)
                        {
                            //l'heure de la résa n'est pas comprise dans le temps pendant lequel la table est occupée
                            if (tables[i].planningResa[k].DateDebutOccupee > dateDeDebut && tables[i].planningResa[k].DateFinOccupee < dateDeDebut)
                            {
                                if (tables[i].planningResa[k].DateDebutOccupee > dateDeFin && tables[i].planningResa[k].DateFinOccupee < dateDeFin)
                                {
                                    bool cuisiniersDispo;
                                    Console.WriteLine("Reservation possible sur la table " + i);
                                    cuisiniersDispo = C.verifierCuisiniersDispo(nbconvive, dateDeDebut, formuleChoisie);
                                    if (cuisiniersDispo == true)
                                    {
                                        validerResa(tables[i], dateDeDebut, nbconvive, formuleChoisie);
                                        return true;
                                    }
                                }
                            }
                        k++;
                        }
                    
                   }

                i++;
            }

            Console.WriteLine("La reservation n'est pas possible. Recommencez en tapant sur ENTREE.");
            Console.ReadLine();
            return false;

        }

        ////jumelage

//            i = 0;
//            while (i<tables.Count)  // cad qu'il n'y a pas de table dispo avec assez de place --> on regarde le jumelage
//            {
//                            int j = i + 1;
//                            while (j < tables.Count)
//                            {
//                                int k = 0;
//                                while (k<planning.Count)
//                                {
//                                    if (tables[j].planningResa[k].DateDebutOccupee > dateEtHeure && tables[j].planningResa[k].DateFinOccupee < dateEtHeure)
//                                    {
//                                        if (tables[i].jumelable == true && tables[j].jumelable == true)
//                                        {
//                                            Console.WriteLine(@"Il est possible d'effectuer un jumelable de table 
//afin de pouvoir placer tous les convives
//Possibilité d'association de la table: " + tables[i] + " et " + tables[j]
//            + ". Voulez vous associer ces deux tables? (oui/non)");
//                                            string reponse = Console.ReadLine();
//                                            if (reponse == "oui")
//                                            {
//                                                //jumelage de tables
//                                                TablesJumelees jumelage = new TablesJumelees(tables[i], tables[j]);
//                                                ValiderResa(jumelage, dateEtHeure, nbconvive, formuleChoisie);
//                                                return true;

//                                            }
//                                            else
//                                            {
//                                                Console.WriteLine("Les deux tables n'ont pas été assemblées");
//                                                Console.WriteLine("La reservation n'est pas possible. Recommencez en tapant sur ENTREE.");
//                                                Console.ReadLine();
//                                                return false;


//                                            }
//                                        }
//                                    }
//                                    k++;
//                                }
                                    
//                                j++;
//                            }

                            
//                         i++;

//                    }


        public void validerResa(Table table, DateTime dateEtHeure, int nbconvive, Formule formuleChoisie)
        {
            Console.WriteLine("Quel est le nom pour la réservation?");
            string nomResa=Console.ReadLine();
            //Il faut lui attribuer un numero de client pour pouvoir creer la résa
            //création et sérialisation de la résa Reservation newResa= new Reservation(......)
            //restau.reservations.Add(resa);

        }

        public void creationOccupationsXml()
        {
            //Désérialisation:
            //le logiciel lit le fichier xml correspondant au restaurant

            XmlDocument doc = new XmlDocument();
            doc.Load("restaurant.xml");
            //partie 1
            XmlNodeList itemNodes = doc.SelectNodes("//Restaurant/Occupations/Occupation");
            List<int> _noOccupation = new List<int>();
            //List<bool> _tableRequise = new List<bool>();
            foreach (XmlNode itemNode in itemNodes)
            {
                XmlNode noOccupation = itemNode.SelectSingleNode("noOccupation");
               // XmlNode tableRequise = itemNode.SelectSingleNode("tableRequise");
                if ((noOccupation != null))
                {
                    int noocc = int.Parse(noOccupation.InnerText);
                    _noOccupation.Add(noocc);
                  //  bool tablereq = bool.Parse(tableRequise.InnerText);
                  //  _tableRequise.Add(tablereq);
                }
            }
            ////partie 2
            //XmlNodeList dureePrepaNodes = doc.SelectNodes("//Restaurant/Formules/Formule/dureePreparation");
            //List<int> _hDureePrepa = new List<int>();
            //List<int> _minDureePrepa = new List<int>();
            //List<int> _secDureePrepa = new List<int>();
            //foreach (XmlNode dureeNode in dureePrepaNodes)
            //{
            //    XmlNode hDureePrepa = dureeNode.SelectSingleNode("heure1");
            //    XmlNode minDureePrepa = dureeNode.SelectSingleNode("min1");
            //    XmlNode secDureePrepa = dureeNode.SelectSingleNode("sec1");
            //    if ((hDureePrepa != null) && (minDureePrepa != null) && (secDureePrepa != null))
            //    {
            //        int hdp = int.Parse(hDureePrepa.InnerText);
            //        _hDureePrepa.Add(hdp);
            //        int mdp = int.Parse(minDureePrepa.InnerText);
            //        _minDureePrepa.Add(mdp);
            //        int sdp = int.Parse(secDureePrepa.InnerText);
            //        _secDureePrepa.Add(sdp);
            //    }
            //}
            //XmlNodeList dureePresenceNodes = doc.SelectNodes("//Restaurant/Formules/Formule/dureePresenceClient");
            //List<int> _hDureePresence = new List<int>();
            //List<int> _minDureePresence = new List<int>();
            //List<int> _secDureePresence = new List<int>();
            //foreach (XmlNode dureePNode in dureePresenceNodes)
            //{
            //    XmlNode hDureePresence = dureePNode.SelectSingleNode("heure2");
            //    XmlNode minDureePresence = dureePNode.SelectSingleNode("min2");
            //    XmlNode secDureePresence = dureePNode.SelectSingleNode("sec2");
            //    if ((hDureePresence != null) && (minDureePresence != null) && (secDureePresence != null))
            //    {
            //        int hdpc = int.Parse(hDureePresence.InnerText);
            //        _hDureePresence.Add(hdpc);
            //        int mdpc = int.Parse(minDureePresence.InnerText);
            //        _minDureePresence.Add(mdpc);
            //        int sdpc = int.Parse(secDureePresence.InnerText);
            //        _secDureePresence.Add(sdpc);
            //    }
            //}

            ////CREATION DES FORMULES
            ////elles se créent à partir de la lecture du fichier xml, comme ça le logiciel s'adapte à chaque restaurant
            //for (int i = 0; i < _nomFormule.Count(); i++)
            //{
            //    TimeSpan dureePreparation = new TimeSpan(_hDureePrepa[i], _minDureePrepa[i], _secDureePrepa[i]);
            //    TimeSpan dureePresenceClient = new TimeSpan(_hDureePresence[i], _minDureePresence[i], _secDureePresence[i]);
            //    Formule formule = new Formule(_nomFormule[i], dureePreparation, dureePresenceClient, _tableRequise[i]);
            //    Console.WriteLine(formule);
            //    this.formules.Add(formule);
            //}

            ////Il faut peut etre quitter le doc
        }

        public void creationFormulesXml()
        {
              //Désérialisation:
            //le logiciel lit le fichier xml correspondant au restaurant

           XmlDocument doc = new XmlDocument();
            doc.Load("restaurant.xml");
            //partie 1
            XmlNodeList itemNodes = doc.SelectNodes("//Restaurant/Formules/Formule");
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
            XmlNodeList dureePrepaNodes = doc.SelectNodes("//Restaurant/Formules/Formule/dureePreparation");
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
                    _minDureePrepa.Add(mdp);
                    int sdp = int.Parse(secDureePrepa.InnerText);
                    _secDureePrepa.Add(sdp);
                }
            }
            XmlNodeList dureePresenceNodes = doc.SelectNodes("//Restaurant/Formules/Formule/dureePresenceClient");
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
                    _hDureePresence.Add(hdpc);
                    int mdpc = int.Parse(minDureePresence.InnerText);
                    _minDureePresence.Add(mdpc);
                    int sdpc = int.Parse(secDureePresence.InnerText);
                    _secDureePresence.Add(sdpc);
                }
            }    

            //CREATION DES FORMULES
            //elles se créent à partir de la lecture du fichier xml, comme ça le logiciel s'adapte à chaque restaurant
            for (int i = 0; i < _nomFormule.Count(); i++)
            {
                TimeSpan dureePreparation = new TimeSpan(_hDureePrepa[i], _minDureePrepa[i], _secDureePrepa[i]);
                TimeSpan dureePresenceClient = new TimeSpan(_hDureePresence[i], _minDureePresence[i], _secDureePresence[i]);
                Formule formule = new Formule(_nomFormule[i], dureePreparation, dureePresenceClient, _tableRequise[i]);
                Console.WriteLine(formule);
                this.formules.Add(formule);
            }

            //Il faut peut etre quitter le doc
        }

        public void creationTablesXml()
        {
            //Désérialisat
            //le logiciel lit le fichier xml correspondant au restaurant

            XmlDocument doc = new XmlDocument();
            doc.Load("restaurant.xml");
            //partie 1
            XmlNodeList itemNodes = doc.SelectNodes("//Restaurant/Tables/TableCarre");
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
            XmlNodeList dureePrepaNodes = doc.SelectNodes("//Restaurant/Formules/Formule/dureePreparation");
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
                    _minDureePrepa.Add(mdp);
                    int sdp = int.Parse(secDureePrepa.InnerText);
                    _secDureePrepa.Add(sdp);
                }
            }
            XmlNodeList dureePresenceNodes = doc.SelectNodes("//Restaurant/Formules/Formule/dureePresenceClient");
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
                    _hDureePresence.Add(hdpc);
                    int mdpc = int.Parse(minDureePresence.InnerText);
                    _minDureePresence.Add(mdpc);
                    int sdpc = int.Parse(secDureePresence.InnerText);
                    _secDureePresence.Add(sdpc);
                }
            }

            //CREATION DES FORMULES
            //elles se créent à partir de la lecture du fichier xml, comme ça le logiciel s'adapte à chaque restaurant
            for (int i = 0; i < _nomFormule.Count(); i++)
            {
                TimeSpan dureePreparation = new TimeSpan(_hDureePrepa[i], _minDureePrepa[i], _secDureePrepa[i]);
                TimeSpan dureePresenceClient = new TimeSpan(_hDureePresence[i], _minDureePresence[i], _secDureePresence[i]);
                Formule formule = new Formule(_nomFormule[i], dureePreparation, dureePresenceClient, _tableRequise[i]);
                Console.WriteLine(formule);
                this.formules.Add(formule);
            }

            //Il faut peut etre quitter le doc
        }

    }// fin class salle
}
