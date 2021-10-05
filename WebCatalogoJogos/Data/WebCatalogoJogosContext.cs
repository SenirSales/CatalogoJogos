using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebCatalogoJogos.Models;

namespace WebCatalogoJogos.Data
{
    public class WebCatalogoJogosContext : DbContext
    {
        public WebCatalogoJogosContext (DbContextOptions<WebCatalogoJogosContext> options)
            : base(options)
        {
        }

        public DbSet<WebCatalogoJogos.Models.Catalogo> Catalogo { get; set; }
    }
}
