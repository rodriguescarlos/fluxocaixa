using Fcx.Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Fcx.Caixa.Domain
{
    public class MovimentoConsolidado : Entity, IAggregateRoot
    {
        public DateTime DataMovimento { get; set; }
        public decimal Debito { get; set; }
        public decimal Credito { get; set; }
        public decimal Saldo { get; set; }
        public char TipoDC { get; set; }
    }
}
