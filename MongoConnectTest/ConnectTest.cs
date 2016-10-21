using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using NUnit.Framework;
using TFSCommunication.Config;

namespace MongoConnectTest
{

    [TestFixture]
    public class ConnectTest
    {
        private MongoClient client = null;
        private IMongoDatabase db = null;

        [OneTimeSetUp]
        public void setup()
        {
            string connString = ConfigUtil.MongoConnect;


            var clientSettings = MongoClientSettings.FromUrl(new MongoUrl(connString));
            client = new MongoClient(clientSettings);
            db = client.GetDatabase("TFS");
        }

        [OneTimeTearDown]
        public void teardown()
        {
        }


        [Test]
        public void GetConnStringFromExternalConfig()
        {
            string expected = "mongodb://localhost:27017";
            Assert.AreEqual(expected,ConfigUtil.MongoConnect);
        }

        [Test]
        public void AddThenRemoveItemsFromNewCollection()
        {
            var coll = db.GetCollection<TestEntity>("TestEntity");
            Assert.IsNotNull(coll);

            var entity = new TestEntity() { Name = "Paul Brower" };
            coll.InsertOneAsync(entity).Wait();

            var found = coll.AsQueryable().FirstOrDefault(x => x.Name == "Paul Brower");
            Assert.IsNotNull(found);

            coll.DeleteOneAsync(x => x._id == found._id).Wait();


            db.DropCollectionAsync("TestEntity").Wait();

        }
    }

    public class TestEntity
    {
        public ObjectId _id { get; set; }
        public string Name { get; set; }
    }

}
