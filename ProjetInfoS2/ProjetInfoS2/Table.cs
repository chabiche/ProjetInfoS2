using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization; 

namespace ProjetInfoS2
{
    abstract class Table
    {  
        //variables d'instances
        private List<Occupation> planningResa;

        public List<Occupation> PlanningResa
        {
            get { return planningResa; }
            protected set { planningResa = value; }
        }
        
      //  public List<Occupation> planningResa;

        private int nbPlaceMax;

        public int NbPlaceMax
        {
            get { return nbPlaceMax; }
            protected set { nbPlaceMax = value; }
        }
        
       // public int nbPlaceMax { get; set; }
        private bool jumelable;

        public bool Jumelable
        {
            get { return jumelable; }
            protected set { jumelable = value; }
        }
        
        //public bool jumelable { get; set; }

        //Constructeur
        public Table(int _nbPlaceMax, bool _jumelable)
        {
            NbPlaceMax = _nbPlaceMax;
            Jumelable = _jumelable;
            PlanningResa = new List<Occupation>();
        }
        //Constructeur par defaut
        public Table() { }

        //Méthodes
        public override string ToString()
        {
            string chaine = "- Table: \nNombre de places maximum: " + nbPlaceMax +"\nJumelable: ";
            if (jumelable==true)
            {
                chaine += "oui";
            }
            else
	        {
                chaine += "non";
	        }
            for (int i = 0; i < planningResa.Count; i++)
            {
                chaine += "\n" + planningResa[i];
            }
            chaine += "\n";
            return chaine;
        }

        public void newOccupationTableXml(DateTime dateDeDebut, Formule formuleChoisie, int indiceTable)
        {
                DateTime datefincuisto = new DateTime();
                datefincuisto = dateDeDebut + formuleChoisie.DureePreparation;

                //Modification du fichier XML: Ajout de la réservation
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


                if (indiceTable < nbTableCarree)
                {
                    int j = 0;
                    while (j < tablecarreeNodes.Count)
                    {
                        if (j==indiceTable)
                        {
                            XmlNode noeudBase = doc.CreateElement("occupations");
                            XmlNode occupationNode = doc.CreateElement("dateDebutOccupee");
                            tablecarreeNodes[j].AppendChild(noeudBase);

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
                else
                {
                    if(indiceTable<nbTableRect+nbTableCarree)
                    {
                        int j = 0;
                        while (j < tablerectNodes.Count)
                        {
                            if (j == (indiceTable-nbTableCarree))
                            {
                                XmlNode noeudBase = doc.CreateElement("occupations");
                                XmlNode occupationNode = doc.CreateElement("dateDebutOccupee");
                                tablerectNodes[j].AppendChild(noeudBase);

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
                    else
                    {
                        int j = 0;
                        while (j < tablerondeNodes.Count)
                        {
                            if (j == (indiceTable - (nbTableRect+nbTableCarree)))
                            {
                                XmlNode noeudBase = doc.CreateElement("occupations");
                                XmlNode occupationNode = doc.CreateElement("dateDebutOccupee");
                                tablerondeNodes[j].AppendChild(noeudBase);

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
                }
                //XmlNodeList cuistoNodes = doc.SelectNodes("//Restaurant/Tables/Table");
                //XmlNodeList noCuistoNodes = doc.SelectNodes("//Restaurant/Cuisiniers/Cuisinier/noCuisto");
                //string noCuisto = n.ToString();
                
          
        }// fin newOcupationTableXml


        //public virtual void remplirTable(int nbConvives) //il faut refaire la methode avec le planningResa
        //{
        //    if (nbConvives<=this.nbPlaceMax)
        //    {
        //        disponible = false;
        //    }
        //    else
        //    {
        //        Console.WriteLine("La table est trop petite pour accueillir toutes les convives.");
        //    }
        //}

        //public virtual void viderTable()
        //{
        //    disponible = true;
        //}

    }// fin class Table
}
