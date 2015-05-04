using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetInfoS2
{
    abstract class Table
    {
        //variables d'instances
        protected int nbPlaceMax;
        public int NbPlaceMax
        {
            get { return nbPlaceMax; }
            set { nbPlaceMax = value; }
        }

        protected int nbPlaceOccupee;
        public int NbPlaceOccupee
        {
            get { return nbPlaceOccupee; }
            set { nbPlaceOccupee = value; }
        }

        protected bool jumelable;
        public bool Jumelable
        {
            get { return jumelable; }
            set { jumelable = value; }
        }
        

        //Constructeur
        public Table(int _nbPlaceMax, int _nbPlaceOccupee, bool _jumelable)
        {
            NbPlaceMax = _nbPlaceMax;
            NbPlaceOccupee = _nbPlaceOccupee;
            Jumelable = _jumelable;
        }
        public Table() { }

        //Méthodes
        public override string ToString()
        {
            string chaine = "Nombre de places maximum: " + NbPlaceMax + "\nNombre de places occupées: " + NbPlaceOccupee+"\nJumelable: ";
            if (Jumelable==true)
            {
                chaine += "oui";
            }
            else
	        {
                chaine += "non";
	        }
            return chaine;
        }

        public virtual void remplirTable(int nbConvives)
        {
            if (nbConvives<=this.NbPlaceMax)
            {
                this.NbPlaceOccupee = nbConvives;
            }
            else
            {
                Console.WriteLine("La table est trop petite pour accueillir tous les convives.");
            }
        }

        public virtual void viderTable()
        {
            this.NbPlaceOccupee = 0;
        }

    }// fin class Table
}
