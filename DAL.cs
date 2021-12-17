using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPCapstone
{
    public class DAL
    {
        const string DATABASE_NAME = "ACDatabase";
        const string CONNECTION_STRING = "mongodb+srv://farrert:MongoDB@cluster0.bbksn.mongodb.net/cluster0?retryWrites=true&w=majority";

        const string COLLECTION_NAME = "ACTasks";
    }
    public class MongoConnect
    {
        public IMongoDatabase db;
         public MongoConnect(string databaseName, string connectionString)
        {
            MongoClient dbClient = new MongoClient(connectionString);
            db = dbClient.GetDatabase(databaseName);
        }
    }
}
