using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization; 

namespace ProjetInfoS2
{
    public abstract class Table
    {
        public List<Occupation> planningResa;

        //variables d'instances
        public int nbPlaceMax { get; set; }

        public bool jumelable { get; set; }

        //Constructeur
        public Table(int _nbPlaceMax, bool _jumelable)
        {
            nbPlaceMax = _nbPlaceMax;
            jumelable = _jumelable;
            planningResa = new List<Occupation>();
        }
        //Constructeur par defaut
        public Table() { }

        //Méthodes
        public override string ToString()
        {
            string chaine = "Nombre de places maximum: " + nbPlaceMax +"\nJumelable: ";
            if (jumelable==true)
            {
                chaine += "oui";
            }
            else
	        {
                chaine += "non";
	        }
            for (int i = 0; i < planningResa.Count; i++)
            {
                chaine += "\n" + planningResa[i];
            }
            return chaine;
        }

        //public virtual void remplirTable(int nbConvives) //il faut refaire la methode avec le planningResa
        //{
        //    if (nbConvives<=this.nbPlaceMax)
        //    {
        //        disponible = false;
        //    }
        //    else
        //    {
        //        Console.WriteLine("La table est trop petite pour accueillir toutes les convives.");
        //    }
        //}

        //public virtual void viderTable()
        //{
        //    disponible = true;
        //}

        public void ajoutOccupation(Occupation occupation)
        {
            planningResa.Add(occupation);
        }

    }// fin class Table
}
