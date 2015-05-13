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

        private List<Occupation> planning;// plus utile car le planning est associé aux tables

        public List<Occupation> Planning
        {
            get { return planning; }
            set { planning = value; }
        }
        


        //Constructeur
        public Salle()
        {
            tables = new List<Table>();
            formules = new List<Formule>();
            reservations = new List<Reservation>();
            planning = new List<Occupation>();// à enlever si t'es d'accord
        }


        //Méthodes
        public override string ToString()
        {
            string chaine = "";
            for (int i = 0; i < tables.Count; i++)
            {
                chaine += "Tables : \n" + tables[i];
            }
            for (int i = 0; i < formules.Count; i++)
            {
                chaine += "\n\nFormules : \n" + formules[i];
            }
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
       /* public bool verifierResa(DateTime dateDeDebut, int nbconvive, Formule formuleChoisie, Cuisine C)
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

        }*/

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


        public void validerResa(Table table, DateTime dateResa, int nbconvive, Formule formuleChoisie)
        {
            Console.WriteLine("Quel est le nom pour la réservation?");
            string nomResa=Console.ReadLine();
            Reservation newResa = new Reservation(table, nomResa, dateResa, nbconvive,formuleChoisie);
            reservations.Add(newResa);

            //Serialization de la liste des réservations
            XmlSerializer xsResa = new XmlSerializer(typeof(Reservation));
            StreamWriter wrResa;
            using (wrResa = new StreamWriter(@"..//..//Reservation.xml"))
            {
                xsResa.Serialize(wrResa, newResa);
            }
            wrResa.Close();

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
            //Désérialisation
            //le logiciel lit le fichier xml correspondant au restaurant

            //CE QUE TU AVAIS MIS DANS LE XML
        //<anneeOcc1>2015</anneeOcc1>
        //<moisOcc1>06</moisOcc1>
        //<jourOcc1>12</jourOcc1>
        //<heureOcc1>19</heureOcc1>
        //<minOcc1>30</minOcc1>
        //<anneeOcc2>2015</anneeOcc2>
        //<moisOcc2>06</moisOcc2>
        //<jourOcc2>12</jourOcc2>
        //<heureOcc2>20</heureOcc2>
        //<minOcc2>20</minOcc2>

            XmlDocument doc = new XmlDocument();
            doc.Load("restaurant.xml");
            XmlNodeList tablecarreeNodes = doc.SelectNodes("//Restaurant/Tables/TableCarees");
            XmlNodeList tablerectNodes = doc.SelectNodes("//Restaurant/Tables/TableRectangulaires");
            XmlNodeList tablerondeNodes = doc.SelectNodes("//Restaurant/Tables/TableRondes");
            int nbTableCarree = 0;
            int nbTableRect = 0;
            int nbTableRonde = 0;
            foreach (XmlNode tablecaree in tablecarreeNodes)
            {
                nbTableCarree++;
            }
            foreach (XmlNode tablerect in tablerectNodes)
            {
                nbTableRect++;
            }
            foreach (XmlNode tablerect in tablerondeNodes)
            {
                nbTableRonde++;
            }
            Console.WriteLine(nbTableCarree);
            Console.WriteLine(nbTableRect);
            Console.WriteLine(nbTableRonde);
            Console.ReadLine();
            //Tables Carrées
            XmlNodeList occupationsNodes = doc.SelectNodes("//Restaurant/Tables/TableCaree/occupations");
            List<DateTime> _dateDebutOccupee = new List<DateTime>();
            List<DateTime> _dateFinOccupee = new List<DateTime>();
            //List<int> _anneeOcc1 = new List<int>();
            //List<int> _moisOcc1 = new List<int>();
            //List<int> _jourOcc1 = new List<int>();
            //List<int> _hOcc1 = new List<int>();
            //List<int> _minOcc1 = new List<int>();
            //List<int> _anneeOcc2 = new List<int>();
            //List<int> _moisOcc2 = new List<int>();
            //List<int> _jourOcc2 = new List<int>();
            //List<int> _hOcc2 = new List<int>();
            //List<int> _minOcc2 = new List<int>();
            foreach (XmlNode occNode in occupationsNodes)
            {
                XmlNode dateDebutOccupee = occNode.SelectSingleNode("dateDebutOccupee");
                XmlNode dateFinOccupee = occNode.SelectSingleNode("dateFinOccupee");
                //XmlNode anneeOcc1 = occNode.SelectSingleNode("anneeOcc1");
                //XmlNode moisOcc1 = occNode.SelectSingleNode("moisOcc1");
                //XmlNode jourOcc1 = occNode.SelectSingleNode("jourOcc1");
                //XmlNode hOcc1 = occNode.SelectSingleNode("heureOcc1");
                //XmlNode minOcc1 = occNode.SelectSingleNode("minOcc1");
                //XmlNode anneeOcc2 = occNode.SelectSingleNode("anneeOcc2");
                //XmlNode moisOcc2 = occNode.SelectSingleNode("moisOcc2");
                //XmlNode jourOcc2 = occNode.SelectSingleNode("jourOcc2");
                //XmlNode hOcc2 = occNode.SelectSingleNode("heureOcc2");
                //XmlNode minOcc2 = occNode.SelectSingleNode("minOcc2");

                if (dateDebutOccupee != null)
                {
                
                DateTime datedebut = Convert.ToDateTime(dateDebutOccupee.InnerText);
                Console.WriteLine(datedebut);
                _dateDebutOccupee.Add(datedebut);
                DateTime datefin = Convert.ToDateTime(dateFinOccupee.InnerText);
                Console.WriteLine(datefin);
                _dateFinOccupee.Add(datefin);
                }

            //    if ((anneeOcc1 != null) && (moisOcc1 != null) && (jourOcc1 != null) && (hOcc1 != null) && (minOcc1 != null))
            //    {
            //        int annee1 = int.Parse(anneeOcc1.InnerText);
            //        _anneeOcc1.Add(annee1);
            //        int mois1 = int.Parse(moisOcc1.InnerText);
            //        _moisOcc1.Add(mois1);
            //        int jour1 = int.Parse(jourOcc1.InnerText);
            //        _jourOcc1.Add(jour1);
            //        int heure1 = int.Parse(hOcc1.InnerText);
            //        _hOcc1.Add(heure1);
            //        int min1 = int.Parse(minOcc1.InnerText);
            //        _minOcc1.Add(min1);
            //        int annee2 = int.Parse(anneeOcc2.InnerText);
            //        _anneeOcc2.Add(annee2);
            //        int mois2 = int.Parse(moisOcc2.InnerText);
            //        _moisOcc2.Add(mois2);
            //        int jour2 = int.Parse(jourOcc2.InnerText);
            //        _jourOcc2.Add(jour2);
            //        int heure2 = int.Parse(hOcc2.InnerText);
            //        _hOcc2.Add(heure2);
            //        int min2 = int.Parse(minOcc2.InnerText);
            //        _minOcc2.Add(min2);
            //    }
            }
            
            //CREATION DES TABLES CAREES
            //elles se créent à partir de la lecture du fichier xml, comme ça le logiciel s'adapte à chaque restaurant
            for (int i = 0; i < nbTableCarree; i++)
            {
                TableCarree table = new TableCarree();
                //int a=_anneeOcc1[i];
                //int m=_moisOcc1[i];
                //int j=_jourOcc1[i];
                //int h=_hOcc1[i];
                //int mi=_minOcc1[i];
                //int a2 = _anneeOcc2[i];
                //int m2 = _moisOcc2[i];
                //int j2 = _jourOcc2[i];
                //int h2 = _hOcc2[i];
                //int mi2 = _minOcc2[i];
                if (i < _dateDebutOccupee.Count)
                {
                    DateTime hdebut = new DateTime();
                    hdebut = _dateDebutOccupee[i];
                    DateTime hfin = new DateTime();
                    hfin = _dateFinOccupee[i];
                    Occupation occ = new Occupation(hdebut, hfin);
                    table.ajoutOccupation(occ);
                }

                Console.WriteLine(table);
                this.tables.Add(table);
            }

            //Tables Rectangulaires
            XmlNodeList occupationNodes = doc.SelectNodes("//Restaurant/Tables/TableRectangulaires/TableRectangulaire/occupations");
            foreach (XmlNode occNode in occupationNodes)
            {
                XmlNode dateDebutOccupee = occNode.SelectSingleNode("dateDebutOccupee");
                XmlNode dateFinOccupee = occNode.SelectSingleNode("dateFinOccupee");
                //XmlNode anneeOcc1 = occNode.SelectSingleNode("anneeOcc1");
                //XmlNode moisOcc1 = occNode.SelectSingleNode("moisOcc1");
                //XmlNode jourOcc1 = occNode.SelectSingleNode("jourOcc1");
                //XmlNode hOcc1 = occNode.SelectSingleNode("heureOcc1");
                //XmlNode minOcc1 = occNode.SelectSingleNode("minOcc1");
                //XmlNode anneeOcc2 = occNode.SelectSingleNode("anneeOcc2");
                //XmlNode moisOcc2 = occNode.SelectSingleNode("moisOcc2");
                //XmlNode jourOcc2 = occNode.SelectSingleNode("jourOcc2");
                //XmlNode hOcc2 = occNode.SelectSingleNode("heureOcc2");
                //XmlNode minOcc2 = occNode.SelectSingleNode("minOcc2");
                //if ((anneeOcc1 != null) && (moisOcc1 != null) && (jourOcc1 != null) && (hOcc1 != null) && (minOcc1 != null))
                //{
                //    int annee1 = int.Parse(anneeOcc1.InnerText);
                //    _anneeOcc1.Add(annee1);
                //    int mois1 = int.Parse(moisOcc1.InnerText);
                //    _moisOcc1.Add(mois1);
                //    int jour1 = int.Parse(jourOcc1.InnerText);
                //    _jourOcc1.Add(jour1);
                //    int heure1 = int.Parse(hOcc1.InnerText);
                //    _hOcc1.Add(heure1);
                //    int min1 = int.Parse(minOcc1.InnerText);
                //    _minOcc1.Add(min1);
                //    int annee2 = int.Parse(anneeOcc2.InnerText);
                //    _anneeOcc2.Add(annee2);
                //    int mois2 = int.Parse(moisOcc2.InnerText);
                //    _moisOcc2.Add(mois2);
                //    int jour2 = int.Parse(jourOcc2.InnerText);
                //    _jourOcc2.Add(jour2);
                //    int heure2 = int.Parse(hOcc2.InnerText);
                //    _hOcc2.Add(heure2);
                //    int min2 = int.Parse(minOcc2.InnerText);
                //    _minOcc2.Add(min2);
                //}
                if (dateDebutOccupee != null)
                {

                    DateTime datedebut = Convert.ToDateTime(dateDebutOccupee.InnerText);
                    Console.WriteLine(datedebut);
                    _dateDebutOccupee.Add(datedebut);
                    DateTime datefin = Convert.ToDateTime(dateFinOccupee.InnerText);
                    Console.WriteLine(datefin);
                    _dateFinOccupee.Add(datefin);
                }
            }
            for (int i = 0; i < nbTableRect; i++)
            {
                TableRectangulaire table = new TableRectangulaire();
                //int a = _anneeOcc1[i];
                //int m = _moisOcc1[i];
                //int j = _jourOcc1[i];
                //int h = _hOcc1[i];
                //int mi = _minOcc1[i];
                //int a2 = _anneeOcc2[i];
                //int m2 = _moisOcc2[i];
                //int j2 = _jourOcc2[i];
                //int h2 = _hOcc2[i];
                //int mi2 = _minOcc2[i];
                if (i<_dateDebutOccupee.Count)
                {
                    DateTime hdebut = new DateTime();
                hdebut = _dateDebutOccupee[i];
                DateTime hfin = new DateTime();
                hfin = _dateFinOccupee[i];
                Occupation occ = new Occupation(hdebut, hfin);
                table.ajoutOccupation(occ);
                }
                
                Console.WriteLine(table);
                this.tables.Add(table);
            }

            //Tables Rondes
            XmlNodeList occupNodes = doc.SelectNodes("//Restaurant/Tables/TableRondes/TableRonde/occupations");
            foreach (XmlNode occNode in occupNodes)
            {
                XmlNode dateDebutOccupee = occNode.SelectSingleNode("dateDebutOccupee");
                XmlNode dateFinOccupee = occNode.SelectSingleNode("dateFinOccupee");
                //XmlNode anneeOcc1 = occNode.SelectSingleNode("anneeOcc1");
                //XmlNode moisOcc1 = occNode.SelectSingleNode("moisOcc1");
                //XmlNode jourOcc1 = occNode.SelectSingleNode("jourOcc1");
                //XmlNode hOcc1 = occNode.SelectSingleNode("heureOcc1");
                //XmlNode minOcc1 = occNode.SelectSingleNode("minOcc1");
                //XmlNode anneeOcc2 = occNode.SelectSingleNode("anneeOcc2");
                //XmlNode moisOcc2 = occNode.SelectSingleNode("moisOcc2");
                //XmlNode jourOcc2 = occNode.SelectSingleNode("jourOcc2");
                //XmlNode hOcc2 = occNode.SelectSingleNode("heureOcc2");
                //XmlNode minOcc2 = occNode.SelectSingleNode("minOcc2");
                //if ((anneeOcc1 != null) && (moisOcc1 != null) && (jourOcc1 != null) && (hOcc1 != null) && (minOcc1 != null))
                //{
                //    int annee1 = int.Parse(anneeOcc1.InnerText);
                //    _anneeOcc1.Add(annee1);
                //    int mois1 = int.Parse(moisOcc1.InnerText);
                //    _moisOcc1.Add(mois1);
                //    int jour1 = int.Parse(jourOcc1.InnerText);
                //    _jourOcc1.Add(jour1);
                //    int heure1 = int.Parse(hOcc1.InnerText);
                //    _hOcc1.Add(heure1);
                //    int min1 = int.Parse(minOcc1.InnerText);
                //    _minOcc1.Add(min1);
                //    int annee2 = int.Parse(anneeOcc2.InnerText);
                //    _anneeOcc2.Add(annee2);
                //    int mois2 = int.Parse(moisOcc2.InnerText);
                //    _moisOcc2.Add(mois2);
                //    int jour2 = int.Parse(jourOcc2.InnerText);
                //    _jourOcc2.Add(jour2);
                //    int heure2 = int.Parse(hOcc2.InnerText);
                //    _hOcc2.Add(heure2);
                //    int min2 = int.Parse(minOcc2.InnerText);
                //    _minOcc2.Add(min2);
                //}
                if (dateDebutOccupee != null)
                {

                    DateTime datedebut = Convert.ToDateTime(dateDebutOccupee.InnerText);
                    Console.WriteLine(datedebut);
                    _dateDebutOccupee.Add(datedebut);
                    DateTime datefin = Convert.ToDateTime(dateFinOccupee.InnerText);
                    Console.WriteLine(datefin);
                    _dateFinOccupee.Add(datefin);
                }
            }
            for (int i = 0; i < nbTableRonde; i++)
            {
                TableRonde table = new TableRonde();
                //int a = _anneeOcc1[i];
                //int m = _moisOcc1[i];
                //int j = _jourOcc1[i];
                //int h = _hOcc1[i];
                //int mi = _minOcc1[i];
                //int a2 = _anneeOcc2[i];
                //int m2 = _moisOcc2[i];
                //int j2 = _jourOcc2[i];
                //int h2 = _hOcc2[i];
                //int mi2 = _minOcc2[i];
                if (i < _dateDebutOccupee.Count)
                {
                    DateTime hdebut = new DateTime();
                    hdebut = _dateDebutOccupee[i];
                    DateTime hfin = new DateTime();
                    hfin = _dateFinOccupee[i];
                    Occupation occ = new Occupation(hdebut, hfin);
                    table.ajoutOccupation(occ);
                }

                Console.WriteLine(table);
                this.tables.Add(table); 
            }


            //Il faut peut etre quitter le doc
        }

    }// fin class salle
}
