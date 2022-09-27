using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppATS.Models;
using AppATS.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppATS.Controllers
{
  //[Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class CandidatosController : Controller
  {
    private readonly ICandidatoRepository repository;
    public CandidatosController(ICandidatoRepository _context)
    {
      repository = _context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Candidato>>> GetCandidatos()
    {
      var Candidatos = await repository.GetAll();
      if (Candidatos == null)
      {
        return BadRequest();
      }
      return Ok(new CandidatoResponse() { items = Candidatos.ToList() });
    }

    // GET: api/Products/5
    [HttpGet("{idCandidato}")]
    public async Task<ActionResult<Candidato>> GetCandidato(string idCandidato)
    {
      var Candidato = await repository.GetById(idCandidato);
      if (Candidato == null)
      {
        return NotFound("Candidato não encontrado pelo id informado");
      }
      return Ok(Candidato);
    }

    // POST api/<controller>  
    [HttpPost]
    public async Task<IActionResult> PostCandidato([FromBody]Candidato Candidato)
    {
      if (Candidato == null)
      {
        return BadRequest("Candidato é null");
      }
      await repository.Insert(Candidato);
      return CreatedAtAction(nameof(GetCandidato), new { idCandidato = Candidato.IdCandidato }, Candidato);
    }

    [HttpPut("{idCandidato}")]
    public async Task<IActionResult> PutCandidato(string idCandidato, Candidato Candidato)
    {
      if (idCandidato != Candidato.IdCandidato)
      {
        return BadRequest($"O código do Candidato {idCandidato} não confere");
      }
      try
      {
        await repository.Update(idCandidato, Candidato);
      }
      catch (DbUpdateConcurrencyException)
      {
        throw;
      }
      return Ok("Atualização do Candidato realizada com sucesso");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Candidato>> DeleteCandidato(string idCandidato)
    {
      var Candidato = await repository.GetById(idCandidato);
      if (Candidato == null)
      {
        return NotFound($"Candidato de {idCandidato} foi não encontrado");
      }
      await repository.Delete(idCandidato);
      return Ok(Candidato);
    }
  }
}
