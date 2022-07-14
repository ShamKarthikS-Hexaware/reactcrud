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
    public class PlayerRepository : IPlayerRepository
    {
        private IGateway _gateway;
        private string _collectionName = "Player";

        public PlayerRepository(IGateway gateway)
        {
            _gateway = gateway;
        }
        public IEnumerable<Player> GetAll()
        {
            var result = _gateway.GetMongoDB().GetCollection<Player>(_collectionName)
                            .Find(new BsonDocument())
                            .ToList();
            return result;
        }

        public bool Save(Player entity)
        {
            _gateway.GetMongoDB().GetCollection<Player>(_collectionName)
                .InsertOne(entity);
            return true;
        }

        public Player Update(string id, Player entity)
        {
            var update = Builders<Player>.Update
                .Set(e => e.name, entity.name );

            var result = _gateway.GetMongoDB().GetCollection<Player>(_collectionName)
                .FindOneAndUpdate(e => e.Id == id, update);
            return result;
        }

        public bool Delete(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<Player>(_collectionName)
                         .DeleteOne(e => e.Id == id);
            return result.IsAcknowledged;
        }
    }
}
