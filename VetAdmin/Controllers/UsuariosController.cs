using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using VetAdmin.Interfaces;
using VetAdmin.Models;

namespace VetAdmin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepository _context;

        public UsuariosController(IUsuarioRepository context)
        {
            _context = context;
        }
        /////  <sumary>
        /////  Método Index que retornará a lista de todos os usuários
        /////  </sumary>
        /////  <returns></returns>

        //// GET: Usuario
        //[HttpGet]
        //[Route("Index")]
        //public async Task<ActionResult> Index()
        //{
        //    return View(await _context.Listar());
        //}

        //// GET: Usuario/Details/5
        //[HttpGet]
        //[Route("Detalhar")]
        //public async Task<IActionResult> Details(int id)
        //{
        //    var usuario = await _context.BuscarPorId(id);
        //    if (usuario == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(usuario);
        //}
        //[HttpGet]
        //[Route("Criar")]
        //// GET: Usuario/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Usuario/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        ////[ValidateAntiForgeryToken]
        //[Route("Criar")]
        //public async Task<IActionResult> Create([Bind("Id,Login,Senha")] Usuario usuario)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.InlcuirUsuario(usuario);
        //        await _context.SalvarAssincrono();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(usuario);
        //}

        //// GET: Usuario/Edit/5
        //[HttpGet]
        //[Route("Editar")]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var usuario = await _context.BuscarPorId(id);
        //    if (usuario == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(usuario);
        //}

        //// POST: Usuario/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPut]
        ////[ValidateAntiForgeryToken]
        //[Route("Editar")]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Login,Senha")] Usuario usuario)
        //{
        //    //if (id != usuario.Id)
        //    //{
        //    //    return NotFound();
        //    //}

        //    //if (ModelState.IsValid)
        //    //{
        //    //    try
        //    //    {
        //            _context.Alterar(usuario);
        //            await _context.SalvarAssincrono();
        //    //    }
        //    //    catch (DbUpdateConcurrencyException)
        //    //    {
        //    //        if (!UsuarioExists(usuario.Id))
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
        //    return View(usuario);
        //}

        //// GET: Usuario/Delete/5
        //[HttpGet]
        //[Route("Deletar")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var usuario = await _context.BuscarPorId(id);
        //    if (usuario == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(usuario);
        //}

        //// POST: Usuario/Delete/5
        //[HttpDelete, ActionName("Delete")]
        ////[ValidateAntiForgeryToken]
        //[Route("Deletar")]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var usuario = await _context.BuscarPorId(id);
        //    _context.Excluir(usuario);
        //    await _context.SalvarAssincrono();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool UsuarioExists(int id)
        //{
        //    return Ok(_context.BuscarPorId(id).Any());
        //}
        // GET: Usuario/BuscarUsuarios/




        /////  <sumary>
        /////  Método para buscar todos os usuários cadastrados.
        /////  </sumary>
        /////  <returns></returns>
        [HttpGet]
        [Route("BuscarTodos")]
        public async Task<ActionResult<IEnumerable<Usuario>>> BuscarUsuarios()
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            var usuarios = await _context.Listar();
            return Ok(JsonSerializer.Serialize(usuarios, options));
        }


        ///  <sumary>
        ///  Método para criar usuário.
        ///  </sumary>
        ///  <param name="value"></param>
        ///  <returns> Persistência do Usuário no Banco de Dados</returns>
        ///  <response code="200">Returna mensagem de sucesso para o Cadastramento de Usuário</response>
        [HttpPost]
        [Route("CadastrarUsuario")]
        public async Task<ActionResult> CadastrarUsuario(Usuario usuario)
        {
            _context.InlcuirUsuario(usuario);
            if (await _context.SalvarAssincrono())
            {
                return Ok("Usuário cadastrado com sucesso!");
            }
            else
            {
                // Crie um dicionário para armazenar as mensagens de erro personalizadas
                Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();

                // Percorra todos os erros de validação no ModelState e adicione-os ao dicionário
                foreach (var key in ModelState.Keys)
                {
                    if (ModelState[key].Errors.Count > 0)
                    {
                        List<string> errorMessages = new List<string>();
                        foreach (var error in ModelState[key].Errors)
                        {
                            errorMessages.Add(error.ErrorMessage);
                        }
                        errors.Add(key, errorMessages);
                    }
                }

                // Retorne uma resposta 200 com as mensagens de erro personalizadas
                return Ok(new { errors });
            }
        }
    }
}
