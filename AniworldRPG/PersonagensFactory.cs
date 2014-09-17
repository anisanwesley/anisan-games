using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorRPG
{
    public delegate void RacaHandler(Personagem personagem);
    public delegate void ClasseHandler(Personagem personagem);
    public delegate void ProfissaoHandler(Personagem personagem);
    
    public class PersonagensFactory
    {
        private Personagem _personagem;

        public void StartPersonagemCreation(string nome)
        {
            _personagem = new Personagem { Nome = nome };

        }

        public Personagem GetPersonagem()
        {
            if (String.IsNullOrWhiteSpace(_personagem.Nome))
                _personagem.Nome = "prisoner";

            if (String.IsNullOrWhiteSpace(_personagem.Raca))
                throw new Exception("Seu personagem não possui raça, chame AttributeRace(passando uma raça)");
            if (String.IsNullOrWhiteSpace(_personagem.Classes))
                throw new Exception("Seu personagem não possui classes, chame AttributeClasse(passando uma classe)");


            if (String.IsNullOrWhiteSpace(_personagem.Cota))
                throw new Exception("Seu personagem vai levar um tiro no peito");

            if (String.IsNullOrWhiteSpace(_personagem.Calcas))
                throw new Exception("Seu personagem vai levar uma flechada no joelho");

            if (String.IsNullOrWhiteSpace(_personagem.Sapatos))
                throw new Exception("Seu personagem vai pegar gripe por andar com pés descalços");

            if (String.IsNullOrWhiteSpace(_personagem.Bracadeiras))
                throw new Exception("Seu personagem não tem braçadeiras");

            if (String.IsNullOrWhiteSpace(_personagem.Capacete))
                throw new Exception("E se seu personagem precisar quebrar um tijolo com a cabeça?");

            if (String.IsNullOrWhiteSpace(_personagem.Arma))
                throw new Exception("Seu personagem não é o Dr. Xavier para andar desarmado");
            
            return _personagem;
        }



        public void AttributeRace(RacaHandler handler)
        {
            if (!String.IsNullOrWhiteSpace(_personagem.Raca))
                throw new ArgumentException("Personagem já possui uma raça!");

            handler(_personagem);
        }

        public void DismissRace(RacaHandler handler)
        {
            if (String.IsNullOrWhiteSpace(_personagem.Raca))
                throw new ArgumentException("Personagem não possui raça!");

            _personagem.Raca = "";
            handler(_personagem);

        }

        public void AttributeClass(ClasseHandler handler)
        {
            handler(_personagem);
        }

        public void DismissClass(ClasseHandler handler)
        {
            handler(_personagem);

        }

        public void AttributeProfissao(ProfissaoHandler handler)
        {
            if (!String.IsNullOrWhiteSpace(_personagem.Profissao))
                throw new ArgumentException("Personagem já possui ganha 1 salário mínimo com esta profissao!");

            handler(_personagem);
        }

        public void DismissProfissao(RacaHandler handler)
        {
            if (String.IsNullOrWhiteSpace(_personagem.Profissao))
                throw new ArgumentException("Personagem está desempregado!");
            
            _personagem.Profissao = "";
            handler(_personagem);

        }

        


    }
}
