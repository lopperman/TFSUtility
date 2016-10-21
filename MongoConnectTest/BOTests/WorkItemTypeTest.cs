using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TFS.BO;
using TFSCommunication;

namespace TFS.BO
{
    [TestFixture]
    public partial class WorkItemTypeTest
    {

        [OneTimeSetUp]
        public void setup()
        {
        }

        [OneTimeTearDown]
        public void teardown()
        {
        }

        [Test]
        public void testBuildWorkItemType()
        {
            var wit = new WorkItemTypeBO();
        }
    }
}
