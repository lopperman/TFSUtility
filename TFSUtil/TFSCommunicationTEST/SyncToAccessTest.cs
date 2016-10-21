using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TFSCommunication;
using TFSCommunication.Syncing;

namespace TFSCommunicationTEST
{
    [TestFixture]
    public class SyncToAccessTest
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


    }
}
