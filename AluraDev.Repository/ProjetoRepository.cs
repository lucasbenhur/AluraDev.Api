using AluraDev.Data;
using AluraDev.Domain.Interfaces;
using AluraDev.Domain.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AluraDev.Repository
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly IMongoCollection<Projeto> _projetoCollection;

        public ProjetoRepository(
            IOptions<AluraDevDataSettings> aluraDevDataSettings)
        {
            var mongoClient = new MongoClient(
                aluraDevDataSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                aluraDevDataSettings.Value.DatabaseName);

            _projetoCollection = mongoDatabase.GetCollection<Projeto>(
                aluraDevDataSettings.Value.ProjetoCollectionName);
        }

        public async Task<List<Projeto>> GetAsync()
        {
            return await _projetoCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Projeto?> GetAsync(string id)
        {
            return await _projetoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Projeto newProjeto)
        {
            await _projetoCollection.InsertOneAsync(newProjeto);
        }

        public async Task UpdateAsync(string id, Projeto updatedProjeto)
        {
            await _projetoCollection.ReplaceOneAsync(x => x.Id == id, updatedProjeto);
        }

        public async Task RemoveAsync(string id)
        {
            await _projetoCollection.DeleteOneAsync(x => x.Id == id);
        }
    }
}