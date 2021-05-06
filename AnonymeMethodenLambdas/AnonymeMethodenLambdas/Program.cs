using System;
using System.Linq;
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

    public class Planet
    {
        private readonly string _name;
        private readonly string _kategorie;
        private readonly int _durchmesser;

        public Planet(string name, string kategorie, int durchmesser)
        {
            _name = name;
            _kategorie = kategorie;
            _durchmesser = durchmesser;
        }

        public string Name => _name;
        public string Kategorie => _kategorie;
        public int Durchmesser => _durchmesser;

        public override string ToString()
        {
            return $" {_name.PadRight(8)}| {_kategorie.PadRight(15)}| Durchmesser:{_durchmesser.ToString().PadLeft(7, '.')} km";
        }
    }

    public class PlanetenVerwalter
    {
        public void ErstelleDurchmessersortiertePlanetenkategorienLambda(IReadOnlyList<Planet> planetenListe)
        {
            var kategorisiertePlaneten = planetenListe.Where(planet => planet.Kategorie != "Zwergplanet")
                                                      .OrderByDescending(planet => planet.Durchmesser)
                                                      .GroupBy(planet => planet.Kategorie);

            GibKategorisiertePlanetenAus(kategorisiertePlaneten);
        }

        public void ErstelleDurchmessersortiertePlanetenkategorien(IReadOnlyList<Planet> planetenListe)
        {
            // Erzeugen eines Dictionary zur aufnahme der Kategorie als Key und der Liste als Value.
            var kategorisiertePlaneten = new Dictionary<string, List<Planet>>();

            foreach (var planet in planetenListe)
            {
                // Zwergplaneten ausschließen
                if (planet.Kategorie == "Zwergplanet")
                {
                    continue;
                }

                // Ist die endsprechende Kategorie im Dictionary nicht vorhanden,
                // dann eine List von Planeten unter dieser Kategorie initialisieren.
                if (kategorisiertePlaneten.ContainsKey(planet.Kategorie) == false)
                {
                    kategorisiertePlaneten[planet.Kategorie] = new List<Planet>();
                }

                // Den Planeten zu der Liste hinzufügen
                kategorisiertePlaneten[planet.Kategorie].Add(planet);
            }

            // Fertige Liste einer Kategorie nach Durchmesser sortieren.
            foreach (var liste in kategorisiertePlaneten.Values)
            {
                liste.Sort(SortiereNachDurchmesser);
            }

            GibKategorisiertePlanetenAus(kategorisiertePlaneten);
        }

        private static void GibKategorisiertePlanetenAus(Dictionary<string, List<Planet>> kategorisiertePlaneten)
        {
            foreach (var kategorieUndListe in kategorisiertePlaneten)
            {
                var planetenKategorie = kategorieUndListe.Key;
                Console.WriteLine($"Kategorie: {planetenKategorie}");
                Console.WriteLine("-----------------------------------");

                foreach (var liste in kategorieUndListe.Value)
                {
                    Console.WriteLine($" {liste.Name.PadRight(7)} | Durchmesser:{liste.Durchmesser.ToString().PadLeft(8, '.')} km");
                }
                Console.WriteLine();
            }
        }

        private static void GibKategorisiertePlanetenAus(IEnumerable<IGrouping<string, Planet>> kategorisiertePlaneten)
        {
            Console.WriteLine("ErstelleDurchmessersortiertePlanetenkategorienLambda(IReadOnlyList<Planet> planetenListe)");
            Console.WriteLine();
            foreach (var kategorieUndListe in kategorisiertePlaneten)
            {
                var planetenKategorie = kategorieUndListe.Key;
                Console.WriteLine($"Kategorie: {planetenKategorie}");
                Console.WriteLine("-----------------------------------");

                foreach (var liste in kategorieUndListe)
                {
                    Console.WriteLine($" {liste.Name.PadRight(7)} | Durchmesser:{liste.Durchmesser.ToString().PadLeft(8, '.')} km");
                }
                Console.WriteLine();
            }
        }

        private int SortiereNachDurchmesser(Planet ersterPlanet, Planet zweiterPlanet)
        {
            return zweiterPlanet.Durchmesser - ersterPlanet.Durchmesser;
        }
    }
}
