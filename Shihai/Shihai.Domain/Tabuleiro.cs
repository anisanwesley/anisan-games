using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shihai.Domain
{
    public class Tabuleiro
    {
        //public Campo[,] Campos { get; set; }
        public List<Campo> Campos { get; set; }
        
        
        public bool JogoContinua(string name)
        {

            var campoAmigo = Campos.Any(c => c.Team == name);
            var campoVazio = Campos.Any(c=>c.Team==null);
            var continua = campoAmigo || campoVazio;

            if (!continua)
                Campos = new List<Campo>();

            return continua;

        }
 
        

        public Tabuleiro(int x, int y)
        {
            Campos = new List<Campo>();

            for (int l = 0; l < x; l++)
            {
                for (int c = 0; c < y; c++)
                {
                    if (LinhaBorda(l, x) && ColunaBorda(c, y))
                    {
                        Campos.Add(new Campo(l, c, 2));
                        continue;
                    }
                    if (LinhaBorda(l, x) || ColunaBorda(c, y))
                    {
                        Campos.Add(new Campo(l, c, 3));
                        continue;
                    }
                    Campos.Add(new Campo(l, c, 4));

                }
            }

            foreach (var campo in Campos)
            {
                campo.Tabuleiro = this;

                var vizinhos = new[]
                {
                     Campos.Find(c => c.posX == campo.posX + 1 && c.posY == campo.posY),
                   Campos.Find(c => c.posX == campo.posX - 1 && c.posY == campo.posY),
                   Campos.Find(c => c.posX == campo.posX  && c.posY == campo.posY+1),
                    Campos.Find(c => c.posX == campo.posX  && c.posY == campo.posY-1)
                                   };
                foreach (var vizinho in vizinhos.Where(vizinho => vizinho!=null))
                campo.Vizinhos.Add(vizinho);
                
            }


            //    Campos = new Campo[x,y];

        //    for (int l = 0; l < x; l++)
        //    {
        //        for (int c = 0; c < y; c++)
        //        {
        //            if (LinhaBorda(l, x) && ColunaBorda(c, y))
        //            {
        //                Campos[l, c] = new Campo(l, c, 2);
        //                continue;
        //            }
        //            if (LinhaBorda(l, x) || ColunaBorda(c, y))
        //            {
        //                Campos[l, c] = new Campo(l, c, 3);
        //                continue;
        //            }
        //            Campos[l, c] = new Campo(l, c, 4);

        //        }
        //    }

            
        }

        



        private bool ColunaBorda(int coluna, int matrizy)
        {
            return coluna == 0 || coluna == matrizy-1;
        }

        private bool LinhaBorda(int linha, int matrizx)
        {
            return linha == 0 || linha == matrizx-1;
        }

    }
}
