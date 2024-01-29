namespace SorterTest
{
    [TestClass]
    public class SorterTest
    {
        [TestMethod]
        public void Sort_TestInt_Should()
        {
            double[] unsorded = { 4, 1, 0, 0, -2, -5, -4 };
            double[] expected = { -5, -4, -2, 0, 0, 1, 4 };

            Sort.VerifyAndSort(unsorded);

            CollectionAssert.AreEqual(expected, unsorded);
        }

        [TestMethod]
        public void Sort_TestFloat_Should()
        {
            double[] unsorded = { 4, 1.5, 0.7, 0.700001, -2, -5, -4 };
            double[] expected = { -5, -4, -2, 0.7, 0.700001, 1.5, 4 };

            Sort.VerifyAndSort(unsorded);

            CollectionAssert.AreEqual(expected, unsorded);
        }

        [TestMethod]
        public void Sort_TestInvalidData_ThrowShould()
        {
            double[] unsorded = {  };

            var act = () => Sort.VerifyAndSort(unsorded);

            Assert.ThrowsException<ArgumentException>(act);
        }

        [TestMethod]
        public void Sort_TestInvalidData_2_ThrowShould()
        {
            double[]? unsorded = null;

            var act = () => Sort.VerifyAndSort(unsorded);

            Assert.ThrowsException<ArgumentException>(act);
        }


        [TestMethod]
        public void Sort_TestInvalidData_3_ThrowShould()
        {
            double[] unsorded = { 4, 1.5, 0.7, 0.700001, -2, -5, -4, 9, 1, 0.2, 14}; //11 elem

            var act = () => Sort.VerifyAndSort(unsorded);

            Assert.ThrowsException<ArgumentException>(act);
        }

        [TestMethod]
        public void Sort_TestInvalidData_Should()
        {
            double[] unsorded = { 1 }; 
            double[] expected = { 1 };

            Sort.VerifyAndSort(unsorded);

            CollectionAssert.AreEqual(expected, unsorded);
        }
    }
}