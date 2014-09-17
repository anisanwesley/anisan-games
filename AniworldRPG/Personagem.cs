using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorRPG
{
   public class Personagem
    {
        public string Nome { get; set; }

        //Atributos
        public int HP { get; set; }
        public int Mana { get; set; }
        public int Stamina { get; set; }

        //Função no mundo
        public string Raca { get; set; }
        public string Classes { get; set; }
        public string Profissao { get; set; }

        //Equipamento
        public string Cota { get; set; }
        public string Calcas { get; set; }
        public string Sapatos { get; set; }
        public string Bracadeiras { get; set; }
        public string Capacete { get; set; }
        public string Arma { get; set; }


       public Personagem()
       {
           HP  = Mana = Stamina = 1000;
           Raca = Classes = Profissao = Cota = Calcas = Sapatos = Bracadeiras = Capacete = Arma = "";
       }


       
       
       public override string ToString()
       {
           return String.Format("{0}, {1} que é {2}, do tipo {3}",Nome,Raca,Profissao,Classes);
       }

       internal void RemoverClasse(string classe)
       {
           Classes = Classes.Replace(classe, "");
           Classes = Classes.Replace(" ,", "");

           if (Classes[0] == ',')
               Classes = Classes.Substring(2, Classes.Length - 2);
       }

       internal void AdicionarClasse(string classe)
       {
           Classes += (String.IsNullOrWhiteSpace(Classes))
               ? classe
               : ", " + classe;

       }

       internal void AdicionarArmaFromClasse(string arma)
       {
           Arma = arma;


       }

       internal void AdicionarArmaFromProfissao(string sufixo)
       {
           Arma = Arma.Split(' ')[0] + " " + sufixo;
       }
    }

}
