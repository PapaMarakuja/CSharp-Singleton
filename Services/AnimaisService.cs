using System.Collections.Generic;
using Api.Entities;
using Api.Repositories;

namespace Api.Services
{
    public class AnimaisService
    {
        private static AnimaisService _instance = null;
        private readonly AnimalRepository _repository;

        private AnimaisService()
        {
            this._repository = AnimalRepository.GetInstance();
        }

        public static AnimaisService GetInstance()
        {
            return _instance ??= new AnimaisService();
        }

        public Animal Insert(Animal animal)
        {
            if (this._repository.Select(animal.Id) != null)
            {
                return null;
            }

            this._repository.Insert(animal);
            return animal;
        }

        public Animal Update(Animal animal)
        {
            if (this._repository.Select(animal.Id) == null)
            {
                return null;
            }

            this._repository.Update(animal);
            return animal;
        }

        public Animal Delete(long id)
        {
            var entidade = this._repository.Select(id);
            if (entidade == null) return null;

            this._repository.Delete(id);
            return entidade;
        }

        public IEnumerable<Animal> GetAll() => this._repository.GetAll();

        public Animal Select(long id) => this._repository.Select(id);
    }
}