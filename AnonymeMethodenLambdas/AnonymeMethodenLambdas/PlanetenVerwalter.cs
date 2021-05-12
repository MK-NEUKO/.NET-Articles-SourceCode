using System;
using System.Linq;
using System.Collections.Generic;

namespace AnonymeMethodenLambdas
{
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
