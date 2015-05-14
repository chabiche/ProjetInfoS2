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
            string chaine = "*********\n* SALLE *\n*********";
            for (int i = 0; i < tables.Count; i++)
            {
                chaine += "*** Tables ***\n" + tables[i];
            }
            for (int i = 0; i < formules.Count; i++)
            {
                chaine += "\n\n*** Formules ***\n" + formules[i];
            }
            return chaine;
        }

        public void affichePlanningResa()
        {
            for (int i = 0; i < reservations.Count; i++)
            {
                Console.WriteLine(reservations[i]);
            }
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
            while (i<formules.Count)
            {
                if (noFormule==i+1)
                {
                    form = formules[i];
                }
                i++;
            }
            return form;
        
        }


         public void afficheResaDate()
         {
             
             Console.WriteLine("Vous souhaitez consulter une réservation. Entrez la date sous le format AAAA/MM/JJ:");
             DateTime dateConsult = DateTime.Parse(Console.ReadLine());
             int annee = dateConsult.Year;
             int mois = dateConsult.Month;
             int day = dateConsult.Day;

             Console.WriteLine("Voici les réservations correspondantes:\n");

             int i = 0;
             bool trouve = false;
             //parcout toutes les réservations de la salle
             while (i<reservations.Count())
             {
                 int anneeR = reservations[i].dateReservation.Year;
                 int moisR = reservations[i].dateReservation.Month;
                 int dayR = reservations[i].dateReservation.Day;
                 if (anneeR==annee && moisR==mois && dayR==day)// cherche quelles réservations correspondent à la date indiquée
                 {
                     Console.WriteLine("Réservation n° {0}:",i+1);
                     Console.WriteLine(reservations[i]);
                     trouve = true;
                 }
                 i++;
             }
             if (trouve == false)
             {
                 Console.WriteLine("Aucune réservations pour cette date-ci\n");
             }
         }//fin afficheResaDate

         public void afficheResaDateHeure()
         {
             Console.WriteLine("Vous souhaitez consulter une réservation. Entrez la date sous le format AAAA/MM/JJ:");
             DateTime dateConsult = DateTime.Parse(Console.ReadLine());
             Console.WriteLine("Entrez l'heure sous le format hh:mm:");
             TimeSpan heureConsult = TimeSpan.Parse(Console.ReadLine());
             dateConsult = dateConsult + heureConsult;

             int i = 0;
             bool trouve = false;
             //parcout toutes les réservations de la salle
             while (i < reservations.Count())
             {
                 if (reservations[i].dateReservation == dateConsult)// cherche quelles réservations correspondent à la date indiquée
                 {
                     Console.WriteLine("Réservation n° {0}:", i + 1);
                     Console.WriteLine(reservations[i]);
                     trouve = true;
                 }
                 i++;
             }
             if (trouve==false)
             {
                 Console.WriteLine("Aucune réservations pour ces date et horaire-ci\n");
             }
         }// fin afficheDateHeure


        //voir si la reservation est possible
        public bool verifierResa(DateTime dateDeDebut, int nbconvive, Formule formuleChoisie, Cuisine C)
        {
            DateTime dateDeFin = dateDeDebut + formuleChoisie.dureePresenceClient;
            //pour l'instant on regarde si il y a une table dispo pour cette horaire
            int i = 0;

            int heureDebut = dateDeDebut.Hour;
            int min = dateDeDebut.Minute;
            int mois = dateDeDebut.Month;
            int jour = dateDeDebut.Day;

            while (i < tables.Count)
            {
                    if (tables[i].nbPlaceMax >= nbconvive)
                    {
                        int k = 0;
                        while (k < tables[i].planningResa.Count)
                        {
                            int comparaisonDebut = DateTime.Compare(dateDeDebut, tables[i].planningResa[k].DateDebutOccupee);
                            int comparaisonFin = DateTime.Compare(dateDeFin, tables[i].planningResa[k].DateFinOccupee);

                            //l'heure de la résa n'est pas comprise dans le temps pendant lequel la table est occup
                            if ((comparaisonDebut < 0 && comparaisonFin< 0)||(comparaisonDebut>0 && comparaisonFin>0))//la date n'est pas la même
                            {
                                bool cuisiniersDispo;
                                cuisiniersDispo = C.verifierCuisiniersDispo(nbconvive, dateDeDebut, formuleChoisie);
                                if (cuisiniersDispo == true)
                                {
                                    
                                    validerResa(tables[i], dateDeDebut, nbconvive, formuleChoisie);
                                    return true;
                                }

                            }
                            else
                            {
                                if ((comparaisonDebut < 0 && comparaisonFin> 0)||(comparaisonDebut>0 && comparaisonFin<0))
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
                                else
                                {
                                    Console.WriteLine("La reservation n'est pas possible. Recommencez en tapant sur ENTREE.");
                                    Console.ReadLine();
                                    return false;
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


        public void validerResa(Table table, DateTime dateResa, int nbconvive, Formule formuleChoisie)
        {
            Console.WriteLine("Quel est le nom du client pour la réservation?");
            string nomResa=Console.ReadLine();
            Console.WriteLine("Quel est le numéro du client?");
            string noClient = Console.ReadLine();
            int i=0;
            string noTable="";
            //Recherche du numéro de la table
            while (i<tables.Count)
            {
                if (tables[i]==table)
                {
                    noTable = i.ToString(); 
                }
                i++;
            }
            //Recherche du nom de la formule choisie
            int j = 0;
            string nomFormule = "";
            while (j < formules.Count)
            {
                if (formules[j] == formuleChoisie)
                {
                    nomFormule = formules[j].nomFormule.ToString();
                }
                j++;
            }
            //Création de la réservation dans le programme
            Reservation newResa = new Reservation(table, nomResa, dateResa, nbconvive,formuleChoisie);
            reservations.Add(newResa);

            //Modification du fichier XML: Ajout de la réservation
            XmlDocument doc = new XmlDocument();
            doc.Load("restaurant.xml");
            XmlNode resaNodes = doc.SelectSingleNode("//Restaurant/Reservations");
            XmlNode noeudBase = doc.CreateElement("Reservation");
            XmlNode tableNode = doc.CreateElement("tableResa");
            tableNode.InnerText = noTable;
            noeudBase.AppendChild(tableNode);

            resaNodes.AppendChild(noeudBase);

            XmlNode nomClientNode = doc.CreateElement("nomClient");
            nomClientNode.InnerText = nomResa;
            noeudBase.AppendChild(nomClientNode);
            XmlNode numClientNode = doc.CreateElement("numClient");
            numClientNode.InnerText = noClient;
            noeudBase.AppendChild(numClientNode);
            XmlNode dateNode = doc.CreateElement("dateResa");
            string date = dateResa.ToString();
            dateNode.InnerText = date;
            noeudBase.AppendChild(dateNode);
            XmlNode nbConviveNode = doc.CreateElement("nbConvive");
            nbConviveNode.InnerText = nbconvive.ToString();
            noeudBase.AppendChild(nbConviveNode);
            XmlNode formuleNode = doc.CreateElement("formuleResa");
            formuleNode.InnerText = nomFormule;
            noeudBase.AppendChild(formuleNode);

            doc.Save("restaurant.xml");
        }//fin validerResa

        public void creationFormulesXml()
        {
            //le logiciel lit le fichier xml correspondant au restaurant
           XmlDocument doc = new XmlDocument();
            doc.Load("restaurant.xml");

            //Lecture des informations nomFormule et TableRequise de chaque formule du fichier XML
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

            //Lecture des durées de préparations et de présence clients pour chaque formule du fichier XML
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
                this.formules.Add(formule);
            }
        }// fin creationFormulesXml

        public void creationTablesXml()
        {
            //le logiciel lit le fichier xml correspondant au restaurant
            XmlDocument doc = new XmlDocument();
            doc.Load("restaurant.xml");

            //Comptage du nombre de tables en fonction de chaque type(carrées, rectangulaires et rondes)
            XmlNodeList tablecarreeNodes = doc.SelectNodes("//Restaurant/Tables/TableCarees/TableCaree");
            XmlNodeList tablerectNodes = doc.SelectNodes("//Restaurant/Tables/TableRectangulaires/TableRectangulaire");
            XmlNodeList tablerondeNodes = doc.SelectNodes("//Restaurant/Tables/TableRondes/TableRonde");
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
            foreach (XmlNode tableronde in tablerondeNodes)
            {
                nbTableRonde++;
            }

            //Lecture des informations concernants les Tables Carrées
            XmlNodeList occupationsNodes = doc.SelectNodes("//Restaurant/Tables/TableCarees/TableCaree/occupations/occupation");
            List<DateTime> _dateDebutOccupee = new List<DateTime>();
            List<DateTime> _dateFinOccupee = new List<DateTime>();

            //parcours chaque noeuds "occupation"
            foreach (XmlNode occNode in occupationsNodes) 
            {
                XmlNode dateDebutOccupee = occNode.SelectSingleNode("dateDebutOccupee");
                XmlNode dateFinOccupee = occNode.SelectSingleNode("dateFinOccupee");

                if (dateDebutOccupee != null)
                {
                DateTime datedebut = Convert.ToDateTime(dateDebutOccupee.InnerText);
                _dateDebutOccupee.Add(datedebut);
                DateTime datefin = Convert.ToDateTime(dateFinOccupee.InnerText);
                _dateFinOccupee.Add(datefin);

                }
                

            }
            
            //CREATION DES TABLES CAREES
            //elles se créent à partir de la lecture du fichier xml, comme ça le logiciel s'adapte à chaque restaurant disposant de ces trois types de tables
            for (int i = 0; i < nbTableCarree; i++)
            {
                TableCarree table = new TableCarree();

                if (i < _dateDebutOccupee.Count)
                {
                    DateTime hdebut = new DateTime();
                    hdebut = _dateDebutOccupee[i];
                    DateTime hfin = new DateTime();
                    hfin = _dateFinOccupee[i];
                    Occupation occ = new Occupation(hdebut, hfin);
                    table.planningResa.Add(occ);

                }
                //ajout des tables lues à la liste de tables de la salle
                this.tables.Add(table);
            }


            //Lecture des informations concernants les Tables Rectangulaires
            XmlNodeList occupationNodes = doc.SelectNodes("//Restaurant/Tables/TableRectangulaires/TableRectangulaire/occupations/occupation");
            //parcours chaque noeuds "occupation"
            foreach (XmlNode occNode in occupationNodes)
            {
                XmlNode dateDebutOccupee = occNode.SelectSingleNode("dateDebutOccupee");
                XmlNode dateFinOccupee = occNode.SelectSingleNode("dateFinOccupee");

                if (dateDebutOccupee != null)
                {

                    DateTime datedebut = Convert.ToDateTime(dateDebutOccupee.InnerText);
                    _dateDebutOccupee.Add(datedebut);
                    DateTime datefin = Convert.ToDateTime(dateFinOccupee.InnerText);
                    _dateFinOccupee.Add(datefin);
                }
            }
            for (int i = 0; i < nbTableRect; i++)
            {
                TableRectangulaire table = new TableRectangulaire();

                if (i<_dateDebutOccupee.Count)
                {
                    DateTime hdebut = new DateTime();
                hdebut = _dateDebutOccupee[i];
                DateTime hfin = new DateTime();
                hfin = _dateFinOccupee[i];
                Occupation occ = new Occupation(hdebut, hfin);
                table.planningResa.Add(occ);
                }
                
                //ajout des tables lues à la liste de tables de la salle
                this.tables.Add(table);
            }

            //Lecture des informations concernants les Tables Rondes
            XmlNodeList occupNodes = doc.SelectNodes("//Restaurant/Tables/TableRondes/TableRonde/occupations/occupation");
            //parcours chaque noeuds "occupation"
            foreach (XmlNode occNode in occupNodes)
            {
                XmlNode dateDebutOccupee = occNode.SelectSingleNode("dateDebutOccupee");
                XmlNode dateFinOccupee = occNode.SelectSingleNode("dateFinOccupee");

                if (dateDebutOccupee != null)
                {

                    DateTime datedebut = Convert.ToDateTime(dateDebutOccupee.InnerText);
                    _dateDebutOccupee.Add(datedebut);
                    DateTime datefin = Convert.ToDateTime(dateFinOccupee.InnerText);
                    _dateFinOccupee.Add(datefin);
                }
            }
            for (int i = 0; i < nbTableRonde; i++)
            {
                TableRonde table = new TableRonde();

                if (i < _dateDebutOccupee.Count)
                {
                    DateTime hdebut = new DateTime();
                    hdebut = _dateDebutOccupee[i];
                    DateTime hfin = new DateTime();
                    hfin = _dateFinOccupee[i];
                    Occupation occ = new Occupation(hdebut, hfin);
                    table.planningResa.Add(occ);
                }
                //ajout des tables lues à la liste de tables de la salle
                this.tables.Add(table); 
            }
        }// fin creationTablesXml

        public void creationReservationXml()
        {
            //chargement du document
            XmlDocument doc = new XmlDocument();
            doc.Load("restaurant.xml");
            
            //recherche du noeud "reservation"
            XmlNodeList itemNodes = doc.SelectNodes("//Restaurant/Reservations/Reservation");
            List<int> _noTable = new List<int>();
            List<string> _nomClient = new List<string>();
            List<int> _nbConvive = new List<int>();
            List<string> _nomFormule = new List<string>();
            List<DateTime> _dateResa = new List<DateTime>();
            //parcourt tous les noeuds "reservation" du document
            foreach (XmlNode itemNode in itemNodes)
            {
                XmlNode noTable = itemNode.SelectSingleNode("tableResa");
                XmlNode nomClient = itemNode.SelectSingleNode("nomClient");
                XmlNode dateResa = itemNode.SelectSingleNode("dateResa");
                XmlNode nbConvive = itemNode.SelectSingleNode("nbConvive");
                XmlNode nomFormule = itemNode.SelectSingleNode("formuleResa");

                if (nomClient != null)
                {

                    _nomFormule.Add(nomFormule.InnerText);
                    _nomClient.Add(nomClient.InnerText);
                    int notable = int.Parse(noTable.InnerText);
                    _noTable.Add(notable);
                    int nbconvive = int.Parse(nbConvive.InnerText);
                    _nbConvive.Add(nbconvive);
                    DateTime dateresa = Convert.ToDateTime(dateResa.InnerText);
                    _dateResa.Add(dateresa);

                }
            }
        
            //CREATION RESERVATIONS DANS LE PROGRAMME
            for (int i = 0; i < _nomClient.Count(); i++)
            {

                Reservation newResa = new Reservation() ;
                Formule formuleChoisie=new Formule();
                int j=0;
                while (j<formules.Count)
			        {
                        for (int k = 0; k < formules.Count; k++)
			            {
			                if (_nomFormule[i].Equals(formules[k].nomFormule))
	                        {
		                        formuleChoisie=formules[k];
	                        }
			            }
                        j++;
                    }

                j = 0;
                while (j < tables.Count)
			        { 
  
			            if (j==_noTable[i])
	                     {
                            if (tables[j].nbPlaceMax==4)
	                            {
		                            TableCarree tableResa = new TableCarree();
                                    tableResa=tables[j] as TableCarree;
                                    newResa = new Reservation(tableResa, _nomClient[i], _dateResa[i], _nbConvive[i], formuleChoisie);
                                    
	                            }
                            else
                            {
                                if (tables[j].nbPlaceMax == 6)
                                {
                                    TableRectangulaire tableResa = new TableRectangulaire();
                                    tableResa = tables[j] as TableRectangulaire;
                                    newResa = new Reservation(tableResa, _nomClient[i], _dateResa[i], _nbConvive[i], formuleChoisie);

                                }
                                else
                                {
                                    TableRonde tableResa = new TableRonde();
                                    tableResa = tables[j] as TableRonde;
                                    newResa = new Reservation(tableResa, _nomClient[i], _dateResa[i], _nbConvive[i], formuleChoisie);

                                }
                            
                            }
                        
	                     }
                j++;
			        }
	          
                this.reservations.Add(newResa);
            }
        
        
        
        }//fin creationReservationXML

    }// fin class salle
}
