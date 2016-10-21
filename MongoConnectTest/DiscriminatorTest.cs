using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TFS.BO;

namespace MongoConnectTest
{
    [TestFixture]
    public class DiscriminatorTest
    {
        [Test]
        public void testDiscriminator()
        {
            Assert.IsFalse(Discriminator.Instance.IsRegistered);
            Discriminator.Instance.Register();
            Assert.IsTrue(Discriminator.Instance.IsRegistered);

        }
    }
}
