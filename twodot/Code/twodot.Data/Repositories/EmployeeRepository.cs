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
    public class EmployeeRepository : IEmployeeRepository
    {
        private IGateway _gateway;
        private string _collectionName = "Employee";

        public EmployeeRepository(IGateway gateway)
        {
            _gateway = gateway;
        }
        public IEnumerable<Employee> GetAll()
        {
            var result = _gateway.GetMongoDB().GetCollection<Employee>(_collectionName)
                            .Find(new BsonDocument())
                            .ToList();
            return result;
        }

        public bool Save(Employee entity)
        {
            _gateway.GetMongoDB().GetCollection<Employee>(_collectionName)
                .InsertOne(entity);
            return true;
        }

        public Employee Update(string id, Employee entity)
        {
            var update = Builders<Employee>.Update
                .Set(e => e.name, entity.name );

            var result = _gateway.GetMongoDB().GetCollection<Employee>(_collectionName)
                .FindOneAndUpdate(e => e.Id == id, update);
            return result;
        }

        public bool Delete(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<Employee>(_collectionName)
                         .DeleteOne(e => e.Id == id);
            return result.IsAcknowledged;
        }
    }
}
