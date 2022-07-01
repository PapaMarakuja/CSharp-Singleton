namespace Api.Entities
{
    public class Animal
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Especie { get; set; }
        public char Tipo { get; set; }
        public decimal Altura { get; set; }
        public decimal Peso { get; set; }

        private string RetornaTipo(char tipo) => tipo == 'O' ? "Onívoro" : tipo == 'H' ? "Herbívoro" : "Carnívoro";

        public override string ToString()
        {
            return
                $"Id: {Id}\nNome: {Nome}\nEspecie: {Especie}\nTipo: {RetornaTipo(Tipo)}\nAltura: {Altura:F1}\nPeso: {Peso:F1}\n";
        }
    }
}