using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization; 

namespace ProjetInfoS2
{
    class Cuisine
    {
        //Varibles d'instance
        private List<Cuisinier> brigade;

        public List<Cuisinier> Brigade
        {
            get { return brigade; }
            private set { brigade = value; }
        }
        
        //public List<Cuisinier> brigade { get; set; }
        private int nbCuistoTotal;

        public int NbCuistoTotal
        {
            get { return nbCuistoTotal; }
            private set { nbCuistoTotal = value; }
        }
        
        //public int nbCuistoTotal { get; set; }
        //private int nbCuistoDispo;

        //public int NbCuistoDispo
        //{
        //    get { return nbCuistoDispo; }
        //    private set { nbCuistoDispo = value; }
        //}
        
        //public int nbCuistoDispo { get; set; }

        private List<Occupation> planning;// plus besoin non plus car les occupations sont intégré dans les cuisto

        public List<Occupation> Planning
        {
            get { return planning; }
            private set { planning = value; }
        }
        
        //Constructeur
        public Cuisine()
        {
            Brigade = new List<Cuisinier>();
            NbCuistoTotal = brigade.Count;
            //nbCuistoDispo = nbCuistoTotal;
        }


        //Méthodes
        public override string ToString()
        {
            string chaine = "*** Cuisine ***:\nNombre de Cuisiniers Total: "+nbCuistoTotal+"\nBrigade: \n";
            for (int i = 0; i < brigade.Count; i++)
            {
                chaine += "\n"+brigade[i];
            }
            chaine += "\n";
            return chaine;
        }

       /* public void ajoutCuisto(int noCuisto)
        {
            Cuisinier cuisto = new Cuisinier(noCuisto);
            brigade.Add(cuisto);
            nbCuistoTotal = brigade.Count;
            nbCuistoDispo++;
            //Verifie que le cuisto est crée
            Console.WriteLine(cuisto);
            Console.ReadLine();
        }*/

        public bool verifierCuisiniersDispo(int nbConvives, DateTime dateDeDebut, Formule formuleChoisie) //ca marche pas, pas la foi de le faire 
        {
           // On regarde combien de cuisiniers sont disponibles
            DateTime dateDeFin = dateDeDebut + formuleChoisie.DureePreparation;
            int nbDispo = 0;
            List<int> cuistoDispo= new List<int>();
            for (int i = 0; i < brigade.Count; i++) //on regarde les cuisiniers un par un
            {
                if (brigade[i].PlanningCuisto.Count==0)
                {
                    nbDispo++;
                    cuistoDispo.Add(i);
                }
                else
                {
                    int k = 0;
                    while (k < brigade[i].PlanningCuisto.Count)//on regarde toutes les heures où les cuisiniers peuvent être occupés
                    {
                        int comparaisonDebut = DateTime.Compare(dateDeDebut, brigade[i].PlanningCuisto[k].DateDebutOccupee);
                        int comparaisonFin = DateTime.Compare(dateDeFin, brigade[i].PlanningCuisto[k].DateFinOccupee);
                        if ((comparaisonDebut < 0 && comparaisonFin < 0) || (comparaisonDebut > 0 && comparaisonFin > 0))//la date n'est pas la même
                        {
                            nbDispo++;
                            cuistoDispo.Add(i);
                        }
                        else
                        {
                            if ((comparaisonDebut < 0 && comparaisonFin > 0) || (comparaisonDebut > 0 && comparaisonFin < 0))
                            {
                                nbDispo++;
                                cuistoDispo.Add(i);

                            }

                        }
                        k++;
                    }
                }    
            }

            if (nbConvives>nbDispo)
            {
                Console.WriteLine("La cuisine est occupée, la reservation n'est pas possible. Veuillez essayer à un autre horaire");
                return false;
            }
            else
            {
                Console.WriteLine("Il y a assez de cuisiniers disponibles pour effectuer la réservation");
                //Création de l'occupation du cuisinier attribué à la réservation
                for (int n = 0; n < cuistoDispo.Count; n++)
			{
			    DateTime datefincuisto = new DateTime();
                datefincuisto = dateDeDebut + formuleChoisie.DureePreparation;
                Occupation occCuisto = new Occupation(dateDeDebut, datefincuisto);
                this.Brigade[n].PlanningCuisto.Add(occCuisto);

                //Modification du fichier XML: Ajout de la réservation
                XmlDocument doc = new XmlDocument();
                doc.Load("restaurant.xml");
                XmlNodeList cuistoNodes = doc.SelectNodes("//Restaurant/Cuisiniers/Cuisinier");
                XmlNodeList noCuistoNodes = doc.SelectNodes("//Restaurant/Cuisiniers/Cuisinier/noCuisto");
                string noCuisto= n.ToString();
                int j = 0;
                while (j<noCuistoNodes.Count)
                {
                    if (noCuistoNodes[j].InnerText == noCuisto)
                    {
                        XmlNode noeudBase = doc.CreateElement("occupations");
                        XmlNode occupationNode = doc.CreateElement("dateDebutOccupee");
                        cuistoNodes[j].AppendChild(noeudBase);

                        string dateDebut = dateDeDebut.ToString();
                        occupationNode.InnerText = dateDebut;
                        noeudBase.AppendChild(occupationNode);
                        

                        XmlNode occupation2Node = doc.CreateElement("dateFinOccupee");
                        string dateFin = datefincuisto.ToString();
                        occupation2Node.InnerText = dateFin;
                        noeudBase.AppendChild(occupation2Node);

                        doc.Save("restaurant.xml");
                    }
                    j++;
                }
               

			}


               



                return true;
            }

            
        }

        public void lecureXMLCuisto()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("restaurant.xml");
           
            //Cuisiniers
            XmlNodeList itemNodes = doc.SelectNodes("//Restaurant/Cuisiniers/Cuisinier");
            List<int> _noCuisto = new List<int>();
            foreach (XmlNode itemNode in itemNodes)
            {
                XmlNode noCuisto = itemNode.SelectSingleNode("noCuisto");
                if ((noCuisto != null))
                {
                    int nc = int.Parse(noCuisto.InnerText);
                    _noCuisto.Add(nc);
                }
            }
            XmlNodeList occupationsNodes = doc.SelectNodes("//Restaurant/Cuisiniers/Cuisinier/occupations");
            List<DateTime> _dateDebutOccupee = new List<DateTime>();
            List<DateTime> _dateFinOccupee = new List<DateTime>();
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

            //CREATION DES CUISINIERS
            for (int i = 0; i < _noCuisto.Count(); i++)
            {
                Cuisinier cuisto = new Cuisinier(_noCuisto[i]);
                if (i<_dateDebutOccupee.Count)
                {
                     DateTime hdebut = new DateTime();
                    hdebut = _dateDebutOccupee[i];
                    DateTime hfin = new DateTime();
                    hfin = _dateFinOccupee[i];
                    Occupation occ = new Occupation(hdebut, hfin);
                    cuisto.PlanningCuisto.Add(occ);
                }
                this.brigade.Add(cuisto);
            }
        }



    }// fin class cuisine
}
