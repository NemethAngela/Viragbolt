using Backend.Controllers;
using Microsoft.AspNetCore.Mvc;
using ClassLibrary;

namespace TestProject
{
    [TestClass]
    public class FlowersControllerTest
    {
        FlowersController controller = new FlowersController();

        [TestMethod]
        public void TestGetViragok_Success()
        {
            // Arrange
            // Teszt kezdeti feltételeinek beállítása

            // Act
            // Meghívjuk a tesztelendõ függvényt / végpontot
            var result = controller.GetViragok() as ObjectResult;

            // Assert
            // Kiértékeljük az eredményt
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);
            var aruk = result.Value as List<Aruk>;
            Assert.IsTrue(aruk.Count() > 0);
        }

        [TestMethod]
        public void TestGetViragokById_Success()
        {
            // Arrange
            int id = 1;

            // Act
            var result = controller.GetViragokById(id) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);
            var aruk = result.Value as List<Aruk>;
            Assert.IsTrue(aruk.Count() > 0);
        }

        [TestMethod]
        public void TestGetViragokById_NotFound()
        {
            // Arrange
            int id = 999;
            string expectedResultText = "error: A virág nem található";

            // Act
            var result = controller.GetViragokById(id) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);
            Assert.IsTrue(result.Value == expectedResultText);
        }
    }
}