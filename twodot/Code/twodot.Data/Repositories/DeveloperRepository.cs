using twodot.Data.Interfaces;
using twodot.Entities.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Bindings;
using System;
using System.Collections.Generic;
using System.Text;

namespace twodot.Data.Repositories
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private IGateway _gateway;
        private string _collectionName = "Developer";

        public DeveloperRepository(IGateway gateway)
        {
            _gateway = gateway;
        }
        public IEnumerable<Developer> GetAll()
        {
            var result = _gateway.GetMongoDB().GetCollection<Developer>(_collectionName)
                            .Find(new BsonDocument())
                            .ToList();
            return result;
        }

        public bool Save(Developer entity)
        {
            _gateway.GetMongoDB().GetCollection<Developer>(_collectionName)
                .InsertOne(entity);
            return true;
        }

        public Developer Update(string id, Developer entity)
        {
            var update = Builders<Developer>.Update
                .Set(e => e.name, entity.name );

            var result = _gateway.GetMongoDB().GetCollection<Developer>(_collectionName)
                .FindOneAndUpdate(e => e.Id == id, update);
            return result;
        }

        public bool Delete(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<Developer>(_collectionName)
                         .DeleteOne(e => e.Id == id);
            return result.IsAcknowledged;
        }
    }
}
