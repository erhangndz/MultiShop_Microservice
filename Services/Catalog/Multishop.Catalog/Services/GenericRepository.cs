using MongoDB.Bson;
using MongoDB.Driver;
using Multishop.Catalog.Entities;
using Multishop.Catalog.Settings;

namespace Multishop.Catalog.Services
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IMongoCollection<T> _collection;

        public GenericRepository(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<T>(typeof(T).Name.ToLowerInvariant());
        }

        public async Task CreateAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.FindOneAndDeleteAsync(x => x.Id == id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _collection.AsQueryable().ToListAsync();
        }

        

        public async Task<T> GetByIdAsync(string id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        }

        public async Task<long> GetCountAsync()
        {
            return await _collection.CountDocumentsAsync(x=>true);
        }

        public async Task UpdateAsync(T entity)
        {
            await _collection.FindOneAndReplaceAsync(x => x.Id == entity.Id, entity);
        }
    }
}
