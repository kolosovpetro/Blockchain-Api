using System.Collections.Generic;
using System.Threading.Tasks;
using BlockchainAPI.Repository.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BlockchainAPI.Repository.BaseRepository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
    {
        private readonly IMongoCollection<TEntity> _collection;

        protected BaseRepository(string connectionString)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(typeof(TEntity).Name);
            _collection = database.GetCollection<TEntity>(typeof(TEntity).Name);
        }
        
        public async Task Insert(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task<bool> Update(ObjectId id, string updateFieldName, string updateFieldValue)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", id);
            var update = Builders<TEntity>.Update.Set(updateFieldName, updateFieldValue);
            var result = await _collection.UpdateOneAsync(filter, update);
            return result.ModifiedCount != 0;
        }

        public async Task<bool> Delete(ObjectId id)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", id);
            var result = await _collection.DeleteOneAsync(filter);
            return result.DeletedCount != 0;
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _collection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<List<TEntity>> GetByFieldValue(string field, string value)
        {
            var filter = Builders<TEntity>.Filter.Eq(field, value);
            var result = await _collection.Find(filter).ToListAsync();
            return result;
        }
    }
}