using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetInfoS2
{
    class Formule
    {
        //Variables d'instance
        private TimeSpan dureePreparation; //en min
        public TimeSpan DureePreparation
        {
            get { return dureePreparation; }
            set { dureePreparation = value; }
        }

        private TimeSpan dureePrensenceClient; //en min
        public TimeSpan DureePresenceClient
        {
            get { return dureePrensenceClient; }
            set { dureePrensenceClient = value; }
        }

        private DateTime horaireLimiteService;
        public DateTime HoraireLimiteService // en min
        {
            get { return horaireLimiteService; }
            set { horaireLimiteService = value; }
        }

        private bool tableRequise;
        public bool TableRequise
        {
            get { return tableRequise; }
            set { tableRequise = value; }
        }
        
        //Constructeur
        public Formule(TimeSpan _dureePreparation, TimeSpan _dureePresenceClient, bool _tableRequise)
        {
            DateTime maintenant = DateTime.Now;
            DureePreparation = _dureePreparation;
            DureePresenceClient = _dureePresenceClient;
            HoraireLimiteService= new DateTime(maintenant.Year, maintenant.Month, maintenant.Day, 23, 0, 0);
            HoraireLimiteService-=DureePreparation;
            TableRequise = _tableRequise;
        }

        //Méthodes
        public override string ToString()
        {
            string formule = "Durée de préparation en cuisine: "+DureePreparation+"/nTemps de présence du client: "+DureePresenceClient;
            return formule + base.ToString();
        }

    }// fin class formule
}
