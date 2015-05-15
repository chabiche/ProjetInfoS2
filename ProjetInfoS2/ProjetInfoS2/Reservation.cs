using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProjetInfoS2
{
   
    class Reservation
    {
        //Variables d'instance
        private Table table;

        public Table Table
        {
            get { return table; }
            private set { table = value; }
        }
        
       // public Table table { get; set; }
        private string nomClient;

        public string NomClient
        {
            get { return nomClient; }
            private set { nomClient = value; }
        }
        
        //public string nomClient { get; set; }

        private int numClient;

        public int NumClient
        {
            get { return numClient; }
            private set { numClient = value; }
        }
        
        //public int numClient { get; set; } 
        private DateTime dateReservation;

        public DateTime DateReservation
        {
            get { return dateReservation; }
            private set { dateReservation = value; }
        }
        
       // public DateTime dateReservation { get; set; }

        private int nbConvives;

        public int NbConvives
        {
            get { return nbConvives; }
            private set { nbConvives = value; }
        }
        
       // public int nbConvives { get; set; }
        private Formule formuleRetenue;

        public Formule FormuleRetenue
        {
            get { return formuleRetenue; }
            private set { formuleRetenue = value; }
        }
        
       // public Formule formuleRetenue {get; set;}

        //Constructeur
        public Reservation(Table _table, string _nomClient, int _numClient, DateTime _dateReservation, int _nbConvives, Formule _formuleRetenue)
        {
            Table = _table;
            NomClient = _nomClient;
            NumClient = _numClient;
            DateReservation = _dateReservation;
            NbConvives = _nbConvives;
            FormuleRetenue = _formuleRetenue;
        }
        //constructeur par defaut
        public Reservation()
        {
        }

        //Méthodes

        public void validerResa()
        { }


        public void refuserResa()
        { }


        public override string ToString()
        {
            string resa= "** Réservation **\nNom du client: "+nomClient+"\nDate de la réservation:"+dateReservation+"\nNombre de convives: "+nbConvives+"\nFormule souhaitée:\n"+formuleRetenue+"\nTable Réservée:\n"+table+"\n";
            return resa;
        }








    }// fin class réservation
}
