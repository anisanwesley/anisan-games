using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Shihai.Domain
{
    public class Campo
    {
        public static int Recursoes=100;

        public Campo(int posX, int posY, int valorMaximo)
        {
            Id = String.Format("({0},{1}), Max:{2}", posX, posY, valorMaximo);
            Limite = valorMaximo;
            Vizinhos = new List<Campo>();
            this.posX = posX;
            this.posY = posY;
            
        }

        public Campo()
        {
            Vizinhos = new List<Campo>();
        }

        public string Id { set; get; }
        public int Valor { set; get; }
        public List<Campo> Vizinhos { set; get; }
        public int Limite { set; get; }
        public int posX { set; get; }
        public int posY{ set; get; }
        public string Team { get; set; }

        public void Incrementa(string team)
        {
            Team = team;
            Thread.Sleep(2);
            Valor++;
           

            if (!Tabuleiro.JogoContinua(team)||Recursoes == 0) throw new Exception("Terminado");

            if (Valor >= Limite)
            {
                Estoura();
            }

        }

        private void Estoura()
        {
            Recursoes--;
            Recursoes--;
            Valor = Valor - Limite;
            //if (Valor == 0) Team = null;
            foreach (var campo in Vizinhos)
            {
                campo.Incrementa(Team);
            }
        }
        public override string ToString()
        {
            return String.Format(Id+Vizinhos.Count+" valor:"+Valor);
        }

        public Tabuleiro Tabuleiro { get; set; }

       

        public void VerificaJogoTerminado(string team)
        {
            if (!Tabuleiro.JogoContinua(team)) throw new Exception("Terminado");
        }
    }
}