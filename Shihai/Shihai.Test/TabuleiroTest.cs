using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shihai.Domain;

namespace Shihai.Test
{
    [TestClass]
    public class TabuleiroTest
    {
        private Tabuleiro _tab;

        [TestMethod]
        public void Criar_Tabuleiro_2x2()
        {
            _tab = new Tabuleiro(2, 2);

            Assert.AreEqual(4, _tab.Campos.Count);
        }
        [TestMethod]
        public void Criar_Tabuleiro_3x2()
        {
            _tab = new Tabuleiro(3, 2);

            Assert.AreEqual(6, _tab.Campos.Count);
        }
        [TestMethod]
        public void Criar_Tabuleiro_4x4()
        {
            _tab = new Tabuleiro(4, 4);

            Assert.AreEqual(16, _tab.Campos.Count);
        }
       
    }
}
