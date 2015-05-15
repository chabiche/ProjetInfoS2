using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization; 

namespace ProjetInfoS2
{
    class Cuisinier
    {
        //Variables d'instance
        private List<Occupation> planningCuisto;

        public List<Occupation> PlanningCuisto
        {
            get { return planningCuisto; }
            private set { planningCuisto = value; }
        }
        
        //public List<Occupation> planningCuisto;

        private int noCuisinier;

        public int NoCuisinier
        {
            get { return noCuisinier; }
            private set { noCuisinier = value; }
        }

       // public int noCuisinier { get; set; }

        //Constructeur
        public Cuisinier(int _noCuisinier)
        {
            NoCuisinier = _noCuisinier;
            PlanningCuisto = new List<Occupation>();
        }

        //constructeur par defaut
        public Cuisinier()
        { }

        //Méthodes
        public override string ToString()
        {
            string chaine = "- Cuisinier:\nNuméro du cuisinier: " + noCuisinier;
            for (int i = 0; i < planningCuisto.Count; i++)
            {
                chaine += "\n" + planningCuisto[i];
            }
            chaine += "\n";
            return chaine;
        }

        public void ajoutOccupationCuisto(Occupation occupation)
        {
            planningCuisto.Add(occupation);
        }
        
    }//Fin class Cuisinier
}
