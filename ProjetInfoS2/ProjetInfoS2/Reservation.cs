using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetInfoS2
{
    class Reservation
    {
        //Variables d'instance
        public Table table;
        public Table Table
        {
            get { return table; }
            set { table = value; }
        }

        public string nomClient;
        public string NomClient
        {
            get { return nomClient; }
            set { nomClient = value; }
        }

        private int numClient;
        public int NumClient
        {
            get { return numClient; }
            set { numClient = value; }
        }
        
        public DateTime dateReservation;
        //public DateTime DateReservation
        //{
        //get { return dateReservation;}
        //set { dateReservation = value;}
        //}

        public int nbConvives;
        //public int NbConvives
        //{
        //    get { return nbConvives; }
        //    set { nbConvives = value; }
        //}

        public Formule formuleRetenue;
        public Formule FormuleRetenue
        {
            get { return formuleRetenue; }
            set { formuleRetenue = value; }
        }
        
        //Constructeur
        public Reservation(Table _table, string _nomClient, int _numClient, DateTime _dateReservation, int _nbConvives, Formule _formuleRetenue)
        {
            Table = _table;
            NomClient = _nomClient;
            NumClient = _numClient;
            dateReservation = _dateReservation;
            nbConvives = _nbConvives;
            FormuleRetenue = _formuleRetenue;
        }

        //Méthodes
        public override string ToString()
        {
            string resa= "\nNom du client: "+NomClient+"\nNuméro du client: "+NumClient+"\nDate de la réservation:"+dateReservation+"\nNombre de convives: "+nbConvives+"\nFormule souhaitée: "+FormuleRetenue+"\nTable Réservée: "+Table;
            return resa;
        }

    }// fin class réservation
}
