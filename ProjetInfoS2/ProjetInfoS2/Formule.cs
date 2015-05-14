using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization; 

namespace ProjetInfoS2
{
    public class Formule
    {
        //Variables d'instance
        public int noFormule;

        //private string nomFormule;

        //public string NomFormule
        //{
        //    get { return nomFormule; }
        //    set { nomFormule = value; }
        //}

        //private TimeSpan dureePreparation;

        //public TimeSpan DureePreparation
        //{
        //    public get { return dureePreparation; }
        //    set { dureePreparation = value; }
        //}

        //private TimeSpan dureePresenceClient;

        //public TimeSpan DureePresenceClient
        //{
        //    public get { return dureePresenceClient; }
        //    set { dureePresenceClient = value; }
        //}

        //private TimeSpan horaireLimiteService;

        //public TimeSpan HoraireLimiteService
        //{
        //    public get { return horaireLimiteService; }
        //    set { horaireLimiteService = value; }
        //}
        //private bool tableRequise;

        //public bool TableRequise
        //{
        //    get { return tableRequise; }
        //    set { tableRequise = value; }
        //}


        public string nomFormule;

        public TimeSpan dureePreparation { get; set; } //en min

        public TimeSpan dureePresenceClient { get; set; } //en min

        public DateTime horaireLimiteService { get; set; }

        public bool tableRequise { get; set; }
        
        
        //Constructeur
        public Formule(string nomFormule, TimeSpan dureePreparation, TimeSpan dureePresenceClient, bool tableRequise)
        {
            this.nomFormule = nomFormule;
            DateTime maintenant = DateTime.Now;
            this.dureePreparation = dureePreparation;
            this.dureePresenceClient = dureePresenceClient;
            horaireLimiteService= new DateTime(maintenant.Year, maintenant.Month, maintenant.Day, 23, 0, 0);
            horaireLimiteService-=dureePreparation;
            this.tableRequise = tableRequise;
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
