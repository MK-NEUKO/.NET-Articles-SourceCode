using System;
using System.Collections.Generic;

namespace AnonymeMethodenLambdas
{
    class Program
    {
        static void Main(string[] args)
        {
            string meinText = "Hallo Welt";
            // Eine anonyme Methode die zwei übergebene Werte Addiert.
            Func<int, int, int> anonymeMethode = delegate (int wert1, int wert2)
            {
                return wert1 + wert2;
            };

            // Die gleiche anonyme Methode als Lambda-Ausdruck
            Func<int, int, int> lambda1 = (int wert1, int wert2) => { return wert1 + wert2; };

            // Die Typenangaben der Parameter können weggelassen werden
            Func<int, int, int> lambda2 = (wert1, wert2) => { return wert1 + wert2; };

            // Befindet sich nur eine Anweisung in der anonymen Methode,
            // kann das return und die geschweiften Klammern weggelassen werden.
            Func<int, int, int> lambda3 = (wert1, wert2) => wert1 + wert2;

            // Ein Lambda mit nur einem Parameter.
            Func<int, int> lambda4 = wert => wert * wert;

            // Ein Lambda ohne Parameter, der Closure nutzt.
            Action lambda5 = () => Console.WriteLine(meinText);

            Console.WriteLine(anonymeMethode(7, 3));
            Console.WriteLine(lambda1(7, 3));
            Console.WriteLine(lambda2(7, 3));
            Console.WriteLine(lambda3(7, 3));
            Console.WriteLine(lambda4(7));
            lambda5();
            Console.WriteLine();



            var planetenImSonnensystem = new List<Planet>
                                        {
                                            new Planet( "Merkur", "Gesteinsplanet", 4879),
                                            new Planet( "Venus", "Gesteinsplanet", 12103),
                                            new Planet( "Erde", "Gesteinsplanet", 12735),
                                            new Planet( "Mars", "Gesteinsplanet", 6772),
                                            new Planet( "Jupiter", "Gasplanet", 138346),
                                            new Planet( "Saturn", "Gasplanet", 114632),
                                            new Planet( "Uranus", "Gasplanet", 50532),
                                            new Planet( "Neptun", "Gasplanet", 49105),
                                            new Planet( "Pluto", "Zwergplanet", 2374),
                                            new Planet( "Ceres", "Zwergplanet", 975),
                                        };

            planetenImSonnensystem.ForEach(planet => Console.WriteLine(planet));
            Console.WriteLine();

            var planetenVerwalter = new PlanetenVerwalter();
            planetenVerwalter.ErstelleDurchmessersortiertePlanetenkategorien(planetenImSonnensystem);

            planetenVerwalter.ErstelleDurchmessersortiertePlanetenkategorienLambda(planetenImSonnensystem);
        }
    }
}
