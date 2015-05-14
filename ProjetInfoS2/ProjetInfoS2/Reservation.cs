using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProjetInfoS2
{
    [Serializable]
    public class Reservation
    {
        //Variables d'instance
        public Table table { get; set; }

        public string nomClient { get; set; }
       
        public DateTime dateReservation { get; set; }
        
        public int nbConvives { get; set; }

        public Formule formuleRetenue {get; set;}

        //Constructeur
        public Reservation(Table _table, string _nomClient, DateTime _dateReservation, int _nbConvives, Formule _formuleRetenue)
        {
            table = _table;
            nomClient = _nomClient;
            dateReservation = _dateReservation;
            nbConvives = _nbConvives;
            formuleRetenue = _formuleRetenue;
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
