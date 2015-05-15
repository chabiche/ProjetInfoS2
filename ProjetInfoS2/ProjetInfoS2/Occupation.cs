using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetInfoS2
{
    class Occupation
    {
        private DateTime dateDebutOccupee;

        public DateTime DateDebutOccupee
        {
            get { return dateDebutOccupee; }
            private set { dateDebutOccupee = value; }
        }


        private DateTime dateFinOccupee;

        public DateTime DateFinOccupee
        {
            get { return dateFinOccupee; }
            private set { dateFinOccupee = value; }
        }


        public Occupation()
        {
            DateDebutOccupee = new DateTime();
            DateFinOccupee = new DateTime();
        }
        public Occupation(DateTime datedebut, DateTime datefin)
        {
            DateDebutOccupee = new DateTime();
            DateFinOccupee = new DateTime();
            DateDebutOccupee = datedebut;
            DateFinOccupee = datefin;
        }

        public Occupation(DateTime dateDebut, TimeSpan duree)
        {
            DateDebutOccupee = new DateTime();
            DateFinOccupee = new DateTime();

            DateDebutOccupee = dateDebut;
            DateFinOccupee = dateDebut + duree;
        }

        public override string ToString()
        {
            return "- Occupé pour la date suivante: \n:nDate de début : "+DateDebutOccupee+"\nDate de fin : "+DateFinOccupee+"\n";
        }

    }
}
