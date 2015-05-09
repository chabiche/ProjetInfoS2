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
        //Variables d'instance
        public int noCuisinier { get; set; }

        public bool disponible { get; set; }


        //Constructeur
        public Cuisinier(int _noCuisinier)
        {
            noCuisinier = _noCuisinier;
            disponible = true;
        }

        //constructeur par defaut
        public Cuisinier()
        { }

        //Méthodes
        public override string ToString()
        {
            string chaine = "Numéro du cuisinier: " + noCuisinier + "\nDisponible: ";
            if (disponible == true)
            {
                chaine += "oui";
            }
            else
            {
                chaine += "non";
            }
            return chaine;
        }
        
    }//Fin class Cuisinier
}
