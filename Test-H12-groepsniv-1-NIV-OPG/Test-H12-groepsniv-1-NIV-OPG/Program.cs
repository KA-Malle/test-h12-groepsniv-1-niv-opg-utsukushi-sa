using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_H12_groepsniv_1_NIV_OPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * NAAM => Kyan Stuyts 6ADB 23/10/25
             */

            // Consolekleuren instellen.
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();

            // Waarde volledige record lijn.

            // Per record
            string vorigeVertrekplaats = "", vertrekPlaats = ""; // Sleutel (primary key)
            string vertrekCode;
            decimal bezetting, capaciteit;


            string vollediglijn;
            string[] lijnGesplit;

            // SreamReader starten en titel afdrukken 
            Console.WriteLine("Bezetting vliegtuigen per vertrekpunt");
            Console.WriteLine("=====================================");
            Console.WriteLine("");

            // Document lezen met streamreader.
            using (StreamReader streamLees = new StreamReader("vliegtuigbezetting.txt"))
            {
                // Tellers op  0 zetten
                decimal procent = 0;
                bezetting = 0;
                capaciteit = 0;
                Int32 gecontroleerdeVlieg = 0;
                Int32 rapportVerzonden = 0;
                Int32 gemBezetting = 0;

                // Lezen 1 lijn van een record.
                vollediglijn = streamLees.ReadLine();
                while (streamLees.Peek() != -1 )
                {
                    // Lezen een record
                    vollediglijn = streamLees.ReadLine();
                    lijnGesplit = vollediglijn.Split(',');


                    // Gegevens records juist plaatsen
                    vertrekCode = lijnGesplit[0];
                    vertrekPlaats = lijnGesplit[1];
                    bezetting = Convert.ToDecimal(lijnGesplit[2]);
                    capaciteit = Convert.ToDecimal(lijnGesplit[3]);

                 
                    

                    

                    if (vorigeVertrekplaats != vertrekPlaats)
                    {
                        
                            // Percentage per vliegtuig.
                            procent = Math.Round((bezetting / capaciteit) * 100, 2, MidpointRounding.AwayFromZero);
                            Console.WriteLine("Percentage: " + procent.ToString());
                            Console.WriteLine("");

                        /*
                        // Zolang de vertrekplaats hetzelfde is alles optellen.
                        while (vorigeVertrekplaats == vertrekPlaats)
                        {
                            bezetting += bezetting;
                            capaciteit += capaciteit;
                        }
                        */


                        // vertrekplaats wijzigen
                        Console.WriteLine(vertrekPlaats);
                       // test  Console.WriteLine(vorigeVertrekplaats)
                        // test Console.WriteLine(bezetting);
                       //  test Console.WriteLine(capaciteit);
                        vorigeVertrekplaats = vertrekPlaats;
                       gecontroleerdeVlieg= gecontroleerdeVlieg + 1;



                    }




                }
            }



            // Wachten op enter.
            Console.WriteLine();
            Console.WriteLine("Druk op enter om te eindigen.");
            Console.ReadLine();
        }
    }
}
