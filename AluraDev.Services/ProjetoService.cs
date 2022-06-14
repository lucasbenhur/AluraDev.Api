using AluraDev.Domain.Interfaces;
using AluraDev.Domain.Models;

namespace AluraDev.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly IProjetoRepository _projetoRepository;

        public ProjetoService(IProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        public async Task<List<Projeto>> GetAsync()
        {
            return await _projetoRepository.GetAsync();
        }

        public async Task<Projeto?> GetAsync(string id)
        {
            return await _projetoRepository.GetAsync(id);
        }

        public async Task CreateAsync(Projeto newProjeto)
        {
            if (IsValid(newProjeto))
                await _projetoRepository.CreateAsync(newProjeto);
            else
                throw new Exception("Projeto Inválido!");
        }

        public async Task UpdateAsync(string id, Projeto updatedProjeto)
        {
            if (IsValid(updatedProjeto))
                await _projetoRepository.UpdateAsync(id, updatedProjeto);
            else
                throw new Exception("Projeto Inválido!");
        }

        public async Task RemoveAsync(string id)
        {
            await _projetoRepository.RemoveAsync(id);
        }

        public bool IsValid(Projeto projeto)
        {
            if (string.IsNullOrEmpty(projeto.Nome) ||
                string.IsNullOrEmpty(projeto.Descricao) ||
                string.IsNullOrEmpty(projeto.Codigo) ||
                string.IsNullOrEmpty(projeto.Cor) ||
                string.IsNullOrEmpty(projeto.Linguagem) ||
                projeto.Usuario is null ||
                string.IsNullOrEmpty(projeto.Usuario.UserName))
                return false;

            return true;
        }
    }
}