using System.Collections.Generic;
using System.Linq;
using Api.Entities;

namespace Api.Repositories
{
    public class MotoRepository
    {
        private static MotoRepository _instance = null;
        private Dictionary<long, Moto> Motos { get; set; }

        private MotoRepository()
        {
            this.Motos = new Dictionary<long, Moto>();
        }

        public static MotoRepository GetInstance()
        {
            return _instance ?? (_instance = new MotoRepository());
        }

        public void Insert(Moto moto)
        {
            this.Motos.Add(moto.Id, moto);
        }

        public void Update(Moto moto)
        {
            this.Motos.Remove(moto.Id);
            this.Motos.Add(moto.Id, moto);
        }

        public Moto Select(long id)
        {
            return this.Motos.ContainsKey(id) ? this.Motos[id] : null;
        }

        public IEnumerable<Moto> GetAll() => this.Motos.Values;
        

        public void Delete(long id) => Motos.Remove(id);
    }
}