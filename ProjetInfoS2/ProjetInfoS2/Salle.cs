using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization; 

namespace ProjetInfoS2
{
    public class Salle
    {
        public List<Table> tables{ get; set; }

        public List<Formule> formules { get; set; }

        public List<Reservation> reservations { get; set; }

        Cuisine C = new Cuisine();


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

        public void afficheFormule() //il faudrait rajouter nom de la formule dans les attributs
        {
            for (int i = 0; i < formules.Count; i++)
            {
                Console.WriteLine("n°"+(i+1) + " "+ formules[i]+ "\n");
            }
        
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
             while (i<reservations.Count())
             {
                 if (reservations[i].dateReservation==date)
                 {
                     Console.WriteLine("Réservation n° {0}:",i+1);
                     Console.WriteLine(reservations[i]);
                 }
                 i++;
             }
         }//fin afficheResaDate

         //voir si la reservation est possible
        public void verifierResa(DateTime dateEtHeure, int nbconvive, Formule formuleChoisie)
        { 
            int i = 0;
            while (i<tables.Count)
            {
                if (tables[i].disponible==true)
                {
                    if (tables[i].nbPlaceMax>nbconvive)
                    {
                        Console.WriteLine("Reservation possible sur la table "+ i);
                        //controle des cuisiniers dispos

                        ValiderResa(tables[i], dateEtHeure, nbconvive, formuleChoisie);
                        //comment faire pour gerer le fait qu'une table n'est pas suffisament remplie?
                    }

                    else // cad qu'il n'y a pas de table dispo avec assez de place --> on regarde le jumelage
                    {
                        int j = i+1;
                        while(j < tables.Count)
                        {
                            if (tables[i].jumelable==true && tables[i].jumelable==true)
                            {
                                Console.WriteLine(@"Il est possible d'effectuer un jumelable de table 
afin de pouvoir placer tous les convives
Possibilité d'association de la table: " + tables[i] + " et " + tables[j]
+". Voulez vous associer ces deux tables? (oui/non)");
                                string reponse=Console.ReadLine();
                                if (reponse=="oui")
                                {
                                    //jumelage de tables
                                    TablesJumelees jumelage = new TablesJumelees(tables[i], tables[j]);
                                    //serialisation
                                }
                                else
                                {
                                    Console.WriteLine("Les deux tables n'ont pas été assemblées");
                                }

                            }
                            
                        }

                        j++;
                    } 
                   
                }
                
                else //aucune table n'est disponible
	                {
                        Console.WriteLine("Aucune table n'est disponible.");
	                }
                i++;
            }
        
        
        }

        public void ValiderResa(Table table, DateTime dateEtHeure, int nbconvive, Formule formuleChoisie)
        {
            //ATTENTION: il faut d'abord controller qu'on a bien des cuisiniers dispo!!!!!!!!

            Console.WriteLine("Quel est le nom pour la réservation?");
            string nomResa=Console.ReadLine();
            //Il faut lui attribuer un numero de client pour pouvoir creer la résa
            //création et sérialisation de la résa Reservation newResa= new Reservation(......)
            //restau.reservations.Add(resa);

        }

        //Serialisation de la liste de formules
        public void SerialisationListFormules(List<Formule> listFormules)
        {
            XmlSerializer x = new XmlSerializer(typeof(List<Formule>));
            StreamWriter writer = new StreamWriter("Test.xml", false);
            x.Serialize(writer, listFormules);
            writer.Close();
        }

        //serialisation de la liste des reservations
        public void SerialisationListReservations(List<Reservation> listReservations)
        {
            XmlSerializer x = new XmlSerializer(typeof(List<Reservation>));
            StreamWriter writer = new StreamWriter("Test.xml", true);
            x.Serialize(writer, listReservations);
            writer.Close();
        }

        //serialisation de la liste des tables
        public void SerialisationListTables(List<Table> listTables)
        {
            XmlSerializer x = new XmlSerializer(typeof(List<Table>));
            StreamWriter writer = new StreamWriter("Test.xml", true);
            x.Serialize(writer, listTables);
            writer.Close();
        }


    }// fin class salle
}
