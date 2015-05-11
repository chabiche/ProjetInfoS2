using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization; 

namespace ProjetInfoS2
{
    public class Cuisinier
    {
        public List<Occupation> planningCuisto;

        //Variables d'instance
        public int noCuisinier { get; set; }

        //Constructeur
        public Cuisinier(int _noCuisinier)
        {
            noCuisinier = _noCuisinier;
            planningCuisto = new List<Occupation>();
        }

        //constructeur par defaut
        public Cuisinier()
        { }

        //Méthodes
        public override string ToString()
        {
            string chaine = "Numéro du cuisinier: " + noCuisinier;
            return chaine;
        }
        
    }//Fin class Cuisinier
}
