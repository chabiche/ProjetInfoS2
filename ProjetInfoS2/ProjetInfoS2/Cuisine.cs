using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetInfoS2
{
    class Cuisine
    {
        //Varibles d'instance
        private List<Cuisinier> brigade;
        public List<Cuisinier> Brigade
        {
            get { return brigade; }
            set { brigade = value; }
        }

        private int nbCuistoTotal;
        public int NbCuistoTotal
        {
            get { return nbCuistoTotal; }
            set { nbCuistoTotal = value; }
        }

        private int nbCuistoDispo;
        public int NbCuistoDispo
        {
            get { return nbCuistoDispo; }
            set { nbCuistoDispo = value; }
        }
        
        //Constructeur
        public Cuisine()
        {
            Brigade = new List<Cuisinier>();
            NbCuistoTotal = Brigade.Count;
            NbCuistoDispo = NbCuistoTotal;
        }

        //Méthodes
        public void ajoutCuisto(int noCuisto)
        {
            Cuisinier cuisto = new Cuisinier(noCuisto);
            Brigade.Add(cuisto);
            NbCuistoTotal = Brigade.Count;
            NbCuistoDispo++;
            //Verifie que le cuisto est crée
            Console.WriteLine(cuisto);
            Console.ReadLine();
        }

    }// fin class cuisine
}
