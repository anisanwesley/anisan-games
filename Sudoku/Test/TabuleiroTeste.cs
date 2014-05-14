using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelo;
using System.Linq;

namespace TestProject
{
    /// <summary>
    /// Summary description for BoardTest
    /// </summary>
    [TestClass]
    public class TabuleiroTeste
    {
        private Tabuleiro _board;

        [TestInitialize()]
        public void TestInitialize()
        {
            _board = new Tabuleiro();
            _board.AdicionaCampo("QB_L1_C5", 3);
        }

        [TestCleanup()]
        public void TestCleanup()
        {
            _board = null;
        }

        [TestMethod]
        public void AdicionaCampoValorRepetidoValido()
        {
            var valorUnico = _board.AdicionaCampo("QE_L6_C6", 3);

            Assert.IsTrue(valorUnico);
        }
        [TestMethod]
        public void AdicionaCampoValorZero()
        {
            _board.AdicionaCampo("QE_L6_C6", 0);

            Assert.IsNull(_board.Campos.Find(c => c.Id == "QE_L6_C6"));
        }
        [TestMethod]
        public void EditaCampoAdicionadoAnteriormente()
        {
            var valorUnico = _board.AdicionaCampo("QB_L1_C5", 4);

            Assert.IsTrue(valorUnico);
        }

        [TestMethod]
        public void AdicionaCampoRepetidoLinha()
        {
            var valorUnico = _board.AdicionaCampo("QC_L1_C9", 3);

            Assert.IsFalse(valorUnico);
        }

        [TestMethod]
        public void AdicionaCampoRepetidoQuadro()
        {
            var valorUnico = _board.AdicionaCampo("QB_L2_C4", 3);

            Assert.IsFalse(valorUnico);
        }

        [TestMethod]
        public void AdicionaCampoRepetidoColuna()
        {
            var valorUnico = _board.AdicionaCampo("QF_L5_C5", 3);

            Assert.IsFalse(valorUnico);
        }

        [TestMethod]
        public void AdicionaCampoComValorDiferente()
        {
            var valorUnico = _board.AdicionaCampo("QB_L1_C4", 4);

            Assert.IsTrue(valorUnico);
        }

        [TestMethod]
        public void EditaValorDoCampo()
        {
            _board.AdicionaCampo("QB_L1_C5", 4);

            var valorCorreto = _board.Campos.Find(c => c.Id.Contains("C5")).Valor;

            Assert.AreEqual(valorCorreto, 4);
        }

        [TestMethod]
        public void ApagaCampoSetandoZero()
        {
            _board.AdicionaCampo("QB_L1_C5", 0);

            var campoDeletado = _board.Campos.Find(c => c.Id.Contains("C5"));

            Assert.IsNull(campoDeletado);
        }

        [TestMethod]
        public void InsereCampoUnico()
        {
            _board.AdicionaCampo("QC_L2_C5", 7);

            var valorUnico = _board.Campos.Find(c => c.Id.Contains("C5")).GetValidade();

            Assert.IsTrue(valorUnico);
        }

        [TestMethod]
        public void InsereCampoNaoUnico()
        {
            _board.AdicionaCampo("QC_L2_C5", 3);

            var valorUnico = _board.Campos.Find(c => c.Id.Contains("C5")).GetValidade();

            Assert.IsFalse(valorUnico);
        }

        [TestMethod]
        public void BoardAlteraCampoUnicoAoInserirUmComMesmoValor()
        {
            _board.AdicionaCampo("QB_L2_C5", 3);

            var valorUnico = _board.Campos.Find(c => c.Id.Contains("C5")).GetValidade();

            Assert.IsFalse(valorUnico);
        }

        [TestMethod]
        public void BoardAlteraCampoRepetidoParaUnico()
        {
            _board.AdicionaCampo("QB_L2_C5", 3);
            _board.RemoveCampo("QB_L1_C5");

            var valorUnico = _board.Campos.Find(c => c.Id.Contains("C5")).GetValidade();

            Assert.IsTrue(valorUnico);
        }
        [TestMethod]
        public void VerificaCampoExclusivoTrue()
        {
            var exclusivo = _board.VerificaSeCampoExclusivo(3, "QB_L1_C5");

            Assert.IsTrue(exclusivo);
        }
        [TestMethod]
        public void VerificaCampoExclusivoAoAdicionarValorIgual()
        {
            _board.AdicionaCampo("QB_L2_C6", 4);

            var exclusivo = _board.VerificaSeCampoExclusivo(3, "QB_L1_C5");

            Assert.IsTrue(exclusivo);
        }
        [TestMethod]
        public void VerificaCampoExclusivoAoEditarUmValor()
        {
            _board.AdicionaCampo("QB_L2_C5", 4);

            var exclusivo = _board.VerificaSeCampoExclusivo(3, "QB_L1_C5");

            Assert.IsTrue(exclusivo);
        }
        [TestMethod]
        public void VerificaCampoExclusivoFalse()
        {
            _board.AdicionaCampo("QB_L2_C5", 4);

            var exclusivo = _board.VerificaSeCampoExclusivo(3, "QB_L1_C5");

            Assert.IsTrue(exclusivo);
        }
        [TestMethod]
        public void VerificaCampoExclusivoAoExcluirOutro()
        {
            _board.AdicionaCampo("QB_L1_C6", 3);
            _board.RemoveCampo("QB_L1_C5");

            var exclusivo = _board.VerificaSeCampoExclusivo(3, "QB_L1_C6");

            Assert.IsTrue(exclusivo);
        }
    }
}