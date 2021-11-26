using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitariosContacto
{
    [TestClass]
    public class CalculosTest
    {
        /// <summary>
        /// Metodo encargardo de verificar que si el IMC es menor a 18.5 la composicion retornada tiene que ser Bajo_peso
        /// </summary>
        [TestMethod]
        public void DeterminarComposicion_RetornaBajoPeso_SiELImcEsMenorA18punto5()
        {
            // Arrange
            double imc = 17;
            Contacto contacto = new Contacto("Pepe", 33, "Hombre");
            EComposicionCorporal esperado = EComposicionCorporal.Bajo_peso;

            // Act
            EComposicionCorporal actual = contacto.DeterminarComposicion(imc);

            // Assert
            Assert.AreEqual(esperado, actual);
        }

        /// <summary>
        /// Metodo encargardo de verificar que si el IMC es mayor a 18.5 y menor a 24.9 la composicion retornada tiene que ser Normal
        /// </summary>
        [TestMethod]
        public void DeterminarComposicion_RetornaNormal_SiELImcEsMayorA18punto5YMenorA24punto9()
        {
            // Arrange
            double imc = 23;
            Contacto contacto = new Contacto("Pepe", 33, "Hombre");
            EComposicionCorporal esperado = EComposicionCorporal.Normal;

            // Act
            EComposicionCorporal actual = contacto.DeterminarComposicion(imc);

            // Assert
            Assert.AreEqual(esperado, actual);
        }

        /// <summary>
        /// Metodo encargardo de verificar que si el IMC es mayor a 24.9 y menor a 29.9 la composicion retornada tiene que ser Sobrepeso
        /// </summary>
        [TestMethod]
        public void DeterminarComposicion_RetornaSobrePeso_SiELImcEsMayorA24punto9YMenorA29punto9()
        {
            // Arrange
            double imc = 27;
            Contacto contacto = new Contacto("Pepe", 33, "Hombre");
            EComposicionCorporal esperado = EComposicionCorporal.Sobrepeso;

            // Act
            EComposicionCorporal actual = contacto.DeterminarComposicion(imc);

            // Assert
            Assert.AreEqual(esperado, actual);
        }

        /// <summary>
        /// Metodo encargardo de verificar que si el IMC es mayor a 30 la composicion retornada tiene que ser Obesidad
        /// </summary>
        [TestMethod]
        public void DeterminarComposicion_RetornaObesidad_SiELImcEs30OMayor()
        {
            // Arrange
            double imc = 31;
            Contacto contacto = new Contacto("Pepe", 33, "Hombre");
            EComposicionCorporal esperado = EComposicionCorporal.Obesidad;

            // Act
            EComposicionCorporal actual = contacto.DeterminarComposicion(imc);

            // Assert
            Assert.AreEqual(esperado, actual);
        }

    }
}
