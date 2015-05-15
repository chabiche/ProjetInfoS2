using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization; 

namespace ProjetInfoS2
{
    abstract class Table
    {  
        //variables d'instances
        private List<Occupation> planningResa;

        public List<Occupation> PlanningResa
        {
            get { return planningResa; }
            protected set { planningResa = value; }
        }
        
      //  public List<Occupation> planningResa;

        private int nbPlaceMax;

        public int NbPlaceMax
        {
            get { return nbPlaceMax; }
            protected set { nbPlaceMax = value; }
        }
        
       // public int nbPlaceMax { get; set; }
        private bool jumelable;

        public bool Jumelable
        {
            get { return jumelable; }
            protected set { jumelable = value; }
        }
        
        //public bool jumelable { get; set; }

        //Constructeur
        public Table(int _nbPlaceMax, bool _jumelable)
        {
            NbPlaceMax = _nbPlaceMax;
            Jumelable = _jumelable;
            PlanningResa = new List<Occupation>();
        }
        //Constructeur par defaut
        public Table() { }

        //Méthodes
        public override string ToString()
        {
            string chaine = "- Table: \nNombre de places maximum: " + nbPlaceMax +"\nJumelable: ";
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
            chaine += "\n";
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

    }// fin class Table
}
