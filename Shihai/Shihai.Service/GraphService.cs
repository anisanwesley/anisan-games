using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shihai.Domain;

namespace Shihai.Service
{
    public class GraphService
    {
        private Tabuleiro _tab = new Tabuleiro(10, 10);

        public Size GetCoordenades(int x, int y,string team)
        {
            var linha = x / 50;
            var coluna = y / 50;

            var campo = _tab.Campos.Find(c => c.posX == linha && c.posY == coluna);
            Campo.Recursoes = 500000;
            campo.VerificaJogoTerminado(team);
            if (team == campo.Team || campo.Team == null)
                try
                {
                    campo.Incrementa(team);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            return new Size(linha * 50, coluna * 50);
        }

        public Image GetImage(int x, int y)
        {
            var linha = x / 50;
            var coluna = y / 50;

            var campo = _tab.Campos.Find(c => c.posX == linha && c.posY == coluna);
            
            if (campo.Team == "pop")
            {
                switch (campo.Valor)
                {
                    case 0:
                        return Resource.pop0;
                    case 1:
                        return Resource.pop1;
                    case 2:
                        return Resource.pop2;
                    case 3:
                        return Resource.pop3;
                    case 4:
                        return Resource.pop4;
                    default:
                        return Resource.pop5;

                }
            }
            if (campo.Team == "rop")
            {
                switch (campo.Valor)
                {
                    case 0:
                        return Resource.rop0;
                    case 1:
                        return Resource.rop1;
                    case 2:
                        return Resource.rop2;
                    case 3:
                        return Resource.rop3;
                    case 4:
                        return Resource.rop4;
                    default:
                        return Resource.rop5;

                }
            }
            return null;
        }

        public Image GetImageControl(string time)
        {
            if (time == "pop") return Resource.pop1;
            return Resource.rop1;
        }
    }
}
