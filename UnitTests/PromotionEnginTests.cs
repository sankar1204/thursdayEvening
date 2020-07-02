using NUnit.Framework;
using PromotionEngine;

namespace UnitTests {

    [TestFixture]
    public class PromotionEngineTests {

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Scenario1() {
            string checkOutInput = "1A 2B 3C";
            string faceValues = "50 A;30 B;20 C;15 D";
            string activePromotion = "3 A 130;2 B 45;1 CD 30";
            CheckOut sut = new CheckOut();
            double expectedTotal = 155; //50 + 45 + 60 

            double actualTotal = sut.GetTotal(faceValues, activePromotion, checkOutInput);

            Assert.IsTrue(expectedTotal==actualTotal, $"it should have been{expectedTotal}");
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Scenario2() {
            string checkOutInput = "6 A;4 B;3 C;2 D";
            string faceValues = "50 A;30 B;20 C;15 D";
            string activePromotion = "3 A 130;2 B 45;1 C&D 30";
            CheckOut sut = new CheckOut();
            double expectedTotal = 430; //260 + 90 + 80 

            double actualTotal = sut.GetTotal(faceValues, activePromotion, checkOutInput);

            Assert.IsTrue(expectedTotal == actualTotal, $"it should have been{expectedTotal}");
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Scenario3() {
            string checkOutInput = "6 A;4 B;3 C;2 D";
            string faceValues = "50 A;30 B;20 C;15 D";
            string activePromotion = "3 A 130;2 B 45;1 C 30";
            CheckOut sut = new CheckOut();
            double expectedTotal = 430; //260 + 90 + 50 + 30 

            double actualTotal = sut.GetTotal(faceValues, activePromotion, checkOutInput);

            Assert.IsTrue(expectedTotal == actualTotal, $"it should have been{expectedTotal}");
        }
    }
}
