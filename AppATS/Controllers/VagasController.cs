using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppATS.Models;
using AppATS.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppATS.Controllers
{
  //[Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class VagasController : Controller
  {
    private readonly IVagaRepository repository;
    public VagasController(IVagaRepository _context)
    {
      repository = _context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Vaga>>> GetVagas()
    {
      var Vagas = await repository.GetAll();
      if (Vagas == null)
      {
        return BadRequest();
      }
      return Ok(new VagasResponse() { items = Vagas.ToList() });
    }

    // GET: api/Products/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Vaga>> GetVaga(string idVaga)
    {
      var Vaga = await repository.GetById(idVaga);
      if (Vaga == null)
      {
        return NotFound("Vaga não encontrado pelo id informado");
      }
      return Ok(Vaga);
    }

    // POST api/<controller>  
    [HttpPost]
    public async Task<IActionResult> PostVaga([FromBody]Vaga Vaga)
    {
      if (Vaga == null)
      {
        return BadRequest("Vaga é null");
      }
      await repository.Insert(Vaga);
      return CreatedAtAction(nameof(GetVaga), new { idVaga = Vaga.IdVaga }, Vaga);
    }

    [HttpPut("{idVaga}")]
    public async Task<IActionResult> PutVaga(string idVaga, Vaga Vaga)
    {
      if (idVaga != Vaga.IdVaga)
      {
        return BadRequest($"O código do Vaga {idVaga} não confere");
      }
      try
      {
        await repository.Update(idVaga, Vaga);
      }
      catch (DbUpdateConcurrencyException)
      {
        throw;
      }
      return Ok("Atualização do Vaga realizada com sucesso");
    }

    [HttpDelete("{idVaga}")]
    public async Task<ActionResult<Vaga>> DeleteVaga(string idVaga)
    {
      var Vaga = await repository.GetById(idVaga);
      if (Vaga == null)
      {
        return NotFound($"Vaga de {idVaga} foi não encontrado");
      }
      await repository.Delete(idVaga);
      return Ok(Vaga);
    }
  }
}
