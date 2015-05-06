using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization; 

namespace ProjetInfoS2
{
    public abstract class Table
    {
        //variables d'instances
        public int nbPlaceMax { get; set; }

        public int nbPlaceOccupee { get; set; }

        public bool jumelable { get; set; }

        //Constructeur
        public Table(int _nbPlaceMax, int _nbPlaceOccupee, bool _jumelable)
        {
            nbPlaceMax = _nbPlaceMax;
            nbPlaceOccupee = _nbPlaceOccupee;
            jumelable = _jumelable;
        }
        public Table() { }

        //Méthodes
        public override string ToString()
        {
            string chaine = "Nombre de places maximum: " + nbPlaceMax + "\nNombre de places occupées: " + nbPlaceOccupee+"\nJumelable: ";
            if (jumelable==true)
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
            if (nbConvives<=this.nbPlaceMax)
            {
                this.nbPlaceOccupee = nbConvives;
            }
            else
            {
                Console.WriteLine("La table est trop petite pour accueillir toutes les convives.");
            }
        }

        public virtual void viderTable()
        {
            this.nbPlaceOccupee = 0;
        }

    }// fin class Table
}
