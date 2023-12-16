using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoAspNetAT.Models;

namespace ProjetoAspNetAT.Data
{
    public class ProjetoAspNetATContext : DbContext
    {
        public ProjetoAspNetATContext (DbContextOptions<ProjetoAspNetATContext> options)
            : base(options)
        {
        }

        public DbSet<ProjetoAspNetAT.Models.Personagens> Personagens { get; set; } = default!;

        public DbSet<ProjetoAspNetAT.Models.Quadrinho>? Quadrinho { get; set; }
    }
}
