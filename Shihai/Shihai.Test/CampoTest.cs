using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shihai.Domain;

namespace Shihai.Test
{
    [TestClass]
    public class CampoTest
    {
        private Campo _campo;

        [TestMethod]
        public void Criar_Campo()
        {
            _campo = new Campo();

            Assert.IsNotNull(_campo);
        }
        [TestMethod]
        public void Incrementar_Campo_em_1()
        {
            _campo = new Campo();

          //  _campo.Incrementa();

            Assert.AreEqual(1,_campo.Valor);
        }
        [TestMethod]
        public void Incrementar_Campo_em_2()
        {
            _campo = new Campo();

           // _campo.Incrementa();
          //  _campo.Incrementa();

            Assert.AreEqual(2, _campo.Valor);
        }
    }
}
