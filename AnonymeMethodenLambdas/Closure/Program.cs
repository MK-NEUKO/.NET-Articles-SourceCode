using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Closure
{
    class Closure
    {
        static void Main(string[] args)
        {
            var planetenImSonnensystem = new List<string>()
                                 {
                                     "Merkur","Venus","Erde","Mars",
                                     "Jupiter","Saturn","Uranus","Neptun",
                                 };

            Action anonymeMethode = delegate
            {
                foreach (var planet in planetenImSonnensystem)
                {
                    Console.WriteLine(planet);
                }
            };
            anonymeMethode();


            int meineZahl = 77;
            Console.WriteLine();
            Console.WriteLine($"Die Variable \"meineZahl\" vor allen Aufrufen:.......................{meineZahl}");
            Console.WriteLine("---------------------------------------------------------------------");

            Action anonymeMethode2 = () =>
            {
                meineZahl++;
                Console.WriteLine($"In der anonymen Methode (mit Closure) nach der Inkrementierung:....{meineZahl}");
            };
            anonymeMethode2();
            Console.WriteLine($"Ausserhalb und nach der anonymen Methode (mit Closure):............{meineZahl}");
            Console.WriteLine("---------------------------------------------------------------------");

            Action<int> anonymeMethode3 = delegate (int zahl)
            {
                zahl++;
                Console.WriteLine($"In der anonymen Methode (ohne Closure) nach der Inkrementierung:...{zahl}");
            };
            anonymeMethode3(meineZahl);
            Console.WriteLine($"Ausserhalb und nach der anonymen Methode (ohne Closure):...........{meineZahl}");
            Console.WriteLine("---------------------------------------------------------------------");

            ErhöheMeineZahl(meineZahl);
            Console.WriteLine($"Ausserhalb und nach ErhöheMeineZahl():............{meineZahl}");
        }

        private static void ErhöheMeineZahl(int meineZahl)
        {
            meineZahl++;
            Console.WriteLine($"In ErhöheMeineZahl() nach der Inkrementierung:....{meineZahl}");
        }
    }
}
