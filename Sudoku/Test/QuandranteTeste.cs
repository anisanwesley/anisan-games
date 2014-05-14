using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelo;

namespace TestProject
{
    [TestClass]
    public class QuadranteTeste
    {
  
        private Tabuleiro _board;

        [TestInitialize()]
        public void TestInitialize()
        {
            _board = new Tabuleiro();
            _board.Campos.Add(new Campo("QA_L1_C1", 1));
        }

        [TestCleanup()]
        public void TestCleanup()
        {
            _board.Campos = null;
            _board = null;
        }

        [TestMethod]
        public void QuadrantAlteraCampoRepetidoParaUnico()
        {
            _board.AdicionaCampo("QA_L1_C2", 1);
            _board.RemoveCampo("QA_L1_C1");
            _board.AtualizaCamposUnicos();

            var valorUnico = _board.Campos.Find(f => f.Id == "QA_L1_C2").Unico;

            Assert.IsTrue(valorUnico);
        }
        [TestMethod]
        public void QuadrantAlteraCampoUnicoParaRepetido()
        {
            _board.AdicionaCampo("QA_L1_C2", 1);

            _board.AtualizaCamposUnicos();

            var valorUnico = _board.Campos.Find(f => f.Id == "QA_L1_C1").Unico;

            Assert.IsFalse(valorUnico);
        }
    }
}
