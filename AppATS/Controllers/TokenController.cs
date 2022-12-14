using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AppATS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppATS.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TokenController : Controller
  {
    public IConfiguration _configuration;
    private readonly AppDbContext _context;

    public TokenController(IConfiguration config, AppDbContext context)
    {
      _configuration = config;
      _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> AutenticaCandidato(CandidatoToken _Candidato)
    {
      if (_Candidato != null && _Candidato.Email != null && _Candidato.Senha != null)
      {
        var Candidato = await GetCandidato(_Candidato.Email, _Candidato.Senha);
        if (Candidato != null)
        {
          //cria claims baseado nas informações do usuário
          var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Id", Candidato.IdCandidato.ToString()),
                    new Claim("Nome", Candidato.Nome),
                    new Claim("Login", Candidato.Login),
                    new Claim("Email", Candidato.Email)
                   };
          var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
          var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
          var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                       _configuration["Jwt:Audience"], claims,
                       expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);
          Token tokenRestponse = new Token();
          tokenRestponse.token = new JwtSecurityTokenHandler().WriteToken(token);
          return Ok(tokenRestponse);
        }
        else
        {
          return BadRequest("Credenciais inválidas");
        }
      }
      else
      {
        return BadRequest();
      }
    }

    private async Task<Candidato> GetCandidato(string email, string password)
    {
      return await _context.Candidatos.FirstOrDefaultAsync(u => u.Email == email && u.Senha == password);
    }
  }
}
