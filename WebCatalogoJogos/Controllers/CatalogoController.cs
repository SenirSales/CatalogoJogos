using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCatalogoJogos.Data;
using WebCatalogoJogos.Models;

namespace WebCatalogoJogos.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly WebCatalogoJogosContext _context;

        public CatalogoController(WebCatalogoJogosContext context)
        {
            _context = context;
        }

        // GET: Catalogo/Index
        public async Task<IActionResult> Index(string catalogoGenero, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> generoQuery = from m in _context.Catalogo
                                            orderby m.Genero
                                            select m.Genero;

            var catalogos = from m in _context.Catalogo
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                catalogos = catalogos.Where(s => s.Titulo.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(catalogoGenero))
            {
                catalogos = catalogos.Where(x => x.Genero == catalogoGenero);
            }

            var movieGenreVM = new CatalogoGeneroViewModel
            {
                Generos = new SelectList(await generoQuery.Distinct().ToListAsync()),
                Catalogos = await catalogos.ToListAsync()
            };

            return View(movieGenreVM);
        }
        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }
        // GET: Catalogo/Detail
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogo = await _context.Catalogo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalogo == null)
            {
                return NotFound();
            }

            return View(catalogo);
        }

        // GET: Catalogo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Catalogo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Ativo,Genero,Preco,Incluido,Locado,LocadoEm")] Catalogo catalogo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catalogo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catalogo);
        }

        // GET: Catalogo/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogo = await _context.Catalogo.FindAsync(id);
            if (catalogo == null)
            {
                return NotFound();
            }
            return View(catalogo);
        }

        // POST: Catalogo/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Ativo,Genero,Preco,Incluido,Locado,LocadoEm")] Catalogo catalogo)
        {
            if (id != catalogo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalogo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogoExists(catalogo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(catalogo);
        }

        // GET: Catalogo/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogo = await _context.Catalogo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalogo == null)
            {
                return NotFound();
            }

            return View(catalogo);
        }

        // POST: Catalogo/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catalogo = await _context.Catalogo.FindAsync(id);
            _context.Catalogo.Remove(catalogo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogoExists(int id)
        {
            return _context.Catalogo.Any(e => e.Id == id);
        }
    }
}
