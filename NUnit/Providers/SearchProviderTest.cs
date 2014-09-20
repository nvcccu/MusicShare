using System.Linq;
using BusinessLogic.DaoEntities;
using DAO;
using NUnit.Environment;
using NUnit.Framework;

namespace NUnit.Providers {
    [TestFixture]
    internal class SearchProviderTest : DbResetBase {
        [Test]
        public void A() {
            var count = new Guitar()
                .Select()
                .OrderBy(Guitar.Fields.Id, OrderType.Asc)
                .GetData()
                .ToList()
                .Count;
            Assert.AreEqual(1, count);
        }
    }
}