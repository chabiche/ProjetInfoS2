﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetInfoS2
{
    public class Occupation
    {
        private int noOccupation;

        public int NoOccupation
        {
            get { return noOccupation; }
            set { noOccupation = value; }
        }
        
        private DateTime dateDebutOccupee;

        public DateTime DateDebutOccupee
        {
            get { return dateDebutOccupee; }
            set { dateDebutOccupee = value; }
        }


        private DateTime dateFinOccupee;

        public DateTime DateFinOccupee
        {
            get { return dateFinOccupee; }
            set { dateFinOccupee = value; }
        }


        public Occupation()
        {
            dateDebutOccupee = new DateTime();
            dateFinOccupee = new DateTime();
        }

        public Occupation(DateTime dateDebut, TimeSpan duree)
        {
            dateDebutOccupee = new DateTime();
            dateFinOccupee = new DateTime();

            dateDebutOccupee = dateDebut;
            dateFinOccupee = dateDebut + duree;
        }


    }
}