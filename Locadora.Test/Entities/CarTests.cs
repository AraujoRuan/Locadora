using Locadora.Domain.ValueObjects;

namespace Locadora.Test.Entities
{
    [TestClass]
    public class CarTests
    {
        public CarTests()
        {
            var name = new Name("Ford", "Mustang");
            var color = new Color("Red");
            var plate = new Plate("kLM-1111");
            var model = new Model("Primeira Geração");
            var year =new DateTime(1970);

        }

        [TestMethod]
        public void Shou()
        {
            Assert.AreEqual(,);
        }
    }
}
