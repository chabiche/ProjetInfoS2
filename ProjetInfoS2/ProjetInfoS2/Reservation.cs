using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetInfoS2
{
    class Reservation
    {
        //Variables d'instance
        private Table table;
        public Table Table
        {
            get { return table; }
            set { table = value; }
        }

        private string nomClient;
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
	    public DateTime DateReservation
	    {
		get { return dateReservation;}
		set { dateReservation = value;}
	    }

        private int nbConvives;
        public int NbConvives
        {
            get { return nbConvives; }
            set { nbConvives = value; }
        }

        private Formule formuleRetenue;
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
            DateReservation = DateReservation;
            NbConvives = _nbConvives;
            FormuleRetenue = _formuleRetenue;
        }

        //Méthodes
        public override string ToString()
        {
            string resa= "/nNom du client: "+NomClient+"/nNuméro du client: "+NumClient+"/nDate de laa réservation:"+DateReservation+"/nNombre de convives: "+NbConvives+"/nFormule souhaitée: "+FormuleRetenue+"Table Réservée: "+Table;
            return resa + base.ToString();
        }

    }// fin class réservation
}
