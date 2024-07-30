using Moq;
using SampleSumCalculator;

namespace SampleSumCalculatorXUnit
{
    public class UnitTest1
    {
        [Fact]
        public void Test()
        {
            //arrange
            Calculate calculate = null;

            //act
            calculate = new Calculate(2, 5);
            var result = calculate.Sum();

            //assert
            Assert.Equal(7, result);
        }

        [Theory]
        [InlineData(1, 8)]
        [InlineData(5, 2)]
        public void Test2(int a, int b)
        {
            //arrange
            Mock<ICalculate> calculate = new Mock<ICalculate>();            
            calculate.Setup(x => x.Sum()).Returns(a + b);

            //act
            var result = calculate.Object.Sum();

            //assert
            Assert.Equal(a + b, result);
        }
    }
}