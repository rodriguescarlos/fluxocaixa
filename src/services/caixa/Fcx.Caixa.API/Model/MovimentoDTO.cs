using System.ComponentModel.DataAnnotations;

namespace Fcx.Caixa.API.Model
{
    public class MovimentoDTO
    {
        [Required(ErrorMessage ="Valor não pode ser menor ou igual a zero")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage ="Código do Lançamento deve ser informado.")]
        public short CodigoLancamento { get; set; }
    }
}
