using Core.Entities;
using Core.Entities.Concrete;
using Core.Entities.Concrete.MongoDB;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.DataAccess.Databases
{
    public interface IEntityRepositoryWithSpecificCollection<T> where T : class, IEntity, new()
    {
        void UpdateMany(List<MongoDBUpdate> mongoDBUpdates, List<MongoDBFilter> mongoDBFilters);
        void UpdateManyWitRegexFilter(List<MongoDBUpdate> mongoDBUpdates, List<MongoDBFilter> mongoDBFilters);
        void UpdateWithAggregation(PipelineDefinition<T, T> pipeline);
        List<T> GetAll(int page, int limit, Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        ReplaceOneResult Update(T entity);
        List<T> GetAllByRegexFilter(List<MongoDBFilter> filter, int page, int limit);
        T GetByFilter(List<MongoDBFilter> filters);
        T GetByRegexFilter(List<MongoDBFilter> filters);
        void CreateConnectionWithCollectionName(string collectionName);
        List<T> GenerateAggregate(PipelineDefinition<T, T> pipeline);
        List<T> GetAllByFilter(List<MongoDBFilter> filters);
        long EstimatedDocumentCount();
        void CreateIndex(Expression<Func<T, object>> field);
        void DropIndex(string indexName);
        List<MongoDBIndex> IndexList();

    }
}
