using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoAspNetAT.Data;
using ProjetoAspNetAT.Models;

namespace ProjetoAspNetAT.Controllers
{
    public class QuadrinhoesController : Controller
    {
        private readonly ProjetoAspNetATContext _context;

        public QuadrinhoesController(ProjetoAspNetATContext context)
        {
            _context = context;
        }

        // GET: Quadrinhoes
        public async Task<IActionResult> Index()
        {
              return _context.Quadrinho != null ? 
                          View(await _context.Quadrinho.ToListAsync()) :
                          Problem("Entity set 'ProjetoAspNetATContext.Quadrinho'  is null.");
        }

        // GET: Quadrinhoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Quadrinho == null)
            {
                return NotFound();
            }

            var quadrinho = await _context.Quadrinho
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quadrinho == null)
            {
                return NotFound();
            }

            return View(quadrinho);
        }

        // GET: Quadrinhoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Quadrinhoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Autor,Quantidade")] Quadrinho quadrinho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quadrinho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quadrinho);
        }

        // GET: Quadrinhoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Quadrinho == null)
            {
                return NotFound();
            }

            var quadrinho = await _context.Quadrinho.FindAsync(id);
            if (quadrinho == null)
            {
                return NotFound();
            }
            return View(quadrinho);
        }

        // POST: Quadrinhoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Autor,Quantidade")] Quadrinho quadrinho)
        {
            if (id != quadrinho.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quadrinho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuadrinhoExists(quadrinho.Id))
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
            return View(quadrinho);
        }

        // GET: Quadrinhoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Quadrinho == null)
            {
                return NotFound();
            }

            var quadrinho = await _context.Quadrinho
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quadrinho == null)
            {
                return NotFound();
            }

            return View(quadrinho);
        }

        // POST: Quadrinhoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Quadrinho == null)
            {
                return Problem("Entity set 'ProjetoAspNetATContext.Quadrinho'  is null.");
            }
            var quadrinho = await _context.Quadrinho.FindAsync(id);
            if (quadrinho != null)
            {
                _context.Quadrinho.Remove(quadrinho);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuadrinhoExists(int id)
        {
          return (_context.Quadrinho?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
