using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitariosArchivos
{
    [TestClass]
    public class ExtensionXmlTest
    {
        /// <summary>
        /// Metodo engadado de validar que la extension del archivo sea xml, si lo es tiene que retornar true.
        /// </summary>
        [TestMethod]
        public void ValidarExtension_RetornaTrue_SiElArchivoEsXml()
        {
            //Arrange
            ExtensionXml<string> extXml = new ExtensionXml<string>();

            //Act
            bool retorno = extXml.ValidarExtension("archivo.xml");

            //Assert
            Assert.IsTrue(retorno);
        }

        /// <summary>
        /// Motodo encargado de validar que la extension del archivo No sea xml, si no lo es lanza ExtensionIncorrectaException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ExtensionIncorrectaException))]
        public void ValidarExtension_LanzaExtensionIncorrectaException_SiElArchivoNoEsXml()
        {
            //Arrange
            ExtensionXml<string> extXml = new ExtensionXml<string>();

            //Act
            extXml.ValidarExtension("archivo.txt");
        }

        /// <summary>
        /// Motodo encargado de validar que el archivo no exista, si no lo es lanza ExtensionIncorrectaException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ExtensionIncorrectaException))]
        public void ValidarSiExisteElArchivo_LanzaExtensionIncorrectaException_SiElArchivoNoExiste()
        {
            //Arrange
            ExtensionXml<string> extXml = new ExtensionXml<string>();

            //Act
            extXml.ValidarSiExisteElArchivo("");
        }
    }
}
