using Locadora.Domain.Entities;
using Locadora.Domain.ValueObjects;

namespace Locadora.Test.Entities
{
    [TestClass]
    public class CarTests
    {
        private Car _car;

        public CarTests()
        {
            var name = new Name("Ford", "Mustang");
            var color = new Color("Red");
            var plate = new Plate("kLM1111");
            var model = new Model("Primeira Geração");
            var year =new DateTime(1970);
            _car = new Car(name, color, plate, model);

        }

        [TestMethod]
        public void pesquisar_o_modelo_do_carro ()
        {
            Assert.AreEqual(true,_car.model!="");
        }

        [TestMethod]
        public void pesquisar_a_cor_do_carro()
        {
            Assert.AreEqual(true, _car.color != "");
        }
        [TestMethod]
        public void pesquisar_a_cor_do_carro_vazio()
        {
            Assert.AreEqual(false, _car.color == "");
        }
    }
}
