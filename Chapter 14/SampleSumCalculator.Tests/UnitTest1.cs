namespace SampleSumCalculator.Tests
{
    public class Tests
    {    

        [Test]
        [TestCase(9,2)]
        [TestCase(1, 0)]
        [TestCase(3, -2)]
        public void Validate_Sum_Returns_Number(int numberA, int numberB)
        {
            //arrange
            var calc =new Calculate(numberA, numberB);

            //act
            var result = calc.Sum();

            //assert
            Assert.That(numberA+numberB, Is.EqualTo(result));
        }
    }
}