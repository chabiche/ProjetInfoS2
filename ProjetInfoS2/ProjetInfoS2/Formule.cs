using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization; 

namespace ProjetInfoS2
{
    public class Formule
    {
        //Variables d'instance
        public TimeSpan dureePreparation { get; set; } //en min

        public TimeSpan dureePresenceClient { get; set; } //en min

        public DateTime horaireLimiteService { get; set; }

        public bool tableRequise { get; set; }
        
        
        //Constructeur
        public Formule(TimeSpan _dureePreparation, TimeSpan _dureePresenceClient, bool _tableRequise)
        {
            DateTime maintenant = DateTime.Now;
            dureePreparation = _dureePreparation;
            dureePresenceClient = _dureePresenceClient;
            horaireLimiteService= new DateTime(maintenant.Year, maintenant.Month, maintenant.Day, 23, 0, 0);
            horaireLimiteService-=dureePreparation;
            tableRequise = _tableRequise;
        }

        //constructeur par defaut
        public Formule()
        { }

        //Méthodes
        public override string ToString()
        {
            string formule = "Durée de préparation en cuisine: "+dureePreparation+"\nTemps de présence du client: "+dureePresenceClient;
            return formule;
        }

    }// fin class formule
}
