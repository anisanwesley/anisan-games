using System;

namespace Modelo
{
    public class Campo
    {
        public string Id { get; set; }

        public string LinhaId { get; set; }

        public string ColunaId { get; set; }

        public string QuadroId { get; set; }

        public int Valor { get; set; }

        public bool Unico { get; set; }

        public Campo()
        {
        }

        public Campo(string id, int valor)
        {
            this.Valor = valor;
            var coordenada = id.Split('_');

            QuadroId = coordenada[0];
            LinhaId = coordenada[1];
            ColunaId = coordenada[2];

            Id = id;
        }

        public Campo(string quadroId, string linhaId, string colunaId)
        {
            Id = String.Format("{0}_{1}_{2}", quadroId, linhaId, colunaId);
        }

        public override string ToString()
        {
            return "Campo: " + Id+", "+Valor+", "+Unico;
        }

        public void InvalidarCampo()
        {
            Unico = false;
        }

        public bool GetValidade()
        {
            return Unico;
        }

        internal void SetValidate(bool unico)
        {
            Unico = unico;
        }
    }
}