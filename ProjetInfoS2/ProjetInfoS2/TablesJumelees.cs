using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetInfoS2
{
    class TablesJumelees: Table
    {

        //Constructeur
        public TablesJumelees(Table table1, Table table2): base (6, 0, true)
        {
            //NbPlaceMax = NbPlaceMax.table1 + NbPlaceMax.table2;

        }
    }// fin class Table
}
