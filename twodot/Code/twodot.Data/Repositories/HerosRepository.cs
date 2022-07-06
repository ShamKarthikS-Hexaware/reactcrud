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
    public class HerosRepository : IHerosRepository
    {
        private IGateway _gateway;
        private string _collectionName = "Heros";

        public HerosRepository(IGateway gateway)
        {
            _gateway = gateway;
        }
        public IEnumerable<Heros> GetAll()
        {
            var result = _gateway.GetMongoDB().GetCollection<Heros>(_collectionName)
                            .Find(new BsonDocument())
                            .ToList();
            return result;
        }

        public bool Save(Heros entity)
        {
            _gateway.GetMongoDB().GetCollection<Heros>(_collectionName)
                .InsertOne(entity);
            return true;
        }

        public Heros Update(string id, Heros entity)
        {
            var update = Builders<Heros>.Update
                .Set(e => e.name, entity.name );

            var result = _gateway.GetMongoDB().GetCollection<Heros>(_collectionName)
                .FindOneAndUpdate(e => e.Id == id, update);
            return result;
        }

        public bool Delete(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<Heros>(_collectionName)
                         .DeleteOne(e => e.Id == id);
            return result.IsAcknowledged;
        }
    }
}
