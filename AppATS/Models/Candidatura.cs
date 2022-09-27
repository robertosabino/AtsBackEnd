using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AppATS.Models
{
  public partial class Candidatura
  {
    public string IdCandidatura { get; set; }
    public string IdCandidato { get; set; }
    public string IdVaga { get; set; }
    [JsonIgnore]
    public virtual Candidato IdCandidatoNavigation { get; set; }
    [JsonIgnore]
    public virtual Vaga IdVagaNavigation { get; set; }
  }
}
