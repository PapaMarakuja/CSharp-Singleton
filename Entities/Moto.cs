namespace Api.Entities
{
    public class Moto
    {
        public long Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public int? Ano { get; set; }
        public decimal Preco { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\nMarca: {Marca}\nModelo: {Modelo}\nPlaca: {Placa}\nAno: {Ano}\nPreço: {Preco:C}\n";
        }
    }
}