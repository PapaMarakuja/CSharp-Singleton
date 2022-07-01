using System.Collections.Generic;
using System.Linq;
using Api.Entities;
using Api.Repositories;

namespace Api.Services
{
    public class MotosService
    {
        private static MotosService _instance = null;
        private readonly MotoRepository _repository;

        private MotosService()
        {
            this._repository = MotoRepository.GetInstance();
        }

        public static MotosService GetInstance()
        {
            return _instance ??= new MotosService();
        }

        public Moto Insert(Moto moto)
        {
            if (this._repository.Select(moto.Id) != null)
            {
                return null;
            }

            this._repository.Insert(moto);
            return moto;
        }

        public Moto Update(Moto moto)
        {
            if (this._repository.Select(moto.Id) == null)
            {
                return null;
            }

            this._repository.Update(moto);
            return moto;
        }

        public Moto Delelte(long id)
        {
            var entidade = this._repository.Select(id);
            if (entidade == null) return null;
            
            this._repository.Delete(id);
            return entidade;

        }

        public Moto Select(long id) => this._repository.Select(id);

        public IEnumerable<Moto> GetAll() => this._repository.GetAll();
    }
}