using AluraDev.Domain.Interfaces;
using AluraDev.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AluraDev.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoService _projetoService;

        public ProjetoController(IProjetoService projetoService)
        {
            _projetoService = projetoService;
        }

        [HttpGet]
        public async Task<List<Projeto>> Get()
        {
            return await _projetoService.GetAsync();
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Projeto>> Get(string id)
        {
            var projeto = await _projetoService.GetAsync(id);

            if (projeto is null)
                return NotFound();

            return projeto;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Projeto newProjeto)
        {
            await _projetoService.CreateAsync(newProjeto);

            return CreatedAtAction(nameof(Get), new { id = newProjeto.Id }, newProjeto);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Projeto updatedProjeto)
        {
            var Projeto = await _projetoService.GetAsync(id);

            if (Projeto is null)
                return NotFound();

            updatedProjeto.Id = Projeto.Id;

            await _projetoService.UpdateAsync(id, updatedProjeto);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _projetoService.GetAsync(id);

            if (book is null)
                return NotFound();

            await _projetoService.RemoveAsync(id);

            return NoContent();
        }
    }
}
