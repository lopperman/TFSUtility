using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TFSCommunication;
using TFSCommunication.BusinessObjects;

namespace TFSCommunicationTEST
{
    [TestFixture]
    public class TFSConnectTest
    {
        private TFSConnect connect = null;

        [OneTimeSetUp]
        public void setup()
        {
            connect = new TFSConnect(TFSCommunication.Config.ConfigUtil.TFSUri, TFSCommunication.Config.ConfigUtil.ProjectName);
        }

        [OneTimeTearDown]
        public void teardown()
        {
            connect = null;
        }


        [Test]
        public void init_tfsconnect()
        {
            Assert.IsNotNull(connect);
            Assert.IsNotEmpty(connect.TFSUri);
            Assert.IsNotEmpty(connect.ProjectName);
        }

        [Test]
        public void GetListOfTfsAreas()
        {
            List<TfsArea> areas = connect.GetTfsAreas();
            Assert.IsNotNull(areas);
            Assert.Greater(areas.Count,0);
        }


    }
}
