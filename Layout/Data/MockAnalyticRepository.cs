using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using System.Configuration;
using MongoDB.Driver.Builders;

namespace Layout.Data
{
    public class MockAnalyticRepository : IRepository
    {
        private readonly string connectionString = ConfigurationManager.AppSettings["connectionString"].ToString();
        private const string databaseName = "promo";
        //private const string TagsCollectionName = "tags";
        //public MongoDatabase Database;

        private MongoClient client { get; set; }
        protected MongoServer server { get; set; }
        protected MongoDatabase database { get; set; }


        public MockAnalyticRepository()
        {
            client = new MongoClient(connectionString);
            server = client.GetServer();
            database = server.GetDatabase(databaseName);
        }


        public List<string> AllTags()
        {
            List<string> list = new List<string>();
           //var query = from a in Analytics.AsQueryable<Domain.Analytic>()
           //        select a.Tags.Distinct();

           //return query.ToList();


            var query = Analytics.Distinct(

            "Tags"

            );

           foreach (var item in query.ToList())
           {
               list.Add(item.ToString());
           }
           return list;
        }

        public List<Domain.Analytic> FindByTag(List<string> tags)
        { 
            //var found = All<Domain.Analytic>().Where
           return Analytics.AsQueryable().Where(a => a.Tags.ContainsAny(tags)).ToList();

        }

        public MongoCollection<Domain.Filter> Filters
        {
            get
            {
                return database.GetCollection <Domain.Filter> ("filters");
            }
        }

        public MongoCollection<Domain.Analytic> Analytics
        {
            get
            {
                return database.GetCollection<Domain.Analytic>("analytics");
            }
        }

        public MongoCollection<Domain.Actions> Actions
        {
            get
            {
                return database.GetCollection<Domain.Actions>("options");
            }
        }

        public MongoCollection<BsonDocument> ActionsAsDocuments
        {
            get
            {
                return database.GetCollection("options");
            }
        }
        public MongoCollection<Domain.Action> Commands
        {
            get
            {
                return database.GetCollection<Domain.Action>("commands");
            }
        }

        public void Save<T>(T item) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public void Add<T>(T item) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T item) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public T Single<T>() where T : class, new()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> All<T>() where T : class, new()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> All<T>(int page, int pageSize) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }


        public List<T> FindByTag<T>(List<string> tags) where T : class, new()
        {
            throw new NotImplementedException();
        }


    }


    public interface IRepository : IDisposable
    {
        void Save<T>(T item) where T : class, new();
        void Add<T>(T item) where T : class, new();
        void Delete<T>(T item) where T : class, new();
        T Single<T>() where T : class, new();
        System.Linq.IQueryable<T> All<T>() where T : class, new();
        System.Linq.IQueryable<T> All<T>(int page, int pageSize) where T : class, new();

        List<T> FindByTag<T>(List<string> tags) where T : class, new();
        List<string> AllTags();
    }
}
