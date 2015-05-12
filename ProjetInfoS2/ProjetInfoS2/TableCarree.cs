﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization; 

namespace ProjetInfoS2
{
    public class TableCarree:Table
    {
        //Constructeur
        public TableCarree(): base (4, true)
        {
        }

        public void ajoutOccupation(Occupation occupation)
        {
            planningResa.Add(occupation);
        }

    }// fin class TableCarree
}
