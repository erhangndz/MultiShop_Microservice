using MongoDB.Driver;
using Multishop.Catalog.Entities;
using Multishop.Catalog.Settings;
using SharpCompress.Common;

namespace Multishop.Catalog.Services.FeatureSliderServices
{
    public class FeatureSliderService :  IFeatureSliderService
    {
        private readonly IMongoCollection<FeatureSlider> _featureCollection;

        public FeatureSliderService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _featureCollection = database.GetCollection<FeatureSlider>(typeof(FeatureSlider).Name.ToLowerInvariant());
        }

        public async Task CreateAsync(FeatureSlider entity)
        {
           await  _featureCollection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
          await _featureCollection.FindOneAndDeleteAsync(x=>x.Id==id);
        }

        public async Task DontShowOnHomeAsync(string id)
        {
            var value = await _featureCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            value.IsShown = false;
            await _featureCollection.FindOneAndReplaceAsync(x => x.Id == id, value);
        }

        public async Task<List<FeatureSlider>> GetAllAsync()
        {
           return await _featureCollection.AsQueryable().ToListAsync();
        }

        public Task<decimal> GetAvgValueAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<FeatureSlider> GetByIdAsync(string id)
        {
            return await _featureCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task<long> GetCountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task ShowOnHomeAsync(string id)
        {
           var value = await _featureCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            value.IsShown = true;
            await _featureCollection.FindOneAndReplaceAsync(x => x.Id == id, value);
        }

        public async Task UpdateAsync(FeatureSlider entity)
        {
            await _featureCollection.FindOneAndReplaceAsync(x => x.Id == entity.Id, entity);
        }
    }
}
