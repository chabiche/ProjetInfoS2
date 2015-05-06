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

        public bool disponible { get; set; }

        public bool jumelable { get; set; }

        //Constructeur
        public Table(int _nbPlaceMax, bool _disponible, bool _jumelable)
        {
            nbPlaceMax = _nbPlaceMax;
            disponible = _disponible;
            jumelable = _jumelable;
        }
        //Constructeur par defaut
        public Table() { }

        //Méthodes
        public override string ToString()
        {
            string chaine = "Nombre de places maximum: " + nbPlaceMax + "\nTable libre: " + disponible+"\nJumelable: ";
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
                disponible = false;
            }
            else
            {
                Console.WriteLine("La table est trop petite pour accueillir toutes les convives.");
            }
        }

        public virtual void viderTable()
        {
            disponible = true;
        }

    }// fin class Table
}
