using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExemploRelatorio.Models;

namespace ExemploRelatorio.Controllers
{
    public class PrescricaoController : Controller
    {
        private readonly Contexto _context;

        public PrescricaoController(Contexto context)
        {
            _context = context;
        }

        // GET: Prescricao
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Prescricao.Include(p => p.Consulta).Include(p => p.Medicamento);
            return View(await contexto.ToListAsync());
        }

        // GET: Prescricao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Prescricao == null)
            {
                return NotFound();
            }

            var prescricao = await _context.Prescricao
                .Include(p => p.Consulta)
                .Include(p => p.Medicamento)
                .FirstOrDefaultAsync(m => m.PrescricaoId == id);
            if (prescricao == null)
            {
                return NotFound();
            }

            return View(prescricao);
        }

        // GET: Prescricao/Create
        public IActionResult Create()
        {
            ViewData["ConsultaId"] = new SelectList(_context.Consulta, "ConsultaId", "ConsultaId");
            ViewData["MedicamentoId"] = new SelectList(_context.Medicamento, "MedicamentoId", "MedicamentoId");
            return View();
        }

        // POST: Prescricao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrescricaoId,ConsultaId,MedicamentoId,Posologia")] Prescricao prescricao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prescricao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConsultaId"] = new SelectList(_context.Consulta, "ConsultaId", "ConsultaId", prescricao.ConsultaId);
            ViewData["MedicamentoId"] = new SelectList(_context.Medicamento, "MedicamentoId", "MedicamentoId", prescricao.MedicamentoId);
            return View(prescricao);
        }

        // GET: Prescricao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Prescricao == null)
            {
                return NotFound();
            }

            var prescricao = await _context.Prescricao.FindAsync(id);
            if (prescricao == null)
            {
                return NotFound();
            }
            ViewData["ConsultaId"] = new SelectList(_context.Consulta, "ConsultaId", "ConsultaId", prescricao.ConsultaId);
            ViewData["MedicamentoId"] = new SelectList(_context.Medicamento, "MedicamentoId", "MedicamentoId", prescricao.MedicamentoId);
            return View(prescricao);
        }

        // POST: Prescricao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrescricaoId,ConsultaId,MedicamentoId,Posologia")] Prescricao prescricao)
        {
            if (id != prescricao.PrescricaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prescricao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrescricaoExists(prescricao.PrescricaoId))
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
            ViewData["ConsultaId"] = new SelectList(_context.Consulta, "ConsultaId", "ConsultaId", prescricao.ConsultaId);
            ViewData["MedicamentoId"] = new SelectList(_context.Medicamento, "MedicamentoId", "MedicamentoId", prescricao.MedicamentoId);
            return View(prescricao);
        }

        // GET: Prescricao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Prescricao == null)
            {
                return NotFound();
            }

            var prescricao = await _context.Prescricao
                .Include(p => p.Consulta)
                .Include(p => p.Medicamento)
                .FirstOrDefaultAsync(m => m.PrescricaoId == id);
            if (prescricao == null)
            {
                return NotFound();
            }

            return View(prescricao);
        }

        // POST: Prescricao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Prescricao == null)
            {
                return Problem("Entity set 'Contexto.Prescricao'  is null.");
            }
            var prescricao = await _context.Prescricao.FindAsync(id);
            if (prescricao != null)
            {
                _context.Prescricao.Remove(prescricao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrescricaoExists(int id)
        {
          return (_context.Prescricao?.Any(e => e.PrescricaoId == id)).GetValueOrDefault();
        }
    }
}
