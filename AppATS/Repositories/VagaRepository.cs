using AppATS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppATS.Repositories
{
  public class VagaRepository : GenericRepository<Vaga>, IVagaRepository
  {
    public VagaRepository(AppDbContext repositoryContext)
            : base(repositoryContext)
    {
    }
  }
}
