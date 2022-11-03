using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcx.Library.Application.Messages.Event
{
    public class MovimentoConsolidadoEvent : EventBase
    {
        public DateTime DataMovimento { get; set; }
        public decimal Debito { get; set; }
        public decimal Credito { get; set; }
        public decimal Saldo { get; set; }
        public char TipoDC { get; set; }

        public MovimentoConsolidadoEvent(
            Guid traceID
            , DateTime dataMovimento
            , decimal debito
            , decimal credito
            , decimal saldo
            , char tipoDC
            , IDictionary<string,string> additionalHeaders = null)
            :base(traceID, additionalHeaders)
        {
            this.DataMovimento = dataMovimento;
            this.TipoDC = tipoDC;
            this.Debito = debito;
            this.Credito = credito;
            this.Saldo = saldo;
        }
    }
}
