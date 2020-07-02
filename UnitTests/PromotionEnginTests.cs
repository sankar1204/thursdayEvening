using NUnit.Framework;
using PromotionEngine;

namespace UnitTests {

    [TestFixture]
    public class PromotionEngineTests {

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void DefaultPromotion() {
            string checkOutInput = "1A 2B 3C";
            string faceValues = "50 A;30 B;20 C;15 D";
            string activePromotion = "3 A 130;2 B 45;2 CD 30";
            CheckOut sut = new CheckOut();
            double expectedTotal = 155; //50 + 45 + 60 

            double actualTotal = sut.GetTotal(faceValues, activePromotion, checkOutInput);

            Assert.IsTrue(expectedTotal==actualTotal, $"it should have been{expectedTotal}");
        }
    }
}
