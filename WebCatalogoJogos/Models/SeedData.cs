using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebCatalogoJogos.Data;
using System;
using System.Linq;

namespace WebCatalogoJogos.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebCatalogoJogosContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<WebCatalogoJogosContext>>()))
            {
                // Look for any Catalogo.
                if (context.Catalogo.Any())
                {
                    return;   // DB has been seeded
                }

                context.Catalogo.AddRange(
                    new Catalogo
                    {
                        Titulo = "Deus e o Diabo na Terra do Sol",
                        Ativo = true,
                        Genero = "Drama",
                        Preco = 7.99M,
                        Incluido = DateTime.Parse("1964-1-1"),
                        Locado = true,
                        LocadoEm = DateTime.Parse("1900-1-1")
                    },
                    new Catalogo
                    {
                        Titulo = "Macunaíma",
                        Ativo = true,
                        Genero = "Comédia",
                        Preco = 17.99M,
                        Incluido = DateTime.Parse("1969-1-1"),
                        Locado = true,
                        LocadoEm = DateTime.Parse("1900-1-1")
                    },
                    new Catalogo
                    {
                        Titulo = "Central do Brasil",
                        Ativo = true,
                        Genero = "Drama",
                        Preco = 27.99M,
                        Incluido = DateTime.Parse("1998-1-1"),
                        Locado = true,
                        LocadoEm = DateTime.Parse("1900-1-1")
                    },
                    new Catalogo
                    {
                        Titulo = "Pixote, a Lei do Mais Fraco",
                        Ativo = true,
                        Genero = "Drama",
                        Preco = 7.99M,
                        Incluido = DateTime.Parse("1980-1-1"),
                        Locado = true,
                        LocadoEm = DateTime.Parse("1900-1-1")
                    },
                    new Catalogo
                    {
                        Titulo = "Ilha das Flores",
                        Ativo = true,
                        Genero = "Documentário",
                        Preco = 37.99M,
                        Incluido = DateTime.Parse("1989-1-1"),
                        Locado = true,
                        LocadoEm = DateTime.Parse("1900-1-1")
                    },
                    new Catalogo
                    {
                        Titulo = "Bye Bye Brasil",
                        Ativo = true,
                        Genero = "Comédia",
                        Preco = 47.99M,
                        Incluido = DateTime.Parse("1979-1-1"),
                        Locado = true,
                        LocadoEm = DateTime.Parse("1900-1-1")
                    },
                    new Catalogo
                    {
                        Titulo = "Rio, 40 Graus",
                        Ativo = true,
                        Genero = "Drama",
                        Preco = 7.99M,
                        Incluido = DateTime.Parse("1955-1-1"),
                        Locado = true,
                        LocadoEm = DateTime.Parse("1900-1-1")
                    },
                    new Catalogo
                    {
                        Titulo = "Memórias do Cárcere",
                        Ativo = true,
                        Genero = "Drama",
                        Preco = 17.99M,
                        Incluido = DateTime.Parse("1984-1-1"),
                        Locado = true,
                        LocadoEm = DateTime.Parse("1900-1-1")
                    },
                    new Catalogo
                    {
                        Titulo = "Tropa de Elite",
                        Ativo = true,
                        Genero = "Policial",
                        Preco = 27.99M,
                        Incluido = DateTime.Parse("2007-1-1"),
                        Locado = true,
                        LocadoEm = DateTime.Parse("1900-1-1")
                    },
                    new Catalogo
                    {
                        Titulo = "Toda Nudez Será Castigada",
                        Ativo = true,
                        Genero = "Drama",
                        Preco = 37.99M,
                        Incluido = DateTime.Parse("1973-1-1"),
                        Locado = true,
                        LocadoEm = DateTime.Parse("1900-1-1")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
