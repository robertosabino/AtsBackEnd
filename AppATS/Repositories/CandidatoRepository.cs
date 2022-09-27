using AppATS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppATS.Repositories
{
  public class CandidatoRepository : GenericRepository<Candidato>, ICandidatoRepository
  {
    public CandidatoRepository(AppDbContext repositoryContext)
            : base(repositoryContext)
    {
    }
  }
}
