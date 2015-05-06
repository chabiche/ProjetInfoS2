using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProjetInfoS2
{
    [Serializable]
    public class Reservation
    {
        //Variables d'instance
        [XmlAttribute()]
        public Table table { get; set; }

        [XmlAttribute()]
        public string nomClient { get; set; }

        [XmlAttribute()]
        public int numClient { get; set; }

        [XmlAttribute()]
        public DateTime dateReservation { get; set; }

        [XmlAttribute()]
        public int nbConvives { get; set; }

        [XmlAttribute()]
        public Formule formuleRetenue {get; set;}

        //Constructeur
        public Reservation(Table _table, string _nomClient, int _numClient, DateTime _dateReservation, int _nbConvives, Formule _formuleRetenue)
        {
            table = _table;
            nomClient = _nomClient;
            numClient = _numClient;
            dateReservation = _dateReservation;
            nbConvives = _nbConvives;
            formuleRetenue = _formuleRetenue;
        }
        //constructeur par defaut
        public Reservation()
        {
        }

        //Méthodes
        public void verifierResa()
        { 
        
        
        
        }
        public void validerResa()
        { }


        public void refuserResa()
        { }















        public override string ToString()
        {
            string resa= "\nNom du client: "+nomClient+"\nNuméro du client: "+numClient+"\nDate de la réservation:"+dateReservation+"\nNombre de convives: "+nbConvives+"\nFormule souhaitée: "+formuleRetenue+"\nTable Réservée: "+table;
            return resa;
        }








    }// fin class réservation
}
