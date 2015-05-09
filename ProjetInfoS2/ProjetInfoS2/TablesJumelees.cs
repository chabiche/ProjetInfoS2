using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization; 

namespace ProjetInfoS2
{
    public class TablesJumelees: Table
    {

        //Constructeur
        public TablesJumelees(Table table1, Table table2)
        {
            nbPlaceMax = table1.nbPlaceMax + table2.nbPlaceMax -2;
            // On supprime également les places en bout de table car les tables seront accolées
            disponible = true; ;
            jumelable = true;
            //Les tables sont à nouveau jumelable afin de ne pas limiter à deux le nombre de tables jumelées
            table1.remplirTable(table1.nbPlaceMax);
            table2.remplirTable(table2.nbPlaceMax);
            //Occupe les deux tables jumelées
        }

    }// fin class Table
}
