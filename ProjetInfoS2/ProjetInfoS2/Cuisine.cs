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

        public bool VerifierCuisineDispo(int nbConvives, DateTime dateEtHeure) //ca marche pas, pas la foi de le faire 
        {
            //On regarde combien de cuisiniers sont disponibles
            //int nbDispo = 0;
            //for (int i = 0; i < brigade.Count; i++)
            //{
            //    int k = 0;
            //    while (k<planning.Count)
            //    {
            //        if (brigade[i].planningCuisto[k].DateDebutOccupee < dateEtHeure && brigade[i].planningCuisto[k].DateFinOccupee > dateEtHeure)
            //        {
            //            nbDispo++;
            //        }
            //    }
                
            //}

            //if (nbConvives>nbDispo)
            //{
            //    Console.WriteLine("La cuisine est occupée, la reservation n'est pas possible. Veuillez essayer à une autre horaire");
            //    //Ca serait trop cool de proposer un autre horraire pour que la reservation puisse être possible
            //}


            return true;
        }





    }// fin class cuisine
}
