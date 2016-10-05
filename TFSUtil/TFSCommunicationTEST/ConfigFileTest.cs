using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TFSCommunicationTEST.Properties;

namespace TFSCommunicationTEST
{
    [TestFixture]
    public class ConfigFileTest
    {
        [Test]
        public void TestConfigFile()
        {
            string configFileName = TFSCommunication.Config.ConfigUtil.ConfigFilePath;
            Assert.AreEqual(@"c:\projects\TFSUtilConfig.xml",configFileName);

            string tfsUri = TFSCommunication.Config.ConfigUtil.TFSUri;

            Assert.IsNotNull(tfsUri);

        }
    }
}
