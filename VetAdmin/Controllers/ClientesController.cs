using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VetAdmin.Context;
using VetAdmin.Models;

namespace VetAdmin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        //// GET: Clientes
        //[HttpGet]
        //[Route("Index")]
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Cliente.ToListAsync());
        //}
        //// GET: Clientes/Details/5
        //[HttpGet]
        //[Route("Detalhar")]
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var cliente = await _context.Cliente
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (cliente == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(cliente);
        //}
        //[HttpGet]
        //[Route("Criar")]
        //// GET: Clientes/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Clientes/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Route("Criar")]
        //public async Task<IActionResult> Create([Bind("Id,Profissao,CanalDeComunicacaoEscolhido,CEP")] Cliente cliente)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(cliente);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(cliente);
        //}
        //[HttpGet]
        //[Route("Editar")]
        //// GET: Clientes/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var cliente = await _context.Cliente.FindAsync(id);
        //    if (cliente == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(cliente);
        //}

        //// POST: Clientes/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPut]
        //[ValidateAntiForgeryToken]
        //[Route("Editar")]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Profissao,CanalDeComunicacaoEscolhido,CEP")] Cliente cliente)
        //{
        //    if (id != cliente.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(cliente);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ClienteExists(cliente.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(cliente);
        //}
        //[HttpGet]
        //[Route("Deletar")]
        //// GET: Clientes/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var cliente = await _context.Cliente
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (cliente == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(cliente);
        //}

        //// POST: Clientes/Delete/5
        //[HttpDelete, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //[Route("Deletar")]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var cliente = await _context.Cliente.FindAsync(id);
        //    _context.Cliente.Remove(cliente);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
        //[HttpGet]
        //[Route("ExistirCliente")]
        //private bool ClienteExists(int id)
        //{
        //    return _context.Cliente.Any(e => e.Id == id);
        //}
    }
}
