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

        //Méthodes
        public virtual void remplirTable(Table table, int nbConvives)
        {
            if (nbConvives<=NbPlaceMax.table)
            {
                NbPlaceOccupee.table = nbConvives;
            }
            else
            {
                Console.WriteLine("La table est trop petite pour accueillir tous les convives.");
            }
        }

    }// fin class Table
}
