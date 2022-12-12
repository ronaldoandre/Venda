using System;
using System.Collections.Generic;
using Pottencial.Domain.Enuns;

namespace Pottencial.Domain.Entities
{
    public class VendaEntity : BaseEntity
    {
        public DateTime DataVenda { get; set; }
        public StatusVendaEnum Status { get; set; }
        public List<ProdutoEntity> Produtos { get; set; }
        public VendedorEntity Vendedor { get; set; }
        public int VendedorId { get; set; }
    }
}