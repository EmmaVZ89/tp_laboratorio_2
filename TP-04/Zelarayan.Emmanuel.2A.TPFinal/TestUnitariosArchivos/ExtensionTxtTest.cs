using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitariosArchivos
{
    [TestClass]
    public class ExtensionTxtTest
    {
        /// <summary>
        /// Metodo engadado de validar que la extension del archivo sea txt, si lo es tiene que retornar true.
        /// </summary>
        [TestMethod]
        public void ValidarExtension_RetornaTrue_SiElArchivoEsTxt()
        {
            //Arrange
            ExtensionTxt extTxt = new ExtensionTxt();

            //Act
            bool retorno = extTxt.ValidarExtension("archivo.txt");

            //Assert
            Assert.IsTrue(retorno);
        }

        /// <summary>
        /// Motodo encargado de validar que la extension del archivo No sea txt, si no lo es lanza ExtensionIncorrectaException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ExtensionIncorrectaException))]
        public void ValidarExtension_LanzaExtensionIncorrectaException_SiElArchivoNoEsTxt()
        {
            //Arrange
            ExtensionTxt extTxt = new ExtensionTxt();

            //Act
            extTxt.ValidarExtension("archivo.json");
        }

        /// <summary>
        /// Motodo encargado de validar que el archivo no exista, si no lo es lanza ExtensionIncorrectaException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ExtensionIncorrectaException))]
        public void ValidarSiExisteElArchivo_LanzaExtensionIncorrectaException_SiElArchivoNoExiste()
        {
            //Arrange
            ExtensionTxt extTxt = new ExtensionTxt();

            //Act
            extTxt.ValidarSiExisteElArchivo("");
        }
    }
}
