using Microsoft.AspNetCore.Mvc;
using Api.Entities;
using Api.Services;
using Api.ViewModels;

namespace Api.Controllers;

[ApiController]
[Route("animais")]
public class AnimaisController : ControllerBase
{
    private readonly AnimaisService _animaisService;

    public AnimaisController()
    {
        this._animaisService = AnimaisService.GetInstance();
    }

    [HttpGet]
    public IEnumerable<Animal> GetAll()
    {
        return this._animaisService.GetAll();
    }

    [HttpGet("{id:long}")]
    public IActionResult GetById([FromRoute] long id)
    {
        return Result(this._animaisService.Select(id));
    }

    [HttpPost]
    public IActionResult Insert([FromBody] Animal animal)
    {
        var result = this._animaisService.Insert(animal);

        return result == null ? StatusCode(500, "Animal já cadastrado") : Ok(result);
    }

    [HttpPut("{id:long}")]
    public IActionResult Update([FromRoute] long id, AnimalViewModel animal)
    {
        var res = this._animaisService.Update(new Animal
        {
            Id = id,
            Especie = animal.Especie,
            Nome = animal.Nome,
            Altura = animal.Altura,
            Peso = animal.Peso,
            Tipo = animal.Tipo
        });

        return Result(res);
    }

    [HttpDelete("{id:long}")]
    public IActionResult Delete([FromRoute] long id)
    {
        return Result(_animaisService.Delete(id));
    }

    private IActionResult Result(Animal animal)
    {
        return animal == null ? StatusCode(404, "Animal não encontrado.") : Ok(animal);
    }
}