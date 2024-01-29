using AgeCalculator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeCalculatorTest
{
    [TestClass]
    public class AttributeTest
    {
        [TestMethod]
        public void Attibute_ValidModel_False()
        {
            var value = DateTime.Now.AddMinutes(1);
            var attribute = new DateTimeFutureAttribute();

            var result = attribute.IsValid(value);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void Attibute_ValidModel_Should()
        {
            var value = DateTime.Now.AddMinutes(-1);
            var attribute = new DateTimeFutureAttribute();

            var result = attribute.IsValid(value);

            Assert.IsTrue(result);
        }
    }
}
