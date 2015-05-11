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

        public bool VerifierCuisineDispo(int nbConvives)
        {
            //On regarde combien de cuisiniers sont disponibles
            int nbDispo = 0;
            //for (int i = 0; i < brigade.Count; i++)
            //{
            //    if (brigade[i].disponible==true)
            //    {
            //        nbDispo++;
            //    }
            //}

            if (nbConvives>nbDispo)
            {
                Console.WriteLine("La cuisine est occupée, la reservation n'est pas possible. Veuillez essayer à une autre horaire");
                //Ca serait trop cool de proposer un autre horraire pour que la reservation puisse être possible
            }


            return true;
        }





    }// fin class cuisine
}
