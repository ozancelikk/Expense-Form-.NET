using Core.Entities;
using Core.Entities.Concrete;
using Core.Entities.Concrete.MongoDB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.DataAccess.Databases.MongoDB
{
    public class MongoDB_RepositoryWithSpecificCollectionBase<TEntity, MongoDBUsedDeviceDataContext> : IDisposable, IEntityRepositoryWithSpecificCollection<TEntity>
           where TEntity : class, IEntity, new()
       where MongoDBUsedDeviceDataContext : class, IMongoDB_RawLogContext<TEntity>, new()
    {

        public IMongoCollection<TEntity> _collection { get; set; }
        private IMongoDatabase database;
        public MongoDB_RepositoryWithSpecificCollectionBase()
        {

            MongoDBUsedDeviceDataContext mongoDBContext = new MongoDBUsedDeviceDataContext();
            database = mongoDBContext.GetMongoDBDatabase() ;
        }

        /*-------------------------------------------------------------------------------------------------------------*/
        public void CreateConnectionWithCollectionName(string collectionName)
        {
            _collection = database.GetCollection<TEntity>(collectionName);
        }

        /*-------------------------------------------------------------------------------------------------------------*/
        public void Add(TEntity entity)
        {
            _collection.InsertOne(entity);
        }

        /*-------------------------------------------------------------------------------------------------------------*/
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {

            return _collection.Find<TEntity>(filter).Sort("{_id:-1}").FirstOrDefault();
        }
        /*-------------------------------------------------------------------------------------------------------------*/

        public List<TEntity> GetAllByRegexFilter(List<MongoDBFilter> filters, int page, int limit)
        {
            List<FilterDefinition<TEntity>> filterDefinitions = new List<FilterDefinition<TEntity>>();
            foreach (var filter in filters)
            {
                filterDefinitions.Add(Builders<TEntity>.Filter.Regex(filter.Field, new BsonRegularExpression(".*" + filter.Filter + ".*")));
            }
            if (filterDefinitions.Count == 0)
            {
                return _collection.Find<TEntity>(document => true).Sort("{_id:-1}").Skip((page - 1) * limit).Limit(limit).ToList();
            }
            else
            {
                var filter2 = Builders<TEntity>.Filter.And(filterDefinitions);
                return _collection.Find<TEntity>(filter2).Sort("{_id:-1}").Skip((page - 1) * limit).Limit(limit).ToList();
            }
           


        }
        /*-------------------------------------------------------------------------------------------------------------*/
        public TEntity GetByRegexFilter(List<MongoDBFilter> filters)
        {
            List<FilterDefinition<TEntity>> filterDefinitions = new List<FilterDefinition<TEntity>>();
            foreach (var filter in filters)
            {
             
                    filterDefinitions.Add(Builders<TEntity>.Filter.Regex(filter.Field, new BsonRegularExpression(".*" + filter.Filter + ".*")));
               
            }
            var filterDefination = Builders<TEntity>.Filter.And(filterDefinitions);
            return _collection.Find<TEntity>(filterDefination).Sort("{_id: -1}").FirstOrDefault();
        }
        /*-------------------------------------------------------------------------------------------------------------*/

        public TEntity GetByFilter(List<MongoDBFilter> filters)
        {
              var filterDefinitions = new List<FilterDefinition<TEntity>>();
                {
                    foreach (var filter in filters)
                        filterDefinitions.Add(Builders<TEntity>.Filter.Regex(filter.Field, new BsonRegularExpression(".*" + filter.Filter + ".*")));
                }
              var filterDefinition = Builders<TEntity>.Filter.And( filterDefinitions);
                var collection = _collection;
                return collection.Find<TEntity>(filterDefinition).Sort("{_id: -1}").FirstOrDefault();

        }
        /*-------------------------------------------------------------------------------------------------------------*/



        public List<TEntity> GetAllByFilter(List<MongoDBFilter> filters)
        {
            var filterDefinitions = new List<FilterDefinition<TEntity>>();
            {
                foreach (var filter in filters)
                    filterDefinitions.Add(Builders<TEntity>.Filter.Regex(filter.Field, new BsonRegularExpression(".*" + filter.Filter + ".*")));
            }
            var filterDefinition = Builders<TEntity>.Filter.And(filterDefinitions);
            var collection = _collection;
            return collection.Find<TEntity>(filterDefinition).Sort("{_id: -1}").ToList();

        }
        /*-------------------------------------------------------------------------------------------------------------*/

        public List<TEntity> GetAll(int page, int limit, Expression<Func<TEntity, bool>> filter = null)
        {
            try
            {
                return filter == null
            ? _collection.Find<TEntity>(document => true).Sort("{_id:-1}").Skip((page - 1) * limit).Limit(limit).ToList()
            : _collection.Find<TEntity>(filter).Sort("{_id:-1}").Skip((page - 1) * limit).Limit(limit).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /*-------------------------------------------------------------------------------------------------------------*/

        public void UpdateMany(List<MongoDBUpdate> mongoDBUpdates, List<MongoDBFilter> mongoDBFilters)
        {
            List<UpdateDefinition<TEntity>> updateDefination = new List<UpdateDefinition<TEntity>>();
            List<FilterDefinition<TEntity>> filterDefinitions = new List<FilterDefinition<TEntity>>();

            foreach (var mongoDBUpdate in mongoDBUpdates)
            {
                updateDefination.Add(Builders<TEntity>.Update.Set(mongoDBUpdate.Field, mongoDBUpdate.NewValue));
            }

            foreach (var filter in mongoDBFilters)
            {
                if (filter.Filter.GetType() == typeof(bool))
                {
                    filterDefinitions.Add(Builders<TEntity>.Filter.Eq(filter.Field, filter.Filter));
                }
                else
                {
                    filterDefinitions.Add(Builders<TEntity>.Filter.Eq(filter.Field, filter.Filter));
                }
            }

            var combinedUpdate = Builders<TEntity>.Update.Combine(updateDefination);
            var filterDefinition = Builders<TEntity>.Filter.And(filterDefinitions);
            var a = _collection.UpdateMany(filterDefinition, combinedUpdate);

        }
        /*-------------------------------------------------------------------------------------------------------------*/

        public void UpdateManyWitRegexFilter(List<MongoDBUpdate> mongoDBUpdates, List<MongoDBFilter> mongoDBFilters)
        {
            List<UpdateDefinition<TEntity>> updateDefination = new List<UpdateDefinition<TEntity>>();
            List<FilterDefinition<TEntity>> filterDefinitions = new List<FilterDefinition<TEntity>>();

            foreach (var mongoDBUpdate in mongoDBUpdates)
            {
                updateDefination.Add(Builders<TEntity>.Update.Set(mongoDBUpdate.Field, mongoDBUpdate.NewValue));
            }

            foreach (var filter in mongoDBFilters)
            {
                if (filter.Filter.GetType() == typeof(bool))
                {
                    filterDefinitions.Add(Builders<TEntity>.Filter.Eq(filter.Field, filter.Filter));
                }
                else
                {
                    filterDefinitions.Add(Builders<TEntity>.Filter.Regex(filter.Field, new BsonRegularExpression(".*" + filter.Filter + ".*")));
                }
            }

            var combinedUpdate = Builders<TEntity>.Update.Combine(updateDefination);
            var filterDefinition = Builders<TEntity>.Filter.And(filterDefinitions);
            var a = _collection.UpdateMany(filterDefinition, combinedUpdate);
            Console.WriteLine(a.MatchedCount);

        }
        /*-------------------------------------------------------------------------------------------------------------*/

        public void UpdateWithAggregation(PipelineDefinition<TEntity, TEntity> pipeline)
        {
            var result = _collection.UpdateMany(new BsonDocument(), pipeline);
        }
        /*-------------------------------------------------------------------------------------------------------------*/

        public long EstimatedDocumentCount()
        {var t  = _collection.EstimatedDocumentCount();
            return _collection.EstimatedDocumentCount();
        }
        /*-------------------------------------------------------------------------------------------------------------*/
        public void CreateIndex(Expression<Func<TEntity, object>> field)
        {
            var indexKeysDefinition = Builders<TEntity>.IndexKeys.Ascending(field);
            _collection.Indexes.CreateOneAsync(new CreateIndexModel<TEntity>(indexKeysDefinition));

        }
        /*-------------------------------------------------------------------------------------------------------------*/
        public void DropIndex(string indexName)
        {
            _collection.Indexes.DropOne(indexName);
        }
        /*-------------------------------------------------------------------------------------------------------------*/
        public List<MongoDBIndex> IndexList()
        {

            var response = _collection.Indexes.List().ToList();
            List<MongoDBIndex> indexes = new List<MongoDBIndex>();
            foreach (var index in response)
            {

                indexes.Add(BsonSerializer.Deserialize<MongoDBIndex>(index));
            }
            return indexes;

        }
        /*-------------------------------------------------------------------------------------------------------------*/

        public ReplaceOneResult Update(TEntity entity)
        {
            return _collection.ReplaceOne(e => e.Id == entity.Id, entity);
        }
        /*-------------------------------------------------------------------------------------------------------------*/

        public List<TEntity> GenerateAggregate(PipelineDefinition<TEntity, TEntity> pipeline)
        {
            return _collection.Aggregate(pipeline, new AggregateOptions { AllowDiskUse = true }).ToList();
        }
        /*-------------------------------------------------------------------------------------------------------------*/

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        /*-------------------------------------------------------------------------------------------------------------*/

    }
}
