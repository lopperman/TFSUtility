using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TFSCommunication;

namespace TFSCommunicationTEST
{
    [TestFixture]
    public class TFSConnectTest
    {
        [Test]
        public void init_tfsconnect()
        {
            var c = new TFSConnect();
            Assert.IsNotNull(c);


        }


    }
}
