using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetInfoS2
{
    class Program
    {
        static void Main(string[] args)
        {
            int choix = 0;
            switch (choix)
            {
                case 0:
                    Console.WriteLine(@"Bonjour et bienvenu !
Que souhaitez-vous réaliser?

1- Ajouter un cuisinier");
                    choix = int.Parse(Console.ReadLine());
                    break;

                case 1:
                    Console.WriteLine("Vous souhaitez ajouter un cuisinier. Quel est le numéro de ce cuisinier?");
                    int noCuisto = int.Parse(Console.ReadLine());
                    //ajoutCuisto(noCuisto);
                    break;

                case 2:
                    Console.WriteLine("Case 2");
                    break;

                default:
                    Console.WriteLine("Coucou");
                    break;

                    Console.ReadLine();

            }// fin main
        }
    }
}
