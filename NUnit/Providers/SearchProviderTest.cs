using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NUnit.Providers
{
   
    class SearchProviderTest
    {
        [Test]
        public void A() {
            var q = 1;
            q++;
            Assert.AreEqual(2, q);
        }
    }
}
