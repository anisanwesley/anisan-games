using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelo;

namespace TestProject
{
    /// <summary>
    /// Summary description for LineTest
    /// </summary>
    [TestClass]
    public class CampoTeste
    {
        private Campo _field;
        private Tabuleiro _board;

        [TestInitialize]
        public void TestInitialize()
        {
            _field = new Campo("QA_L1_C1", 1);
            _board = new Tabuleiro();
            _board.Campos.Add(_field);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _field = null;
            _board = null;
        }

        [TestMethod]
        public void VerificaNomeCampoIgual_B_L1_C8()
        {
            _field = new Campo("QB", "L1", "C8");

            Assert.AreEqual("QB_L1_C8", _field.Id);
        }

        [TestMethod]
        public void VerificaNomeCampoIgual_C_L2_C8()
        {
            _field = new Campo("QC", "L2", "C8");

            Assert.AreEqual("QC_L2_C8", _field.Id);
        }

   
    }
}
