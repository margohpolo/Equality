using Equality.Domain.ValueObjects;

namespace Equality.Tests.ValueObjectTests
{
    public class MoneyTests
    {
        private static readonly Money _moneyExampleA = new Money(4_321.09M);
        private static readonly Money _moneyExampleB = new Money(987_654_321.09M);

        [Fact]
        public void EqualityCheck_Should_Return_True_IfEqual()
        {
            Assert.True(_moneyExampleA.Equals(_moneyExampleA));
        }

        [Fact]
        public void EqualityCheck_Should_Return_False_IfNotEqual()
        {
            Assert.False(_moneyExampleA.Equals(_moneyExampleB));
        }

        [Fact]
        public void ToString_Should_Print_CorrectValue_With_Formatting()
        {
            string expectedA = "$4,321.09";

            Assert.Equal(expectedA, _moneyExampleA.ToString());

            string expectedB = "$987,654,321.09";

            Assert.Equal(expectedB, _moneyExampleB.ToString());

            string expectedC = "$321.09";

            Assert.Equal(expectedC, new Money(321.09M).ToString());

            string expectedD = "$321.00";

            Assert.Equal(expectedD, new Money(321).ToString());
        }
    }
}
