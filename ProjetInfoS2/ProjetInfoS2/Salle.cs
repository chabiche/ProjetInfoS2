using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetInfoS2
{
    class Salle
    {
        private List<Table> tables;
        public List<Table> Tables
        {
            get { return tables; }
            set { tables = value; }
        }

        private List<Formule> formules;
        public List<Formule> Formules
        {
            get { return Formules; }
            set { Formules = value; }
        }

        private List<Reservation> reservations;
        public List<Reservation> Reservations
        {
            get { return Reservations; }
            set { Reservations = value; }
        }


        //Constructeur
        public Salle()
        {
           
        }

        //Méthodes
        public void afficheResaDate()
        {
            Console.WriteLine("Veuillez saisir la date pour laquelle vous souhaitez consulter les réservations");
            DateTime date = DateTime.Parse(Console.ReadLine());
            int i = 0;
            while (reservations[i]!=null)
            {
                if (DateReservation.reservation[i]==date)
                {
                    Console.WriteLine(reservations[i]);
                }
                i++;
            }

        }//fin afficheResaDate
        
        
    }// fin class salle
}
