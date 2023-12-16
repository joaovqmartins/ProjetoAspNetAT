using Microsoft.AspNetCore.Builder;
using ProjetoAspNetAT.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoAspNetAT.Data
{
    public class Banco_Inicial
    {
        public static void Seed(ProjetoAspNetATContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Personagens.Any())
            {
                context.Personagens.AddRange(new List<Personagens>()
                {
                    new Personagens()
                    {
                        Nome = "Superman",
                        Idade = 25,
                        Descricao = "superforte"
                    
                    }
                });

                context.SaveChanges();
            }
        }
    }
}
