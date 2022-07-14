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
    public class CompanyRepository : ICompanyRepository
    {
        private IGateway _gateway;
        private string _collectionName = "Company";

        public CompanyRepository(IGateway gateway)
        {
            _gateway = gateway;
        }
        public IEnumerable<Company> GetAll()
        {
            var result = _gateway.GetMongoDB().GetCollection<Company>(_collectionName)
                            .Find(new BsonDocument())
                            .ToList();
            return result;
        }

        public bool Save(Company entity)
        {
            _gateway.GetMongoDB().GetCollection<Company>(_collectionName)
                .InsertOne(entity);
            return true;
        }

        public Company Update(string id, Company entity)
        {
            var update = Builders<Company>.Update
                .Set(e => e.name, entity.name );

            var result = _gateway.GetMongoDB().GetCollection<Company>(_collectionName)
                .FindOneAndUpdate(e => e.Id == id, update);
            return result;
        }

        public bool Delete(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<Company>(_collectionName)
                         .DeleteOne(e => e.Id == id);
            return result.IsAcknowledged;
        }
    }
}
