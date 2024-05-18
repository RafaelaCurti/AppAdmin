using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VetAdmin.Context;
using VetAdmin.Interfaces;
using VetAdmin.Models;

namespace VetAdmin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionariosController : Controller
    {
        private readonly IFuncionarioRepository _context;

        public FuncionariosController(IFuncionarioRepository context)
        {
            _context = context;
        }

        //// GET: Funcionarios
        //[HttpGet]
        //[Route("Index")]
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Listar());
        //}

        //// GET: Funcionarios/Details/5
        //[HttpGet]
        //[Route("Detalhar")]
        //public async Task<IActionResult> Details(int id)
        //{
        //    var funcionario = await _context.BuscarPorId(id);
        //    if (funcionario == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(funcionario);
        //}

        //// GET: Funcionarios/Create
        //[HttpGet]
        //[Route("Criar")]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Funcionarios/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Route("Criar")]
        //public async Task<IActionResult> Create([Bind("Id,EVeterinario,EAdministrativo,CNPJ,Area,Especialidade")] Funcionario funcionario)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.InlcuirFuncionario(funcionario);
        //        await _context.SalvarAssincrono();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(funcionario);
        //}

        //// GET: Funcionarios/Edit/5
        //[HttpGet]
        //[Route("Editar")]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var funcionario = await _context.BuscarPorId(id);
        //    if (funcionario == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(funcionario);
        //}

        //// POST: Funcionarios/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPut]
        //[ValidateAntiForgeryToken]
        //[Route("Editar")]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,EVeterinario,EAdministrativo,CNPJ,Area,Especialidade")] Funcionario funcionario)
        //{
        //    //if (id != funcionario.Id)
        //    //{
        //    //    return NotFound();
        //    //}

        //    //if (ModelState.IsValid)
        //    //{
        //    //    try
        //    //    {
        //            _context.Alterar(funcionario);
        //            await _context.SalvarAssincrono();
        //        //}
        //    //    catch (DbUpdateConcurrencyException)
        //    //    {
        //    //        if (!FuncionarioExists(funcionario.Id))
        //    //        {
        //    //            return NotFound();
        //    //        }
        //    //        else
        //    //        {
        //    //            throw;
        //    //        }
        //    //    }
        //    //    return RedirectToAction(nameof(Index));
        //    //}
        //    return View(funcionario);
        //}
        //[HttpGet]
        //// GET: Funcionarios/Delete/5
        //[Route("Deletar")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var funcionario = await _context.BuscarPorId(id);
        //    if (funcionario == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(funcionario);
        //}

        //// POST: Funcionarios/Delete/5
        //[HttpDelete, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //[Route("Deletar")]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var funcionario = await _context.BuscarPorId(id);
        //    _context.Excluir(funcionario);
        //    await _context.SalvarAssincrono();
        //    return RedirectToAction(nameof(Index));
        //}
        ////[HttpGet]
        ////[Route("ExistirFuncionario")]
        ////private bool FuncionarioExists(int id)
        ////{
        ////    return _context..Any(e => e.Id == id);
        ////}


        [HttpGet]
        [Route("BuscarFuncionarios")]
        public async Task<ActionResult<IEnumerable<Funcionario>>> BuscarFuncionarios()
        {
            return Ok(await _context.Listar());
        }

        [HttpGet]
        [Route("CadastrarFuncionario")]
        public async Task<ActionResult> CriarFuncionario(Funcionario funcionario)
        {
             _context.InlcuirFuncionario(funcionario);
            if (await _context.SalvarAssincrono())
            {
                return Ok("Funcionário Cadastrado com Sucesso!");
            }
            else {
                return BadRequest("Ocorreu algum erro inesperado.");
            }
        }

    }
}
