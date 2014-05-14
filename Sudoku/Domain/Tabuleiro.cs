using System.Collections.Generic;
using System.Linq;

namespace Modelo
{
    public class Tabuleiro
    {
        public List<Campo> Campos { get; set; }

        public Tabuleiro()
        {
            Campos = new List<Campo>();
        }

        #region

        public bool NaoHaRepeticao(Campo campo)
        {
            //Pega todos os campos na mesma linha, coluna e quadrante
            var listaLinha = Campos.FindAll(c => c.LinhaId == campo.LinhaId);
            var listaColuna = Campos.FindAll(c => c.ColunaId == campo.ColunaId);
            var listaQuadro = Campos.FindAll(c => c.QuadroId == campo.QuadroId);

            //retorna true se não encontrar outro campo com o mesmo valor (excluindo ele mesmo)
            //também se não houver campos em hareas proximas
            var unicaLinha = !listaLinha.Any(c => c.Valor == campo.Valor && c.Id != campo.Id) || listaLinha.Count == 0;
            var unicaColuna = !listaColuna.Any(c => c.Valor == campo.Valor && c.Id != campo.Id) || listaColuna.Count == 0;
            var unicaQuadro = !listaQuadro.Any(c => c.Valor == campo.Valor && c.Id != campo.Id) || listaQuadro.Count == 0;

            //atualiza o estado "Válido" do campo
            campo.SetValidate(unicaLinha && unicaColuna && unicaQuadro);

            return campo.GetValidade();
        }

        public bool AdicionaCampo(Campo novoCampo)
        {
            var campo = Campos.Find(c => c.Id == novoCampo.Id);

            NaoHaRepeticao(novoCampo);

            if (campo == null)
            {
                //adiciona caso o campo não exista e tiver valor diferente de zero
                if (novoCampo.Valor != 0)
                    Campos.Add(novoCampo);
            }
            else
            {
                //remove o campo e o adiciona para garantir sua integridade
                Campos.Remove(campo);
                if (novoCampo.Valor != 0)
                    Campos.Add(novoCampo);
            }

            AtualizaCamposUnicos();

            return novoCampo.GetValidade();
        }

        public bool AtualizaCamposUnicos()
        {
            var todosOk = true;

            if (Campos.Count == 0) return true;

            foreach (var campo in Campos)
            {
                var coordenada = new[] { campo.QuadroId, campo.LinhaId, campo.ColunaId };

                foreach (var repeticoes in coordenada.Select(quadrantId => Campos.Count(c => c.Valor == campo.Valor && c.Id.Contains(quadrantId))))
                {
                    if (repeticoes > 1)
                    {
                        campo.Unico = false;
                        todosOk = false;
                        break;
                    }
                    campo.Unico = true;
                }
            }
            return todosOk;
        }

        public void InvalidaCampo(Campo novoCampo)
        {
            var campo = Campos.Find(f => f.Id == novoCampo.Id);
            campo.InvalidarCampo();
        }

        #endregion

        public void RemoveCampo(string id)
        {
            AdicionaCampo(id, 0);
        }

        public bool VerificaSeCampoExclusivo(int valor, string id)
        {
            var campo = Campos.Find(c => c.Id == id);

            return campo == null || campo.GetValidade();
        }

        public bool AdicionaCampo(string campoId, int valor)
        {
            var campo = new Campo(campoId, valor);

            AdicionaCampo(campo);

            campo = Campos.Find(c => c.Id == campoId);

            return campo == null || campo.GetValidade();
        }

        public bool VerificaSeCamposCompletos(int valor)
        {
            return Campos.Count(c => c.Valor == valor) == 9;
        }

        public List<Campo> GetCamposBuValue(int value)
        {
            return Campos.FindAll(c => c.Valor == value);
        }

        public void LimparTabuleiro()
        {
            Campos.Clear();
        }

        public bool ContemElementos()
        {
            return Campos.Count > 0;
        }

        public Campo GetCamposBuId(string fieldId)
        {
            return Campos.Find(c => c.Id.Contains(fieldId));
        }
    }
}