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
            // Teszt kezdeti felt�teleinek be�ll�t�sa

            // Act
            // Megh�vjuk a tesztelend� f�ggv�nyt / v�gpontot
            var result = controller.GetViragok() as ObjectResult;

            // Assert
            // Ki�rt�kelj�k az eredm�nyt
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
            string expectedResultText = "error: A vir�g nem tal�lhat�";

            // Act
            var result = controller.GetViragokById(id) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);
            Assert.IsTrue(result.Value == expectedResultText);
        }
    }
}