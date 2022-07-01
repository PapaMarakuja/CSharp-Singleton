using Microsoft.AspNetCore.Mvc;
using Api.Entities;
using Api.Services;
using Api.ViewModels;

namespace Api.Controllers;

[ApiController]
[Route("motos")]
public class MotoController : ControllerBase
{
    private readonly MotosService _motosService;

    public MotoController()
    {
        this._motosService = MotosService.GetInstance();
    }

    [HttpGet]
    public IEnumerable<Moto> GetAll()
    {
        return this._motosService.GetAll();
    }

    [HttpGet("{id:long}")]
    public IActionResult GetById([FromRoute] long id)
    {
        return Result(this._motosService.Select(id));
    }

    [HttpPost]
    public IActionResult Insert([FromBody] Moto moto)
    {
        var result = this._motosService.Insert(moto);
        
        return result == null ? StatusCode(500, "Moto já cadastrada") : Ok(result);
    }

    [HttpPut("{id:long}")]
    public IActionResult Update([FromRoute] long id, MotosViewModel moto)
    {
        var res = this._motosService.Update(new Moto
        {
            Id = id,
            Modelo = moto.Modelo,
            Marca = moto.Marca,
            Placa = moto.Placa,
            Ano = moto.Ano,
            Preco = moto.Preco
        });

        return Result(res);
    }

    [HttpDelete("{id:long}")]
    public IActionResult Delete([FromRoute] long id)
    {
        return Result(_motosService.Delelte(id));
    }

    private IActionResult Result(Moto moto)
    {
        return moto == null ? StatusCode(404, "Moto não encontrada.") : Ok(moto);
    }
} 