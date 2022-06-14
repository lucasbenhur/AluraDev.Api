using AluraDev.Domain.Models;

namespace AluraDev.Domain.Interfaces
{
    public interface IProjetoService
    {
        public Task<List<Projeto>> GetAsync();
        public Task<Projeto?> GetAsync(string id);
        public Task CreateAsync(Projeto newProjeto);
        public Task UpdateAsync(string id, Projeto updatedProjeto);
        public Task RemoveAsync(string id);
        public bool IsValid(Projeto projeto);
    }
}
