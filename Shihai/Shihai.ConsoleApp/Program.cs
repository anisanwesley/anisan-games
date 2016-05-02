using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shihai.Domain;

namespace Shihai.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var campos = new Campo[4];

            campos[0] = new Campo(1, 2, 3);
            campos[1] = new Campo(4, 5, 6);

            campos[0].Vizinhos.Add(campos[1]);
            campos[0].Vizinhos.Add(campos[1]);
            //campos[0].Vizinhos.First().Incrementa();

            var campo = campos[1];

           // campo.Incrementa();


            var list = new List<Campo>();

            list.Add(new Campo(1, 1, 1));
            list.Add(new Campo(2, 2, 2));
            list[0].Vizinhos.Add(list[1]);
            list[0].Vizinhos.Add(list[0]);

            //list[1].Incrementa();

            foreach (var campo1 in list)
            {
                foreach (var campo2 in campo1.Vizinhos)
                {
                   // campo2.Incrementa();
                }
            }

            var camp = list[1];

            Campo campor = null;

            list.Add(campor);
            list.Add(null);
            list.Add(null);
            list.Add(null);

            list.Remove(null);
            list.Remove(null);
            list.Remove(null);
            list.Remove(null);
            list.Remove(null);
            list.Remove(null);

            //camp.Incrementa();





        }
    }
}
