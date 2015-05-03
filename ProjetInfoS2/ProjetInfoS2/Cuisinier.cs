using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetInfoS2
{
    class Cuisinier
    {
        //Variables d'instance
        private int noCuisinier;
        public int NoCuisinier
        {
            get { return noCuisinier; }
            set { noCuisinier = value; }
        }

        private bool diponible;
        public bool Disponible
        {
            get { return diponible; }
            set { diponible = value; }
        }

        //Constructeur
        public Cuisinier(int _noCuisinier)
        {
            NoCuisinier = _noCuisinier;
            Disponible = true;
        }

        //Méthodes
        public override string ToString()
        {
            string chaine = "Numéro du cuisinier: " + NoCuisinier + "/nDisponibilité: ";
            if (Disponible == true)
            {
                chaine += "oui";
            }
            else
            {
                chaine += "non";
            }
            return chaine + base.ToString();
        }
        
    }//Fin class Cuisinier
}
