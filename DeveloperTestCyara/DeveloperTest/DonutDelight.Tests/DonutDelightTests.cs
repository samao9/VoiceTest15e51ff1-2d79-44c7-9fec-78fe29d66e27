using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework.Constraints;

namespace DonutDelight.Tests
{
    public class DonutDelightTests
    {
        [TestFixture]
        public class GetOrderSizeMethodTests
        {
            [TestCaseSource(typeof(DonutDelightTestData), nameof(DonutDelightTestData.InvalidOrderSizes))]
            public void GetOrderSize_Invalid_ReturnNull(int s)
            {
                var result = OrderSizes.GetOrderForSize(s);

                Assert.IsTrue(result == null);
            }

            [TestCaseSource(typeof(DonutDelightTestData), nameof(DonutDelightTestData.SampleValidValue))]
            public void GetOrderSize_ValidSizeN_ReturnSumToN(int n)
            {
                var actual = OrderSizes.GetOrderForSize(n).Sum();
                Assert.AreEqual(n, actual);
            }

            [TestCaseSource(typeof(DonutDelightTestData), nameof(DonutDelightTestData.SampleValidValue))]
            public void GetOrderSize_ValidSizeN_ReturnContainsCorrectBoxSize(int n)
            {
                var result = OrderSizes.GetOrderForSize(n);

                bool containCorrectBox = result.TrueForAll(x => OrderSizes.BoxSizeList.Contains(x));

                Assert.IsTrue(containCorrectBox);
            }

            [TestCaseSource(typeof(DonutDelightTestData), nameof(DonutDelightTestData.InvalidInput))]
            public void GetOrderSize_InvalidInput_ThrowException(int n)
            {
                Exception ex = Assert.Throws<Exception>(() => OrderSizes.GetOrderForSize(n));

                Assert.That(ex.Message, Is.EqualTo(OrderSizes.INPUT_CONSTRAINT));
            }
        }

        [TestFixture]
        public class GetInvalidOrdersMethodTests
        {
            private List<int> invalidOrderSizes;

            [SetUp]
            protected void SetUp()
            {
                invalidOrderSizes = new List<int> { 1, 2, 3, 5, 7, 11 };
            }

            [TestCase(50)]
            [TestCase(100)]
            public void GetInvalidOrders_ReturnsCorrectInvalids(int n)
            {
                var actual = OrderSizes.GetInvalidOrders(n);

                Assert.AreEqual(invalidOrderSizes, actual);
            }
        }

        [TestFixture]
        public class GetBoxCountForOrderTests
        {
            [TestCaseSource(typeof(DonutDelightTestData), nameof(DonutDelightTestData.InvalidOrderSizes))]
            public void GetBoxCountForOrder_Invalid_ReturnNull(int s)
            {
                var result = OrderSizes.GetBoxCountForOrder(s);

                Assert.IsTrue(result == null);
            }

            [TestCaseSource(typeof(DonutDelightTestData), nameof(DonutDelightTestData.SampleValidValue))]
            public void GetBoxCountForOrder_ValidSizeN_ReturnSumToN(int n)
            {
                var boxCountResult = OrderSizes.GetBoxCountForOrder(n);

                var actual = boxCountResult.Select(b => b.Value * b.Key).Sum();

                Assert.AreEqual(n, actual);
            }

            [Test]
            public void GetBoxCountForOrder_ValidSizeN_ReturnContainsCorrectBoxSize(int n)
            {
                var boxCountResult = OrderSizes.GetBoxCountForOrder(n);

                bool containCorrectBox = boxCountResult.TrueForAll(x => OrderSizes.BoxSizeList.Contains(x.Key));

                Assert.IsTrue(containCorrectBox);
            }

            [TestCaseSource(typeof(DonutDelightTestData), nameof(DonutDelightTestData.InvalidInput))]
            public void GetBoxCountForOrder_InvalidInput_ThrowException(int n)
            {
                Exception ex = Assert.Throws<Exception>(() => OrderSizes.GetOrderForSize(n));

                Assert.That(ex.Message, Is.EqualTo(OrderSizes.INPUT_CONSTRAINT));
            }
        }
    }
}
