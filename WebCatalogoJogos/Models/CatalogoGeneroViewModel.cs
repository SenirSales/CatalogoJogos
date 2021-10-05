using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;


namespace WebCatalogoJogos.Models
{
    public class CatalogoGeneroViewModel
    {
        public List<Catalogo> Catalogos { get; set; }
        public SelectList Generos { get; set; }
        public string CatalogoGenero { get; set; }
        public string SearchString { get; set; }
    }
}
