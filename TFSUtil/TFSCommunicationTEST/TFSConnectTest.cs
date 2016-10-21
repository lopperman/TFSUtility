using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
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

        [Test]
        public void GetWorkitem()
        {
            var item = connect.GetWorkItem(10301);
            Assert.IsNotNull(item);
        }

        [Test]
        public void GetWorkItemTypes()
        {
            var workItemTypes = connect.GetWorkItemTypes();
            Assert.IsNotNull(workItemTypes);
            Assert.Greater(workItemTypes.Count, 0);
        }

        [Test]
        public void ExecuteWIQL()
        {
            DateTime dt = DateTime.Today.AddDays(-10);

            string query1 = string.Format("SELECT * FROM WorkItems WHERE ([Created Date] >= '{0}' OR [Changed Date] >= '{0}')", dt.ToString("MM/dd/yy"));
            List<WorkItem> results = connect.ExecuteWorkItemWIQL(query1);

        }

    }
}
