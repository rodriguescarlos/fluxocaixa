using Fcx.Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcx.Caixa.Domain
{
    public class Lancamento : Entity, IAggregateRoot
    {
        public int CodigoLancamento { get; set; }
        public string Finalidade { get; set; }
        public char TipoDC { get; set; }
        public DateTime DataHoraCriacao { get; set; }

        public List<Movimento> Movimento { get; protected set; }

        //Construtor para o EF
        public Lancamento()
        {

        }

        public Lancamento(int codigoLancamento)
        {
            this.CodigoLancamento = codigoLancamento;
        }

    }
}
