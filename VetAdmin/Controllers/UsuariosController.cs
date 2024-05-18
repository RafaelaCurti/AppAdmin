using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VetAdmin.Context;
using VetAdmin.Models;
using VetAdmin.Repositories;

namespace VetAdmin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : Controller
    {
        private readonly UsuarioRepository _context;

        public UsuariosController(UsuarioRepository context)
        {
            _context = context;
        }
        ///  <sumary>
        ///  Método Index que retornará a lista de todos os usuários
        ///  </sumary>
        ///  <returns></returns>

        // GET: Usuario
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(await _context.Listar());
        }

        // GET: Usuario/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var usuario = await _context.BuscarPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }
        [HttpGet]
        // GET: Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Login,Senha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.InlcuirUsuario(usuario);
                await _context.SalvarAssincrono();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var usuario = await _context.BuscarPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Login,Senha")] Usuario usuario)
        {
            //if (id != usuario.Id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
                    _context.Alterar(usuario);
                    await _context.SalvarAssincrono();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!UsuarioExists(usuario.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _context.BuscarPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpDelete, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.BuscarPorId(id);
            _context.Excluir(usuario);
            await _context.SalvarAssincrono();
            return RedirectToAction(nameof(Index));
        }

        //private bool UsuarioExists(int id)
        //{
        //    return Ok(_context.BuscarPorId(id).Any());
        //}
        // GET: Usuario/BuscarUsuarios/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> BuscarUsuarios()
        {
            return Ok(await _context.Listar());
        }
    }
}
