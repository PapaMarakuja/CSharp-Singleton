using System.Collections.Generic;
using Api.Entities;

namespace Api.Repositories
{
    public class AnimalRepository
    {
        private static AnimalRepository _instance = null;
        private Dictionary<long, Animal> Animais { get; set; }

        private AnimalRepository()
        {
            this.Animais = new Dictionary<long, Animal>();
        }

        public static AnimalRepository GetInstance()
        {
            return _instance ?? (_instance = new AnimalRepository());
        }

        public void Insert(Animal animal)
        {
            this.Animais.Add(animal.Id, animal);
        }

        public void Update(Animal animal)
        {
            this.Animais.Remove(animal.Id);
            this.Animais.Add(animal.Id, animal);
        }

        public Animal Select(long id)
        {
            return this.Animais.ContainsKey(id) ? this.Animais[id] : null;
        }

        public IEnumerable<Animal> GetAll() => this.Animais.Values;

        public void Delete(long id) => Animais.Remove(id);
    }
}