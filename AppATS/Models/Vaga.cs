using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AppATS.Models
{
  public partial class Vaga
  {
    public string IdVaga { get; set; }
    public string Descricao { get; set; }
    public string Situacao { get; set; }
  }

  public partial class VagasResponse
  {
    public List<Vaga> items { get; set; }
  }
}
