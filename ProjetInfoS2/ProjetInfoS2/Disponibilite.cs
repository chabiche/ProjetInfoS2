using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetInfoS2
{
    public class Disponibilite
    {
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


        public Disponibilite()
        {
            dateDebutOccupee = new DateTime();
            dateFinOccupee = new DateTime();
        }

        public Disponibilite(DateTime dateDebut, TimeSpan duree)
        {
            dateDebutOccupee = new DateTime();
            dateFinOccupee = new DateTime();

            dateDebutOccupee = dateDebut;
            dateFinOccupee = dateDebut + duree;
        }


    }
}
