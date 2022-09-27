using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AppATS.Models
{
    public partial class Candidato
    {
        public string IdCandidato { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }  
        public string Email { get; set; }        
    }

  public partial class CandidatoResponse
  {
    public List<Candidato> items { get; set; }
  }
}
