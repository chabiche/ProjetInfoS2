using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization; 

namespace ProjetInfoS2
{
    class Cuisine
    {
        //Varibles d'instance

        public List<Cuisinier> brigade { get; set; }

        public int nbCuistoTotal { get; set; }

        public int nbCuistoDispo { get; set; }

        private List<Occupation> planning;

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
                int k = 0;
                while (k<planning.Count)//on regarde toutes les heures où les cuisiniers peuvent être occupés
                {
                    if (brigade[i].planningCuisto[k].DateDebutOccupee < dateDeDebut && brigade[i].planningCuisto[k].DateFinOccupee > dateDeDebut)
                        if (brigade[i].planningCuisto[k].DateDebutOccupee > dateDeFin && brigade[i].planningCuisto[k].DateFinOccupee < dateDeFin)
                        {
                            {
                                nbDispo++;

                            }
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





    }// fin class cuisine
}
