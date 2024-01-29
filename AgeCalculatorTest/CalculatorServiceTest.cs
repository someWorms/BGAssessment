namespace AgeCalculatorTest
{
    [TestClass]
    public class CalculatorServiceTest
    {
        [TestMethod]
        public void CalculatorService_ReturnDataValid_Should()
        {
            // Arrange
            var calculatorService = new CalculatorService();

            var bday = DateTime.Parse("01.01.2000 11:25:01");
            var current = DateTime.Parse("05.12.2022 10:25:02");

            var actualModel = new AgeViewModel() { CurrDate = current, Birthday = bday };
            var expected = new AgeViewModel()
            {
                CurrDate = current,
                Birthday = bday,
                Years = 22,
                Months = 11,
                Days = 4,
                Hours = 23,
                Minutes = 0,
                Seconds = 1
            };

            // Act
            var actual = calculatorService.CalculateDate(actualModel);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Seconds, actual.Seconds);
            Assert.AreEqual(expected.Minutes, actual.Minutes);
            Assert.AreEqual(expected.Hours, actual.Hours);
            Assert.AreEqual(expected.Days, actual.Days);
            Assert.AreEqual(expected.Months, actual.Months);
            Assert.AreEqual(expected.Years, actual.Years);
        }
    }
}
