
using System.Collections.Generic;

namespace Pottencial.Domain.Entities
{
    public class ProdutoEntity : BaseEntity
    {
        public string Nome { get; set; }
        public double Valor { get; set; }
        public List<VendaEntity> Vendas { get; set; }
    }
}