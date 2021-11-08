using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitariosArchivos
{
    [TestClass]
    public class ExtensionXmlTest
    {
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

        [TestMethod]
        [ExpectedException(typeof(ExtensionIncorrectaException))]
        public void ValidarExtension_LanzaExtensionIncorrectaException_SiElArchivoNoEsXml()
        {
            //Arrange
            ExtensionXml<string> extXml = new ExtensionXml<string>();

            //Act
            extXml.ValidarExtension("archivo.txt");
        }

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
