
namespace AgeCalculatorTest
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void GetIndexView_Return_Should()
        {
            var controller = new HomeController(new NullLogger<HomeController>(), new CalculatorService());

            var result = controller.Index();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<ViewResult>(result);
        }


        [TestMethod]
        public void PostIndexView_Return_Should()
        {
            var controller = new HomeController(new NullLogger<HomeController>(), new CalculatorService());
            DateTime dateTime = DateTime.Now.AddDays(-1);

            var result = controller.Index(new AgeCalculator.Models.AgeViewModel { Birthday = dateTime });

            Assert.IsNotNull(result);
            Assert.IsNotNull((result as ViewResult)?.Model);
        }


        [TestMethod]
        public void PostIndexView_ReturnModel_Should()
        {
            var controller = new HomeController(new NullLogger<HomeController>(), new CalculatorService());
            DateTime dateTime = DateTime.Now.AddDays(-1);

            var result = controller.Index(new AgeCalculator.Models.AgeViewModel { Birthday = dateTime });
            var model = (result as ViewResult)?.Model;

            Assert.IsNotNull(model);
            Assert.IsInstanceOfType<AgeViewModel>(model);

        }
    }
}