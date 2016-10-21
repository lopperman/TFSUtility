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
    public class ConvertWorkItemTest
    {

        [Test]
        public void testConvert()
        {
            var connect = new TFSConnect(TFSCommunication.Config.ConfigUtil.TFSUri, TFSCommunication.Config.ConfigUtil.ProjectName);

            var workItemTypes = connect.GetWorkItemTypes();





        }
    }



}
