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
    public class DesignerRepository : IDesignerRepository
    {
        private IGateway _gateway;
        private string _collectionName = "Designer";

        public DesignerRepository(IGateway gateway)
        {
            _gateway = gateway;
        }
        public IEnumerable<Designer> GetAll()
        {
            var result = _gateway.GetMongoDB().GetCollection<Designer>(_collectionName)
                            .Find(new BsonDocument())
                            .ToList();
            return result;
        }

        public bool Save(Designer entity)
        {
            _gateway.GetMongoDB().GetCollection<Designer>(_collectionName)
                .InsertOne(entity);
            return true;
        }

        public Designer Update(string id, Designer entity)
        {
            var update = Builders<Designer>.Update
                .Set(e => e.name, entity.name );

            var result = _gateway.GetMongoDB().GetCollection<Designer>(_collectionName)
                .FindOneAndUpdate(e => e.Id == id, update);
            return result;
        }

        public bool Delete(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<Designer>(_collectionName)
                         .DeleteOne(e => e.Id == id);
            return result.IsAcknowledged;
        }
    }
}
