namespace AnonymeMethodenLambdas
{
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
}
