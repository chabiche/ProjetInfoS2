using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetInfoS2
{
    class Salle
    {
        public List<Table> tables;
        public List<Table> Tables
        {
            get { return tables; }
            set { tables = value; }
        }

        public List<Formule> formules;
        public List<Formule> Formules
        {
            get { return formules; }
            set { formules = value; }
        }

        public List<Reservation> reservations;
        public List<Reservation> Reservations
        {
            get { return reservations; }
            set { reservations = value; }
        }


        //Constructeur
        public Salle()
        {
            tables = new List<Table>();
            formules = new List<Formule>();
            reservations = new List<Reservation>();
        }

        //Méthodes
        public override string ToString()
        {
            string chaine = "";
            return chaine;
        }

         public void afficheResaDate()
         {
             Console.WriteLine("Veuillez saisir la date pour laquelle vous souhaitez consulter les réservations");
             Console.WriteLine("Le jour:");
             int day = int.Parse(Console.ReadLine());
             Console.WriteLine("Le mois:");
             int month = int.Parse(Console.ReadLine());
             Console.WriteLine("L'année:");
             int year = int.Parse(Console.ReadLine());
             Console.WriteLine("L'heure:");
             int hour = int.Parse(Console.ReadLine());
             Console.WriteLine("Les minutes:");
             int min = int.Parse(Console.ReadLine());
             DateTime date = new DateTime(year, month, day, hour, min, 0);
             Console.WriteLine(date);
             int i = 0;
             while (i<Reservations.Count())
             {
                 if (Reservations[i].dateReservation==date)
                 {
                     Console.WriteLine("Réservation n° {0}:",i+1);
                     Console.WriteLine(Reservations[i]);
                 }
                 i++;
             }
         }//fin afficheResaDate
         

    }// fin class salle
}
