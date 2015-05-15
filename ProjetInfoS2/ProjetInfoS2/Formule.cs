using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization; 

namespace ProjetInfoS2
{
    class Formule
    {
        //Variables d'instance
        //public int noFormule;

        private string nomFormule;

        public string NomFormule
        {
            get { return nomFormule; }
            private set { nomFormule = value; }
        }

        private TimeSpan dureePreparation;

        public TimeSpan DureePreparation
        {
            get { return dureePreparation; }
            private set { dureePreparation = value; }
        }

        private TimeSpan dureePresenceClient;

        public TimeSpan DureePresenceClient
        {
            get { return dureePresenceClient; }
            private set { dureePresenceClient = value; }
        }

        private TimeSpan horaireLimiteService;

        public TimeSpan HoraireLimiteService
        {
            get { return horaireLimiteService; }
            private set { horaireLimiteService = value; }
        }
        private bool tableRequise;

        public bool TableRequise
        {
            get { return tableRequise; }
            private set { tableRequise = value; }
        }


        //public string nomFormule;

        //public TimeSpan dureePreparation { get; set; } //en min

        //public TimeSpan dureePresenceClient { get; set; } //en min

        //public DateTime horaireLimiteService { get; set; }

        //public bool tableRequise { get; set; }
        
        
        //Constructeur
        public Formule(string nomFormule, TimeSpan dureePreparation, TimeSpan dureePresenceClient, bool tableRequise)
        {
            this.NomFormule = nomFormule;
            this.DureePreparation = dureePreparation;
            this.DureePresenceClient = dureePresenceClient;
            HoraireLimiteService= new TimeSpan(23, 0, 0);
            HoraireLimiteService-=DureePreparation;
            this.TableRequise = tableRequise;
        }

        //constructeur par defaut
        public Formule()
        { }

        //Méthodes
        public override string ToString()
        {
            string formule = "- "+nomFormule+"\nDurée de préparation en cuisine: "+dureePreparation.Hours+" heures et "+dureePreparation.Minutes
                + " minutes \nTemps de présence du client: " + dureePresenceClient.Hours + " heures et " + dureePresenceClient.Minutes + " minutes\n";
            return formule;
        }


    }// fin class formule
}
