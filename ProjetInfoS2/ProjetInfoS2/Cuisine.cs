﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization; 

namespace ProjetInfoS2
{
    public class Cuisine
    {
        //Varibles d'instance

        public List<Cuisinier> brigade { get; set; }

        public int nbCuistoTotal { get; set; }

        public int nbCuistoDispo { get; set; }

        private List<Occupation> planning;// plus besoin non plus car les occupations sont intégré dans les cuisto

        public List<Occupation> Planning
        {
            get { return planning; }
            set { planning = value; }
        }
        
        //Constructeur
        public Cuisine()
        {
            brigade = new List<Cuisinier>();
            nbCuistoTotal = brigade.Count;
            nbCuistoDispo = nbCuistoTotal;
        }


        //Méthodes
        public override string ToString()
        {
            string chaine = "Nombre de Cuisiniers Total: "+nbCuistoTotal+"\nNombre de cuisiniers disponibles: "+nbCuistoDispo+"\nBrigade: \n";
            for (int i = 0; i < brigade.Count; i++)
            {
                chaine += "\n"+brigade[i];
            }
            return chaine;
        }

        public void ajoutCuisto(int noCuisto)
        {
            Cuisinier cuisto = new Cuisinier(noCuisto);
            brigade.Add(cuisto);
            nbCuistoTotal = brigade.Count;
            nbCuistoDispo++;
            //Verifie que le cuisto est crée
            Console.WriteLine(cuisto);
            Console.ReadLine();
        }

        public bool verifierCuisiniersDispo(int nbConvives, DateTime dateDeDebut, Formule formuleChoisie) //ca marche pas, pas la foi de le faire 
        {
           // On regarde combien de cuisiniers sont disponibles
            DateTime dateDeFin = dateDeDebut + formuleChoisie.dureePreparation;
            int nbDispo = 0;
            for (int i = 0; i < brigade.Count; i++) //on regarde les cuisiniers un par un
            {
                if (brigade[i].planningCuisto.Count==0)
                {
                    nbDispo++;
                }
                else
                {
                    int k = 0;
                    while (k < brigade[i].planningCuisto.Count)//on regarde toutes les heures où les cuisiniers peuvent être occupés
                    {
                        int comparaisonDebut = DateTime.Compare(dateDeDebut, brigade[i].planningCuisto[k].DateDebutOccupee);
                        int comparaisonFin = DateTime.Compare(dateDeFin, brigade[i].planningCuisto[k].DateFinOccupee);
                        if ((comparaisonDebut < 0 && comparaisonFin < 0) || (comparaisonDebut > 0 && comparaisonFin > 0))//la date n'est pas la même
                        {
                            nbDispo++;
                        }
                        else
                        {
                            if ((comparaisonDebut < 0 && comparaisonFin > 0) || (comparaisonDebut > 0 && comparaisonFin < 0))
                            {
                                nbDispo++;

                            }

                        }
                        k++;
                    }
                }
                
                
            }

            if (nbConvives>nbDispo)
            {
                Console.WriteLine("La cuisine est occupée, la reservation n'est pas possible. Veuillez essayer à une autre horaire");
                return false;
            }
            else
            {
                Console.WriteLine("Il y a assez de cuisiniers disponibles");
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
                    cuisto.planningCuisto.Add(occ);
                }
                this.brigade.Add(cuisto);
            }
        }



    }// fin class cuisine
}
